using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Csharp.Pages.General;
using Csharp.EventsAggregator;
using Csharp.Ios;
using SAP.Middleware.Connector;
using Csharp.Pages.RecipePars;
using System.Threading;

namespace Csharp.Pages.SAP_Production
{
    public partial class uc_SAP_Production : UserControl
    {
        private static iNotifyCycle parameters;
        private static iNotifyCycleFinished parameters_finished;
        private Thread threatProduction;
        public static string sSelectedRecipe;
        private string functionName = "ZPP_MAK_ENT_KONF", setValueName = "I_AUFNR", setValue = "", tableName = "ZPP_KONF_DEGER";
        private eChooseSelectedRecipeButton fooChooseSelectedRecipeButton;
        Dictionary<int, ShoppingCard> dic_ShoppingList_Transient;
        private Dictionary<int, ShoppingCard> dic_ShoppingList;
        private int counter = 1; // ShoppingList' in içindeki Recipe'leri dönmeye yarar.
        //private int kullanilanAdet = 0;
        public uc_SAP_Production()
        {
            InitializeComponent();
            dic_ShoppingList = new Dictionary<int, ShoppingCard>();
            dic_ShoppingList_Transient = new Dictionary<int, ShoppingCard>();
        }
        private void uc_RecipeParsPage_Load(object sender, EventArgs e)
        {
            List<string> listRecipes = new List<string>();
            listRecipes = RecipePars_ToPLC.Read_Recipe_Names();
            fooChooseSelectedRecipeButton = new eChooseSelectedRecipeButton();

            eRecipeParameterChanged.eChanged -= ERecipeParameterChanged_eChanged;
            eRecipeParameterChanged.eChanged += ERecipeParameterChanged_eChanged;

            eUpdate_RecipeList.eChanged -= EUpdateRecipes_eChanged;
            eUpdate_RecipeList.eChanged += EUpdateRecipes_eChanged;

            //Selected Recipe ile açılsın
            if (staticSelectedRecipe.sName != null)
            {
                sSelectedRecipe = staticSelectedRecipe.sName;
                RecipePars_ToPLC.dicRecipePars_Displaying_Bools.Clear();
                RecipePars_ToPLC.dicRecipePars_Displaying_Nums.Clear();

                RecipePars_ToPLC.nDisplaying_Recipe_Id = RecipePars_ToPLC.Find_RecipeId_FromName(sSelectedRecipe);
                RecipePars_ToPLC.sDisplaying_RecipeName = sSelectedRecipe;
                RecipePars_ToPLC.SelectDisplayingRecipe(RecipePars_ToPLC.sDisplaying_RecipeName);
            }

            ParametersOnPropertyChanged(null, null);
            iNotifyCycle.eChanged += ParametersOnPropertyChanged;

            //ParametersOnPropertyChangedForFinished(null, null);
            iNotifyCycleFinished.eChanged += ParametersOnPropertyChangedForFinished;

            #region ///////////////////////////        listView1 Columns      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ListView_Order.HotTracking = true;
            ListView_Transient.HotTracking = false;

            //ShoppingCard shoppingCard = new ShoppingCard("", "", "", "", 0, 0, "");
            //OrderList.Columns.Add("", 1, HorizontalAlignment.Center);
            //foreach (var property in shoppingCard.GetType().GetProperties())
            //{
            //    if (property.Name != "KullanilanAdet" && property.Name != "Recete")
            //    {
            //        var nameLength = property.Name == "QrCode" ? (float)(property.Name.Length / 57.0) : (float)(property.Name.Length / 90.7);
            //        int width = (int)Math.Round(tableLayoutPanel4.Width * nameLength);
            //        OrderList.Columns.Add(property.Name, width, HorizontalAlignment.Center);
            //    }
            //}

            #region ///////////////////////////        listView1 Columns      \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ListView_Order.Columns.Add("", 1, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("Açıklama", (tableLayoutPanel4.Width / 3 + 2), HorizontalAlignment.Center);
            ListView_Order.Columns.Add("FormTürü", tableLayoutPanel4.Width / 10, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("FormTipi", tableLayoutPanel4.Width / 12, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("Genişlik", tableLayoutPanel4.Width / 12, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("Kalınlık", tableLayoutPanel4.Width / 12, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("Adet", tableLayoutPanel4.Width / 20, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("Ü.Adet", tableLayoutPanel4.Width / 16, HorizontalAlignment.Center);
            ListView_Order.Columns.Add("ÜrünNo", tableLayoutPanel4.Width / 13, HorizontalAlignment.Center);

            UpdateListView();
            #endregion

            ListView_Transient.Columns.Add("", 1, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("Açıklama", (tableLayoutPanel4.Width / 3 + 2), HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("FormTürü", tableLayoutPanel4.Width / 10, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("FormTipi", tableLayoutPanel4.Width / 12, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("Genişlik", tableLayoutPanel4.Width / 12, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("Kalınlık", tableLayoutPanel4.Width / 12, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("Adet", tableLayoutPanel4.Width / 20, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("Ü.Adet", tableLayoutPanel4.Width / 16, HorizontalAlignment.Center);
            ListView_Transient.Columns.Add("ÜrünNo", tableLayoutPanel4.Width / 13, HorizontalAlignment.Center);

            UpdateListView_Transient();
            #endregion
        }

        public static void Init()
        {
            parameters = new iNotifyCycle();
            parameters_finished = new iNotifyCycleFinished();
        }
        private void ParametersOnPropertyChanged(object sender, iNotifyCycle e)  // The Control of Start Thread Operation
        {
            try
            {
                if (IO.Bits.IsCycle && dic_ShoppingList.Count > 0)
                {
                    dic_ShoppingList[counter].KullanilanAdet++;
                    UpdateListView();
                    if (threatProduction == null || threatProduction.ThreadState == ThreadState.Stopped)
                    {
                        threatProduction = new Thread(new ThreadStart(Start_SelectedRecipesSAP));
                    }
                    if (threatProduction != null)
                    {
                        if (!threatProduction.IsAlive)
                        {
                            threatProduction.Start();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }
        private void ParametersOnPropertyChangedForFinished(object sender, iNotifyCycleFinished e)
        {
            if (dic_ShoppingList.Count == 0 && staticSelectedRecipe.sName != null && IO.Bits.IsCycleFinished/*&& threatProduction.ThreadState != ThreadState.Running*/)
            {
                int offeredRecipeId = OfferedId_ProducedRecipes();
                string path = Thread.GetDomain().BaseDirectory + "//ProducedRecipes" + "//" + staticSelectedRecipe.sName + "_" + offeredRecipeId.ToString() + ".xml";

                File.Copy(Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//RecipeParameters_Empty.xml", path);

                if (File.Exists(path)) { File.SetLastWriteTime(path, DateTime.Now); }

                fooUpdateRecipes = new eUpdate_RecipeList();
                fooUpdateRecipes.EventFired();
            }
        }
        private object Reflection_Get_A_Property(object _object, string propName)
        {
            return _object.GetType().GetProperty(propName).GetValue(_object, null);
        }

        private void UpdateListView()
        {
            ListView_Order.GridLines = true;
            ListView_Order.Items.Clear();

            if (dic_ShoppingList != null)
            {
                foreach (var item in dic_ShoppingList)
                {
                    ListViewItem _listViewItem;
                    if (item.Value is ShoppingCard)
                    {
                        if ((int)Reflection_Get_A_Property(item.Value, "UretilenAdet") == (int)Reflection_Get_A_Property(item.Value, "Adet"))
                        {
                            _listViewItem = new ListViewItem(null, 1, Color.White, Color.Green, null);
                        }
                        else if (/*(int)Reflection_Get_A_Property(item.Value, "UretilenAdet") != */(int)Reflection_Get_A_Property(item.Value, "KullanilanAdet") > 0)
                        {
                            _listViewItem = new ListViewItem(null, 1, Color.White, Color.LightBlue, null);
                        }
                        else
                        {
                            _listViewItem = new ListViewItem();
                        }

                        /*********         Sırası karışıyor yoksa güzel bir deneme oldu         ***********/
                        //foreach (var property in item.Value.GetType().GetProperties())
                        //{
                        //    var getValue = property.GetValue(item.Value, null).ToString();
                        //    _listViewItem.SubItems.Add(getValue, Color.Black, Color.Blue, DefaultFont);
                        //}
                        _listViewItem.SubItems.Add(item.Value.UrunAciklama.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item1.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item2.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item3.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item4.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Adet.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.UretilenAdet.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.QrCode.ToString(), Color.Black, Color.Blue, DefaultFont);

                        ListView_Order.Items.Add(_listViewItem);
                    }
                }
            }
        }
        private void UpdateListView_Transient()
        {
            ListView_Transient.GridLines = true;
            ListView_Transient.Items.Clear();

            if (dic_ShoppingList_Transient != null)
            {
                foreach (var item in dic_ShoppingList_Transient)
                {
                    ShoppingCard shoppingCard = (ShoppingCard)item.Value;
                    ListViewItem _listViewItem;
                    if (item.Value is ShoppingCard)
                    {
                        var order = item.Key.ToString();

                        if ((int)Reflection_Get_A_Property(item.Value, "UretilenAdet") == (int)Reflection_Get_A_Property(item.Value, "Adet"))
                        {
                            _listViewItem = new ListViewItem(null, 1, Color.White, Color.Green, null);
                        }
                        else if ((int)Reflection_Get_A_Property(item.Value, "UretilenAdet") != (int)Reflection_Get_A_Property(item.Value, "KullanilanAdet"))
                        {
                            _listViewItem = new ListViewItem(null, 1, Color.White, Color.LightBlue, null);
                        }
                        else
                        {
                            _listViewItem = new ListViewItem();
                        }

                        _listViewItem.SubItems.Add(item.Value.UrunAciklama.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item1.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item2.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item3.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Recete.Item4.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.Adet.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.UretilenAdet.ToString(), Color.Black, Color.Blue, DefaultFont);
                        _listViewItem.SubItems.Add(item.Value.QrCode.ToString(), Color.Black, Color.Blue, DefaultFont);

                        ListView_Transient.Items.Add(_listViewItem);
                    }
                }
            }
        }
        private void EUpdateRecipes_eChanged(object sender, eUpdate_RecipeList e)
        {
            List<string> listRecipes = new List<string>();
            listRecipes = RecipePars_ToPLC.Read_Recipe_Names();
        }
        private void ERecipeParameterChanged_eChanged(object sender, eRecipeParameterChanged e)
        {
            FillDatasetFromUserControls();
            if (staticSelectedRecipe.sName == RecipePars_ToPLC.sDisplaying_RecipeName) // Değişiklik yapılan reçete aktuel reçete
            {
                FillDatasetFromUserControls();
                RecipePars_ToPLC.SelectRecipe(staticSelectedRecipe.sName);
                RecipePars_ToPLC.WritePLC();
            }
        }

        private void FillDatasetFromUserControls()
        {
            #region[First Fill Dictionaries]


            #endregion
            foreach (var item in RecipePars_ToPLC.dicRecipePars_Displaying_Bools)
            {
                RecipePars_ToPLC.ds_Displaying_recipePars.Tables["Recipe Parameters Bools"].Rows[item.Key]["Value"] = RecipePars_ToPLC.dicRecipePars_Displaying_Bools[item.Key].Value;
            }
            foreach (var item in RecipePars_ToPLC.dicRecipePars_Displaying_Nums)
            {
                RecipePars_ToPLC.ds_Displaying_recipePars.Tables["Recipe Parameters Nums"].Rows[item.Key]["Value"] = RecipePars_ToPLC.dicRecipePars_Displaying_Nums[item.Key].Value;
            }

            if (RecipePars_ToPLC.sDisplaying_RecipeName == null)
            {
                RecipePars_ToPLC.ds_Displaying_recipePars.WriteXml(System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//RecipeParameters_Empty.xml");
            }
            else
            {
                RecipePars_ToPLC.ds_Displaying_recipePars.WriteXml(System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//" + RecipePars_ToPLC.sDisplaying_RecipeName + ".xml");
            }
        }

        private List<string> SeparateEmirNumbers()
        {
            List<string> list = new List<string>();
            string emirNo = "";

            foreach (var item in tb_SiparisNo.Text)
            {
                var itemString = item.ToString();
                if (!item.Equals('.') && !item.Equals('/'))
                {
                    emirNo = emirNo.Insert(emirNo.Length, itemString);
                }
                else
                {
                    list.Add(emirNo);
                    emirNo = "";
                }
            }
            return list;
        } //Emir numaraları içeren bir liste oluşturur.
        private void SelectedRecipeSAP()
        {
            DirectoryInfo fileInfo = new DirectoryInfo(System.Threading.Thread.GetDomain().BaseDirectory + "\\RecipeParameters");
            List<int> strings = new List<int>();
            foreach (FileInfo item in fileInfo.GetFiles())
            {
                var x = dic_ShoppingList[counter].GetRecipeName();
                if (item.ToString().Contains(x))
                {
                    strings.Add(Convert.ToInt32(item.ToString().Split('.').First().Split('_').Last()));
                }
            }

            if (strings != null && strings.Count != 0)
            {
                int kucuk = strings[0];
                for (int i = 0; i < strings.Count; i++)
                {
                    if (kucuk > strings[i])
                    { kucuk = strings[i]; }
                }

                foreach (FileInfo item in fileInfo.GetFiles())
                {
                    if (item.ToString().Split('.').First().Split('_').Last().Equals(kucuk.ToString()))
                    {
                        sSelectedRecipe = item.ToString().Split('.').First();
                        staticSelectedRecipeForSAP.sName = sSelectedRecipe;
                        staticSelectedRecipeForSAP.sThickness = dic_ShoppingList[counter].Recete.Item4;
                    }
                }
            }
            else
            {
                MyMessageBox.ShowMessageBox($"SAP verilerine karşılık gelecek bir reçete bulunamadı. \nLütfen kontrol ediniz!"); // \nReçete: {selectedRecipeFromSAP}
                return;
            }
        }
        private void btn_GetAllRecipe_SAP_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var emirNo in SeparateEmirNumbers()) //Ayrılmış her bir emir numarası dönülüyor. Örn: 508112252
                {
                    setValue = emirNo;
                    if (setValue != null && setValue != "")
                    {
                        List<string> _list = new List<string>();
                        _list = SAP_Entegrator(functionName, setValueName, setValue, tableName); //SAP'dan emirNo'ya uygun bilgiler _list'e aktarıldı.

                        string formType = _list[0].Contains("Bakır") ? "BakırLama" : "AlüminyumLama";
                        string formHeight = "";
                        if (_list[1].Contains("Alcak Forma")) { formHeight = "L1L2"; }
                        else if (_list[1].Contains("Yuksek Forma")) { formHeight = "L3N"; }
                        else if (_list[1].Contains("CPE")) { formHeight = "CPE"; }
                        else { formHeight = "PE"; }
                        string formWidth = _list[2] + "mm";
                        string formThickness = _list[3] == "6 mm" ? "6mm" : "3mm";
                        int adetMiktari = Convert.ToInt32(_list[4].Split('.')[0]);
                        int qrCode = Convert.ToInt32(_list[5]);
                        string urunAciklama = _list[6];

                        string selectedRecipeFromSAP = formType + "_" + formHeight + "_" + formWidth + "_" + formThickness;

                        ShoppingCard shoppingCard = new ShoppingCard(formType, formHeight, formWidth, formThickness, adetMiktari, qrCode, urunAciklama);
                        dic_ShoppingList_Transient.Add(dic_ShoppingList_Transient.Count + 1, shoppingCard);
                        UpdateListView_Transient();

                        /*
                         * SİL!
                         * 
                        string path = Thread.GetDomain().BaseDirectory + "\\ProducedRecipes_SAP";
                        DirectoryInfo fileInfo = new DirectoryInfo(path);
                        List<DateTime> strings = new List<DateTime>();
                        foreach (FileInfo item in fileInfo.GetFiles())
                        {
                            strings.Add(File.GetLastAccessTime(item.FullName));
                        }

                        strings.Clear();
                        */

                        //foreach (var item in dic_ShoppingList.Values)
                        //{
                        //    int offeredRecipeId = OfferedId_ProducedRecipes();
                        //    string path = Thread.GetDomain().BaseDirectory + "//ProducedRecipes_SAP" + "//" + item.GetRecipeName() + "_" + offeredRecipeId.ToString() + ".xml";

                        //    File.Copy(Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//RecipeParameters_Empty.xml", path);

                        //    if (File.Exists(path)) { File.SetLastWriteTime(path, DateTime.Now); }

                        //    fooUpdateRecipes = new eUpdate_RecipeList();
                        //    fooUpdateRecipes.EventFired();

                        //}
                    }
                    else
                    {
                        MyMessageBox.ShowMessageBox("Üretim numarası eksik veya hatalı girilmiştir. \nLütfen kontrol ediniz!"); return;
                    }
                }
            }
            catch (Exception)
            {
                MyMessageBox.ShowMessageBox("Sistemde böyle bir üretim numarası mevcut değildir!");
            }

        }
        private List<string> SAP_Entegrator(string functionName, string setValueName, string setValue, string tableName)
        {
            List<string> list = new List<string>();

            // SAP bağlantı oluşturma için gereken bilgiler
            RfcConfigParameters config = new RfcConfigParameters();
            config.Add(RfcConfigParameters.Name, "SAPConnect");
            config.Add(RfcConfigParameters.AppServerHost, "192.168.10.197");
            config.Add(RfcConfigParameters.SystemNumber, "00");
            config.Add(RfcConfigParameters.User, "ZDEFAR");
            config.Add(RfcConfigParameters.Password, "EaFG+GH24");
            config.Add(RfcConfigParameters.Client, "400");
            config.Add(RfcConfigParameters.Language, "TR");
            config.Add(RfcConfigParameters.PoolSize, "5");

            RfcDestination destination = RfcDestinationManager.GetDestination(config);

            IRfcFunction function = destination.Repository.CreateFunction(functionName);
            function.SetValue(setValueName, setValue);
            function.Invoke(destination);

            string malzemeCinsi = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("ILETKEN_CINSI")).ToList()[0].GetString(1); list.Add(malzemeCinsi);     // Bakır - Alüminyum
            string formYuksekligi = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("BARA_FORMA")).ToList()[0].GetString(1); list.Add(formYuksekligi);   // Alcak Forma - Yuksek Forma - CPE - PE
            string formGenisligi = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("BARA_KESIT")).ToList()[0].GetString(1); list.Add(formGenisligi);    // 25 - 60 - 180 - 250
            string formKalinligi = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("BARA_KALINLIK")).ToList()[0].GetString(1); list.Add(formKalinligi);    // 6 mm - 3 mm
            string adetMiktari = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("MIKTAR")).ToList()[0].GetString(1); list.Add(adetMiktari);      // 2.000 - 15.000
            string emirNoSayisi = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("EMIR_NO")).ToList()[0].GetString(1); list.Add(emirNoSayisi);     // 508111562
            string urunAciklama = function.GetTable(tableName).
                Where(p => p.GetString(0).Contains("ACIKLAMA")).ToList()[0].GetString(1); list.Add(urunAciklama);     // AL ARAB P BARA 80 L3(CIKISLI BARA)

            return list;
        }

        public void Start_SelectedRecipesSAP() //Thread methodudur ve PLC'nin seçili reçetesini değiştirir.
        {
            int token = 0;

            switch (token)
            {
                case 0:
                    if (IO.Bits.IsCycleFinished)
                    {
                        if (dic_ShoppingList[counter].KullanilanAdet == 2)
                        {
                            dic_ShoppingList[counter].KullanilanAdet = 0;
                            dic_ShoppingList[counter].UretilenAdet++;
                        }

                        UpdateListView();

                        if (dic_ShoppingList[counter].Adet == dic_ShoppingList[counter].UretilenAdet)
                        {
                            counter++;
                        }
                        if (counter > dic_ShoppingList.Count)
                        {
                            //PLC'ye yeni reçeteyi gönderildi dendi.
                            goto case 20;
                        }
                        else
                        {
                            SelectedRecipeSAP(); // Sıradaki reçete seçildi bayrağı kalktı ve bilgi PLC'ye gönderildi.
                            fooChooseSelectedRecipeButton.EventFired();
                            //PLC'ye yeni reçeteyi gönderildi dendi.

                            goto case 10;
                        }

                    }
                    else
                    {
                        goto case 0;
                    }

                case 10: // Yeni reçeteyi gönderdim denildikten sonra PLC'den SAP workinge hazır bilgisi bekleniliyor.
                    if (!IO.Bits.IsCycleFinished)  //PLC den Workinge hazır bilgisi geldi
                    {
                        //Sıradaki reçete seçildi bayrağı düştü.
                        goto case 0;
                    }
                    else
                    {
                        goto case 10;
                    }
                case 20:
                    counter = 1;
                    threatProduction.Abort();

                    foreach (var item in dic_ShoppingList.Values)
                    {
                        int offeredRecipeId = OfferedId_ProducedRecipes();
                        string path = Thread.GetDomain().BaseDirectory + "//ProducedRecipes_SAP" + "//" + item.GetRecipeName() + "_" + offeredRecipeId.ToString() + ".xml";

                        File.Copy(Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//RecipeParameters_Empty.xml", path);

                        if (File.Exists(path)) { File.SetLastWriteTime(path, DateTime.Now); }

                        fooUpdateRecipes = new eUpdate_RecipeList();
                        fooUpdateRecipes.EventFired();
                    }
                    dic_ShoppingList.Clear();
                    UpdateListView();
                    break;
            }
        }
        private eUpdate_RecipeList fooUpdateRecipes;

        private int OfferedId_ProducedRecipes()
        {
            List<int> listRecipes = new List<int>();
            string value;
            string value2;
            string[] value3;
            int RecipeId;
            DirectoryInfo fileInfo = new DirectoryInfo(Thread.GetDomain().BaseDirectory + "\\ProducedRecipes");
            foreach (FileInfo item in fileInfo.GetFiles())
            {
                value = item.ToString();
                value2 = value.Split('_').Last();
                value3 = value2.Split('.');
                if (value3[0] == "Empty")
                {
                    ;
                }
                else
                {
                    RecipeId = Convert.ToInt32(value3[0]);
                    listRecipes.Add(RecipeId);
                }
            }

            if (listRecipes.Count == 0)
            {
                return 1;
            }
            else
            {
                return (listRecipes.Max() + 1);
            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Consolas", 16, FontStyle.Bold))
                {
                    e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds);
                    e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption,
                        new Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height));
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.WhiteSmoke, e.Bounds, sf);
                }
            }
        }
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.DarkKhaki, e.Bounds);
                e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption,
                            new Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
        }
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = ListView_Order.GetItemAt(0, e.Y);
            if (clickedItem != null)
            {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
            }
        }

        private void listView2_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Consolas", 16, FontStyle.Bold))
                {
                    e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds);
                    e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption,
                        new Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height));
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.WhiteSmoke, e.Bounds, sf);
                }
            }
        }

        private void ReOrder_ShoppingList_Transient()
        {
            Dictionary<int, ShoppingCard> _fooList = new Dictionary<int, ShoppingCard>();
            int i = 1;
            foreach (var item in dic_ShoppingList_Transient)
            {
                _fooList.Add(i, item.Value);
                i = i + 1;
            }
            dic_ShoppingList_Transient.Clear();
            dic_ShoppingList_Transient = _fooList;
        }
        private void btn_Send2Work_Click(object sender, EventArgs e)
        {
            if (dic_ShoppingList_Transient.Count > 0)
            {
                ReOrder_ShoppingList(dic_ShoppingList_Transient);
            }
            else
            {
                MyMessageBox.ShowMessageBox("Tabloda gönderilecek bir ürün bulunmamaktadır.");
            }
        }

        private void ReOrder_ShoppingList(Dictionary<int, ShoppingCard> eklenenListe)
        {
            int count = dic_ShoppingList.Count + 1;
            foreach (var eleman in eklenenListe)
            {
                dic_ShoppingList.Add(count, eleman.Value);
                count++;
            }

            UpdateListView();

            dic_ShoppingList_Transient.Clear();
            UpdateListView_Transient();

            if (dic_ShoppingList.Count > 0)
            {
                SelectedRecipeSAP();
                fooChooseSelectedRecipeButton.EventFired();
            }
        }
        private void btn_DeleteAllList_Click(object sender, EventArgs e)
        {
            //int iLoginResult = Frm_MachinePars_Login.ShowLogin();
            //if (iLoginResult == 1)
            //{
            if (MyMessageBox.ShowMessageBox("Tablo temizlenecek! Onaylıyor musunuz?", true) == 1)
            {
                dic_ShoppingList_Transient.Clear();
                UpdateListView_Transient();
            }
        }
        private void btn_DeleteAllOrderList_Click(object sender, EventArgs e) //Kontrol et!
        {
            //int iLoginResult = Frm_MachinePars_Login.ShowLogin();
            //if (iLoginResult == 1)
            //{
            if (MyMessageBox.ShowMessageBox("Tablo temizlenecek! Onaylıyor musunuz? \nDİKKAT: Üretim yapıyorsanız tablo temizlenirse üretim İPTAL edilecek!", true) == 1)
            {
                dic_ShoppingList.Clear();
                UpdateListView();
                if (threatProduction != null && threatProduction.ThreadState == ThreadState.Running)
                {
                    threatProduction.Abort();
                }
            }
        }

        private void btn_SingleSend2Work_Click(object sender, EventArgs e)
        {
            if (dic_ShoppingList_Transient.Count > 0)
            {
                var eklenenListe = dic_ShoppingList_Transient.SingleOrDefault(x => x.Key == _clickedItem + 1).Value;

                int count = dic_ShoppingList.Count + 1;

                dic_ShoppingList.Add(count, eklenenListe);

                UpdateListView();

                dic_ShoppingList_Transient.Remove(_clickedItem + 1);

                ReOrder_ShoppingList_Transient();
                UpdateListView_Transient();

                if (dic_ShoppingList.Count > 0)
                {
                    SelectedRecipeSAP();
                    fooChooseSelectedRecipeButton.EventFired();
                }
            }
            else
            {
                MyMessageBox.ShowMessageBox("Tabloda gönderilecek bir ürün bulunmamaktadır.");
            }
        }
        private void btn_Collapsed_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = true;
                btn_Collapsed.Text = "▼";
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
                btn_Collapsed.Text = "▲";
            }
        }

        private void btn_CollapsedList2_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = true;
                btn_CollapsedList2.Text = "▲";
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                btn_CollapsedList2.Text = "▼";
            }
        }

        private void listView2_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.DarkKhaki, e.Bounds);
                e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption,
                            new Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height));
                e.DrawFocusRectangle();
            }
        }
        private void listView2_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private int _clickedItem;
        private void listView2_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = ListView_Transient.GetItemAt(0, e.Y);
            if (clickedItem != null)
            {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
                _clickedItem = clickedItem.Index;
            }
        }
    }
}
