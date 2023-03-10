using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Csharp.Pages.RecipePars;
using Csharp.EventsAggregator;
using Csharp.Pages.General;
using System.Windows.Media;
using PLCcomModbus.Core;
using Color = System.Drawing.Color;
using Brushes = System.Drawing.Brushes;
using System.Windows.Controls;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Label = System.Windows.Forms.Label;
using Csharp.Pages.MachinePars;
using CustomControls.RJControls;
using LiveCharts.Dtos;
using System.Diagnostics;

namespace Csharp.RecipePars
{
    public partial class RecipeSelection : Form
    {
        public RecipeSelection()
        {
            InitializeComponent();
            this.DataBindings.Add("Text", label_text, nameof(Label.Text));

            try //Name lerin "_" ile sıralanmış olması önemli. İçlerini otomatik olarak dolduruyoruz.
            {
                foreach (RoundedButton ucBool in tableLayoutPanel33.Controls.OfType<RoundedButton>())
                {
                    if (ucBool.Name.Contains("roundedButton_"))
                    {
                        string[] splitted = ucBool.Name.Split('_');
                        int order = Convert.ToInt32(splitted[1]);
                        if (MachinePars_ToPLC.dicMachinePars_Bools[order + 17].Value == true)
                        {
                            ucBool.Visible = true;
                            ucBool.Text = MachinePars_ToPLC.dicMachinePars_Bools[order + 17].Alias;
                        }
                    }

                }
                foreach (RoundedButton ucBool in tableLayoutPanel19.Controls.OfType<RoundedButton>())
                {
                    if (ucBool.Name.Contains("roundedButton_"))
                    {
                        string[] splitted = ucBool.Name.Split('_');
                        int order = Convert.ToInt32(splitted[1]);
                        if (MachinePars_ToPLC.dicMachinePars_Bools[order + 17].Value == true)
                        {
                            ucBool.Visible = true;
                            ucBool.Text = MachinePars_ToPLC.dicMachinePars_Bools[order + 17].Alias;
                        }
                    }
                }
                foreach (RoundedButton ucBool in tableLayoutPanel5.Controls.OfType<RoundedButton>())
                {
                    if (ucBool.Name.Contains("roundedButton_"))
                    {
                        string[] splitted = ucBool.Name.Split('_');
                        int order = Convert.ToInt32(splitted[1]);
                        if (MachinePars_ToPLC.dicMachinePars_Bools[order + 17].Value == true)
                        {
                            ucBool.Visible = true;
                            ucBool.Text = MachinePars_ToPLC.dicMachinePars_Bools[order + 17].Alias;
                        }
                    }
                }
                for (int i = 31; i <= 63; i++)
                {
                    if (MachinePars_ToPLC.dicMachinePars_Nums[i].Item1.Value == 1)
                    {
                        cb_formGenis.Items.Add(MachinePars_ToPLC.dicMachinePars_Nums[i].Item1.Alias);
                    }
                }
            }
            catch (Exception e)
            {
                ;
            }
        }
        private static RecipeSelection recipeSelection;
        private static string fooOfSelectedRecipe;
        private static string resultOfSelectedRecipe;
        private static string resultOfSelectedRecipe_add;
        private static List<string> recipeNames;
        public static string ShowSelection(List<string> _recipeNames, string _titleName)
        {
            b_ShowSelection = true;
            recipeNames = _recipeNames;
            recipeSelection = new RecipeSelection();
            recipeSelection.label_text.Text = _titleName.ToUpper();

            recipeSelection.tb_userEntry.Visible = false;
            recipeSelection.listView1.Visible = true;

            recipeSelection.ShowDialog();
            b_ShowSelection = false;

            return resultOfSelectedRecipe;
        }

        private static bool b_ShowSelection_For_Machine;
        private static bool b_ShowSelection;
        public static string ShowSelection_For_Machine(List<string> _recipeNames, string _titleName)
        {
            b_ShowSelection_For_Machine = true;
            recipeNames = _recipeNames;
            recipeSelection = new RecipeSelection();
            recipeSelection.label_text.Text = _titleName.ToUpper();

            recipeSelection.tb_userEntry.Visible = false;
            recipeSelection.listView1.Visible = true;

            recipeSelection.ShowDialog();
            b_ShowSelection_For_Machine = false;
            return resultOfSelectedRecipe;
        }
        public static bool b_AddRecipe;
        public static string AddRecipeSelection(List<string> _recipeNames, string _titleName, string btnEkleName)
        {
            b_AddRecipe = true;
            recipeNames = _recipeNames;
            recipeSelection = new RecipeSelection();

            recipeSelection.btn_Ekle.Text = btnEkleName;
            recipeSelection.label_text.Text = _titleName.ToUpper();


            recipeSelection.tb_userEntry.Visible = true;
            recipeSelection.listView1.Visible = false;

            if (Non_materialInfo_add != null && formHeight_add != null && formWidth_add != null && formThickness_add != null && userEntry != null)
            {
                Non_materialInfo_add = null;
                formHeight_add = null;
                formWidth_add = null;
                formThickness_add = null;
                userEntry = null;
            }

            recipeSelection.ShowDialog();

            b_AddRecipe = false;

            if (resultOfSelectedRecipe_add != "İptal Edildi")
            {
                if (Non_materialInfo_add == null || formHeight_add == null || formWidth_add == null || formThickness_add == null || userEntry == null)
                {
                    resultOfSelectedRecipe_add = null;
                    MyMessageBox.ShowMessageBox("Reçete bilgilerini eksiksiz giriniz!");
                }
            }
            return resultOfSelectedRecipe_add;
        }

        public static bool b_SaveAsRecipe;
        public static string SaveAsRecipeSelection(List<string> _recipeNames, string _titleName, string btnEkleName)
        {
            b_SaveAsRecipe = true;
            b_Non_materialInfo = false;
            b_formHeight = false;
            b_formWidth = false;
            b_formThickness = false;

            recipeNames = _recipeNames;
            recipeSelection = new RecipeSelection();
            recipeSelection.btn_Ekle.Text = btnEkleName;
            recipeSelection.btn_Bakir.Enabled = true;
            recipeSelection.btn_Aluminyum.Enabled = true;
            recipeSelection.btn_LevhaBakir.Enabled = true;
            recipeSelection.btn_LevhaAluminyum.Enabled = true;

            recipeSelection.btn_11600.Enabled = true;
            recipeSelection.btn_16500.Enabled = true;
            recipeSelection.btn_31200.Enabled = true;
            recipeSelection.btn_35000.Enabled = true;

            recipeSelection.cb_formGenis.Enabled = true;

            recipeSelection.btn_3mm.Enabled = true;
            recipeSelection.btn_6mm.Enabled = true;

            recipeSelection.label_text.Text = _titleName.ToUpper();


            formHeight_add = null;
            formWidth_add = null;
            formThickness_add = null;
            userEntry = null;
            s_userEntry = null;

            // resultOfSelectedRecipe_SaveAs = recipeSelection.Filter_saveAsParemeters(resultOfSelectedRecipe);
            //resultOfSelectedRecipe_SaveAs = recipeSelection.Filter_saveAsParemeters(resultOfSelectedRecipe);
            b_AddRecipe = true;
            recipeSelection.ShowDialog();
            b_AddRecipe = false;
            b_SaveAsRecipe = false;

            //if (resultOfSelectedRecipe_SaveAs_iptal == true)
            //{
            //    resultOfSelectedRecipe_SaveAs = null;
            //    resultOfSelectedRecipe_SaveAs_iptal = false;
            //}
            //else
            //{
            //    if (userEntry == "")
            //    {
            //        resultOfSelectedRecipe_SaveAs = null;
            //        MyMessageBox.ShowMessageBox("Reçete bilgilerini eksiksiz giriniz!");
            //    }
            //    else
            //    {
            //        resultOfSelectedRecipe_SaveAs = resultOfSelectedRecipe_SaveAs + userEntry;
            //    }

            //}
            return resultOfSelectedRecipe_add;
        }

        List<string> Non_materialInfo = new List<string>();
        List<string> formHeight = new List<string>();
        List<string> formWidth = new List<string>();
        List<string> formThickness = new List<string>();
        List<int> list_token = new List<int>();
        private static List<int> _list_token = new List<int>();
        private static List<int> _list_token_token = new List<int>();

        public static string Non_materialInfo_add, formHeight_add, formWidth_add, formThickness_add, userEntry;
        public static bool b_Non_materialInfo, b_formHeight, b_formWidth, b_formThickness;

        #region \\\\\\\\\\\\\\\    MALZEME BİLGİSİ BUTONLARI    ///////////////
        private void btn_Bakir_Click(object sender, EventArgs e)
        {
            Non_materialInfo = Filter_formParameters("BakırLama", Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("Bakır", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = "BakırLama";

            //buton renk ayarları 
            btn_Bakir.BackColor = Color.FromArgb(131, 175, 155);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(1);
            b_Non_materialInfo = true;
        }
        private void btn_Aluminyum_Click(object sender, EventArgs e)
        {
            Non_materialInfo = Filter_formParameters("AlüminyumLama", Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("Alüminyum", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = "AlüminyumLama";

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(131, 175, 155);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(2);
            b_Non_materialInfo = true;
        }
        private void btn_LevhaBakir_Click(object sender, EventArgs e)
        {
            Non_materialInfo = Filter_formParameters("BakırPlaka", Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("BakırLevha", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = "BakırPlaka";

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(131, 175, 155);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(3);
            b_Non_materialInfo = true;
        }
        private void btn_LevhaAluminyum_Click(object sender, EventArgs e)
        {
            Non_materialInfo = Filter_formParameters("AlüminyumPlaka", Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("AlüminyumLevha", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = "AlüminyumPlaka";

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(131, 175, 155);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(4);
            b_Non_materialInfo = true;
        }

        #region ///////////     RESERVE BUTTONS     \\\\\\\\\\\\\
        private string button_ID;
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            button_ID = MachinePars_ToPLC.dicMachinePars_Bools[18].Alias;
            Non_materialInfo = Filter_formParameters(button_ID, Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("AlüminyumLevha", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = button_ID;

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(5);
            b_Non_materialInfo = true;
        }
        private void roundedButton_2_Click(object sender, EventArgs e)
        {
            button_ID = MachinePars_ToPLC.dicMachinePars_Bools[19].Alias;
            Non_materialInfo = Filter_formParameters(button_ID, Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("AlüminyumLevha", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = button_ID;

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(6);
            b_Non_materialInfo = true;
        }
        private void roundedButton_3_Click(object sender, EventArgs e)
        {
            button_ID = MachinePars_ToPLC.dicMachinePars_Bools[20].Alias;
            Non_materialInfo = Filter_formParameters(button_ID, Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("AlüminyumLevha", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = button_ID;

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_4.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(7);
            b_Non_materialInfo = true;
        }
        private void roundedButton_4_Click(object sender, EventArgs e)
        {
            button_ID = MachinePars_ToPLC.dicMachinePars_Bools[21].Alias;
            Non_materialInfo = Filter_formParameters(button_ID, Non_materialInfo, recipeNames, "a");
            //Non_materialInfo_add = Filter_formParameters("AlüminyumLevha", Non_materialInfo_add, recipeNames);
            Non_materialInfo_add = button_ID;

            //buton renk ayarları
            btn_Bakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_Aluminyum.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaBakir.BackColor = Color.FromArgb(64, 64, 64);
            btn_LevhaAluminyum.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_1.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_2.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_3.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_4.BackColor = Color.FromArgb(131, 175, 155);

            list_token.Add(8);
            b_Non_materialInfo = true;
        }
        #endregion

        #endregion

        #region \\\\\\\\\\\\\\\    FORM YÜKSEKLİĞİ BUTONLARI    ///////////////
        private void btn_11600_Click(object sender, EventArgs e)
        {
            formHeight = Filter_formParameters("L1L2", formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("11600", formHeight_add, Non_materialInfo_add);
            formHeight_add = "L1L2";

            //buton renk ayarları

            btn_11600.BackColor = Color.FromArgb(131, 175, 155);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(9); //5
            b_formHeight = true;
        }

        private void btn_16500_Click(object sender, EventArgs e)
        {
            formHeight = Filter_formParameters("L3N", formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("16500", formHeight_add, Non_materialInfo_add);
            formHeight_add = "L3N";

            //buton renk ayarları
            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(131, 175, 155);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(10);
            b_formHeight = true;
        }

        private void btn_31200_Click(object sender, EventArgs e)
        {
            formHeight = Filter_formParameters("PE", formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("31386", formHeight_add, Non_materialInfo_add);
            formHeight_add = "PE";

            //buton renk ayarları
            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(131, 175, 155);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(11);
            b_formHeight = true;
        }

        private void btn_35000_Click(object sender, EventArgs e)
        {
            formHeight = Filter_formParameters("CPE", formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("35000", formHeight_add, Non_materialInfo_add);
            formHeight_add = "CPE";

            //buton renk ayarları
            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(131, 175, 155);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(12);
            b_formHeight = true;
        }

        #region ///////////     RESERVE BUTTONS     \\\\\\\\\\\\\
        private string button_ID_Height;
        private void roundedButton_5_Click(object sender, EventArgs e)
        {
            button_ID_Height = MachinePars_ToPLC.dicMachinePars_Bools[22].Alias;
            formHeight = Filter_formParameters(button_ID_Height, formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("11600", formHeight_add, Non_materialInfo_add);
            formHeight_add = button_ID_Height;

            //buton renk ayarları

            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(13);
            b_formHeight = true;
        }

        private void roundedButton_6_Click(object sender, EventArgs e)
        {
            button_ID_Height = MachinePars_ToPLC.dicMachinePars_Bools[23].Alias;
            formHeight = Filter_formParameters(button_ID_Height, formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("11600", formHeight_add, Non_materialInfo_add);
            formHeight_add = button_ID_Height;

            //buton renk ayarları

            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(14);
            b_formHeight = true;
        }

        private void roundedButton_7_Click(object sender, EventArgs e)
        {
            button_ID_Height = MachinePars_ToPLC.dicMachinePars_Bools[24].Alias;
            formHeight = Filter_formParameters(button_ID_Height, formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("11600", formHeight_add, Non_materialInfo_add);
            formHeight_add = button_ID_Height;

            //buton renk ayarları

            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_8.BackColor = Color.FromArgb(64, 64, 64);

            list_token.Add(15);
            b_formHeight = true;
        }

        private void roundedButton_8_Click(object sender, EventArgs e)
        {
            button_ID_Height = MachinePars_ToPLC.dicMachinePars_Bools[25].Alias;
            formHeight = Filter_formParameters(button_ID_Height, formHeight, Non_materialInfo, "b");
            //formHeight_add = Filter_formParameters("11600", formHeight_add, Non_materialInfo_add);
            formHeight_add = button_ID_Height;

            //buton renk ayarları

            btn_11600.BackColor = Color.FromArgb(64, 64, 64);
            btn_16500.BackColor = Color.FromArgb(64, 64, 64);
            btn_31200.BackColor = Color.FromArgb(64, 64, 64);
            btn_35000.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_5.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_6.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_7.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_8.BackColor = Color.FromArgb(131, 175, 155);

            list_token.Add(16);
            b_formHeight = true;
        }
        #endregion

        #endregion

        #region \\\\\\\\\\\\\\\    FORM GENİŞLİĞİ COMBO_BOX    ///////////////
        public static string _formWidth;
        private static List<string> list_cb_formGenis = new List<string>();
        private void cb_formGenis_SelectedIndexChanged(object sender, EventArgs e)  //FORM GENİŞLİĞİ
        {
            if (cb_formGenis.SelectedIndex != -1)
            {
                if (b_Non_materialInfo == true && b_formHeight == true)
                {
                    list_token.Add(17);
                }
                _formWidth = cb_formGenis.SelectedItem.ToString();
                formWidth = Filter_formParameters(_formWidth + "mm", formWidth, formHeight, "c");
                //formWidth_add = Filter_formParameters(_formWidth + "mm", formWidth_add, formHeight_add);
                formWidth_add = (_formWidth + "mm");

                cb_formGenis.BackColor = Color.FromArgb(131, 175, 155);

                //richTextBox2.ResetText();
                //for (int i = 0; i < formWidth.Count; i++)
                //{
                //    richTextBox2.AppendText(formWidth[i] + "\n");
                //}

                b_formWidth = true;
            }
        }
        #endregion
        ListViewItem _listViewItem;
        #region \\\\\\\\\\\\\\\    FORM KALINLIĞI BUTONLARI    ///////////////
        private void btn_3mm_Click(object sender, EventArgs e)
        {
            formThickness = Filter_formParameters("3mm", formThickness, formWidth, "d");
            //formThickness_add = Filter_formParameters("3mm", formThickness_add, formWidth_add);
            formThickness_add = "3mm";

            //buton renk ayarları
            btn_6mm.BackColor = Color.FromArgb(64, 64, 64);
            btn_3mm.BackColor = Color.FromArgb(131, 175, 155);

            roundedButton_9.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_10.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_11.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

            foreach (var item in formThickness)
            {
                _listViewItem = new ListViewItem(item);
                _listViewItem.SubItems.Add(item);
                //listView1.Items.Add(item);
                listView1.Items.Add(_listViewItem);
            }

            list_token.Add(18);
            b_formThickness = true;
        }

        private void btn_6mm_Click(object sender, EventArgs e)
        {
            formThickness = Filter_formParameters("6mm", formThickness, formWidth, "d");
            //formThickness_add = Filter_formParameters("6mm", formThickness_add, formWidth_add);
            formThickness_add = "6mm";

            //buton renk ayarları
            btn_6mm.BackColor = Color.FromArgb(131, 175, 155);
            btn_3mm.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_9.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_10.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_11.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

            foreach (var item in formThickness)
            {
                _listViewItem = new ListViewItem(item);
                _listViewItem.SubItems.Add(item);
                listView1.Items.Add(_listViewItem);
                //listView1.Items.Add(item);
            }

            list_token.Add(19);
            b_formThickness = true;
        }

        #region ///////////     RESERVE BUTTONS     \\\\\\\\\\\\\
        private string button_ID_Thickness;
        private void roundedButton_9_Click(object sender, EventArgs e)
        {
            button_ID_Thickness = MachinePars_ToPLC.dicMachinePars_Bools[26].Alias;
            formThickness = Filter_formParameters(button_ID_Thickness, formThickness, formWidth, "d");
            //formThickness_add = Filter_formParameters("6mm", formThickness_add, formWidth_add);
            formThickness_add = button_ID_Thickness;

            btn_6mm.BackColor = Color.FromArgb(64, 64, 64);
            btn_3mm.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_9.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_10.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_11.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

            foreach (var item in formThickness)
            {
                _listViewItem = new ListViewItem(item);
                _listViewItem.SubItems.Add(item);
                listView1.Items.Add(_listViewItem);
                //listView1.Items.Add(item);
            }

            list_token.Add(20);
            b_formThickness = true;

        }
        private void roundedButton_10_Click(object sender, EventArgs e)
        {
            button_ID_Thickness = MachinePars_ToPLC.dicMachinePars_Bools[27].Alias;
            formThickness = Filter_formParameters(button_ID_Thickness, formThickness, formWidth, "d");
            //formThickness_add = Filter_formParameters("6mm", formThickness_add, formWidth_add);
            formThickness_add = button_ID_Thickness;

            btn_6mm.BackColor = Color.FromArgb(64, 64, 64);
            btn_3mm.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_9.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_10.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_11.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

            foreach (var item in formThickness)
            {
                _listViewItem = new ListViewItem(item);
                _listViewItem.SubItems.Add(item);
                listView1.Items.Add(_listViewItem);
                //listView1.Items.Add(item);
            }

            list_token.Add(21);
            b_formThickness = true;
        }

        private void roundedButton_11_Click(object sender, EventArgs e)
        {
            button_ID_Thickness = MachinePars_ToPLC.dicMachinePars_Bools[28].Alias;
            formThickness = Filter_formParameters(button_ID_Thickness, formThickness, formWidth, "d");
            //formThickness_add = Filter_formParameters("6mm", formThickness_add, formWidth_add);
            formThickness_add = button_ID_Thickness;

            btn_6mm.BackColor = Color.FromArgb(64, 64, 64);
            btn_3mm.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_9.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_10.BackColor =Color.FromArgb(64, 64, 64);
            roundedButton_11.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

            foreach (var item in formThickness)
            {
                _listViewItem = new ListViewItem(item);
                _listViewItem.SubItems.Add(item);
                listView1.Items.Add(_listViewItem);
                //listView1.Items.Add(item);
            }

            list_token.Add(22);
            b_formThickness = true;
        }

        private void roundedButton_12_Click(object sender, EventArgs e)
        {
            button_ID_Thickness = MachinePars_ToPLC.dicMachinePars_Bools[29].Alias;
            formThickness = Filter_formParameters(button_ID_Thickness, formThickness, formWidth, "d");
            //formThickness_add = Filter_formParameters("6mm", formThickness_add, formWidth_add);
            formThickness_add = button_ID_Thickness;

            btn_6mm.BackColor = Color.FromArgb(64, 64, 64);
            btn_3mm.BackColor = Color.FromArgb(64, 64, 64);

            roundedButton_9.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_10.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_11.BackColor = Color.FromArgb(64, 64, 64);
            roundedButton_12.BackColor = Color.FromArgb(131, 175, 155);

            foreach (var item in formThickness)
            {
                _listViewItem = new ListViewItem(item);
                _listViewItem.SubItems.Add(item);
                listView1.Items.Add(_listViewItem);
                //listView1.Items.Add(item);
            }

            list_token.Add(23);
            b_formThickness = true;
        }
        #endregion
        #endregion

        #region \\\\\\\\\\\\\\\    FİLTRELEME İŞLEMLERİ    ///////////////
        public List<string> Filter_formParameters(string button_ID, List<string> parameterName, List<string> recipeName, string info)
        {
            parameterName.Clear();
            foreach (var item in recipeName)
            {
                string item_first = item.Split('_').First();                // _ dan önce
                string item_last = item.Substring(item_first.Length + 1);   //_ dan sonra
                if (info.Equals("a"))
                {
                    if (item_first.Equals(button_ID))
                    {
                        parameterName.Add(item);
                    }
                }

                if (info.Equals("b"))
                {
                    string item_last_1 = item_last.Split('_').First();
                    string item_last_b = item_last.Substring(item_last_1.Length + 1);
                    if (item_last_1.Equals(button_ID))
                    {
                        parameterName.Add(item);
                    }
                }

                if (info.Equals("c"))
                {
                    string item_last_1 = item_last.Split('_').First();
                    string item_last_b = item_last.Substring(item_last_1.Length + 1);

                    string item_last_c1 = item_last_b.Split('_').First();
                    string item_last_c = item_last_b.Substring(item_last_c1.Length + 1);
                    if (item_last_c1.Equals(button_ID))
                    {
                        parameterName.Add(item);
                    }
                }

                if (info.Equals("d"))
                {
                    string item_last_1 = item_last.Split('_').First();
                    string item_last_b = item_last.Substring(item_last_1.Length + 1);

                    string item_last_c1 = item_last_b.Split('_').First();
                    string item_last_c = item_last_b.Substring(item_last_c1.Length + 1);

                    string item_last_d1 = item_last_c.Split('_').First();
                    string item_last_d = item_last_c.Substring(item_last_d1.Length + 1);

                    if (item_last_d1.Equals(button_ID))
                    {
                        parameterName.Add(item);
                    }
                }
            }

            if (info.Equals("a"))
            {
                btn_11600.BackColor = Color.FromArgb(64,64,64);         //Color.FromArgb(42, 100, 65);
                btn_16500.BackColor = Color.FromArgb(64,64,64);  
                btn_31200.BackColor = Color.FromArgb(64,64,64);  
                btn_35000.BackColor = Color.FromArgb(64, 64, 64);

                roundedButton_5.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_6.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_7.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_8.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_9.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_10.BackColor =Color.FromArgb(64,64,64);  
                roundedButton_11.BackColor =Color.FromArgb(64,64,64);  
                roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

                cb_formGenis.BackColor = Color.FromArgb(64, 64, 64);
                cb_formGenis.SelectedIndex = -1;

                btn_3mm.BackColor = Color.FromArgb(64,64,64);  
                btn_6mm.BackColor = Color.FromArgb(64, 64, 64);

                formHeight.Clear();
                formWidth.Clear();
                formThickness.Clear();
                listView1.Items.Clear();

                formHeight_add = null;
                formWidth_add = null;
                formThickness_add = null;
            }
            if (info.Equals("b"))
            {
                cb_formGenis.BackColor = Color.FromArgb(64, 64, 64);
                cb_formGenis.SelectedIndex = -1;

                btn_3mm.BackColor = Color.FromArgb(64,64,64);  
                btn_6mm.BackColor = Color.FromArgb(64, 64, 64);

                roundedButton_9.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_10.BackColor =Color.FromArgb(64,64,64);  
                roundedButton_11.BackColor =Color.FromArgb(64,64,64);  
                roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

                formWidth.Clear();
                formThickness.Clear();
                listView1.Items.Clear();

                formWidth_add = null;
                formThickness_add = null;
            }
            if (info.Equals("c"))
            {
                btn_3mm.BackColor = Color.FromArgb(64,64,64);  
                btn_6mm.BackColor = Color.FromArgb(64, 64, 64);

                roundedButton_9.BackColor = Color.FromArgb(64,64,64);  
                roundedButton_10.BackColor =Color.FromArgb(64,64,64);  
                roundedButton_11.BackColor =Color.FromArgb(64,64,64);  
                roundedButton_12.BackColor = Color.FromArgb(64, 64, 64);

                formThickness.Clear();
                listView1.Items.Clear();

                formThickness_add = null;
            }
            if (info.Equals("d"))
            {
                listView1.Items.Clear();
            }

            return parameterName;
        }
        #endregion

        public static List<string> addButtonList = new List<string>();

        public static string sNon_materialInfo_1, sformHeight_1, sformWidth_1, sformThickness_1, s_userEntry, resultOfSelectedRecipe_SaveAs;



        public static bool resultOfSelectedRecipe_SaveAs_iptal = false;

        #region \\\\\\\\\\\\\\\    FARKLI KAYDET FİLTRELEME    ///////////////
        public string Filter_saveAsParemeters(string _resultOfSelectedRecipe)
        {   //Alüminyum_16500_25mm_6mm_17
            try
            {
                if (_resultOfSelectedRecipe != null || _list_token_token.Count != 0 || resultOfSelectedRecipe_SaveAs_iptal == true)
                {
                    sNon_materialInfo_1 = _resultOfSelectedRecipe.Split('_')[0]; //Alüminyum
                                                                                 //string sNon_materialInfo_2 = _resultOfSelectedRecipe.Split('_')[1];       //16500_25mm_6mm_1

                    sformHeight_1 = _resultOfSelectedRecipe.Split('_')[1];                      //16500
                                                                                                //string sformHeight_2 = _resultOfSelectedRecipe.Split('_')[4];             //25mm_6mm_1

                    sformWidth_1 = _resultOfSelectedRecipe.Split('_')[2];                       //25mm
                                                                                                //string sformWidth_2 = sformHeight_2.Split('_')[1];                        //6mm_1

                    sformThickness_1 = _resultOfSelectedRecipe.Split('_')[3];                   //6mm
                    if (_list_token_token.Count != 0)
                    {
                        _list_token = _list_token_token;
                    }
                    foreach (var item in _list_token.ToList())
                    {
                        switch (item)
                        {
                            case 1:
                                btn_Bakir.BackColor = Color.SteelBlue;
                                btn_Aluminyum.BackColor = Color.SlateGray;
                                btn_LevhaBakir.BackColor = Color.SlateGray;
                                btn_LevhaAluminyum.BackColor = Color.SlateGray;

                                //btn_Bakir.Enabled = false;
                                //btn_Aluminyum.Enabled = false;
                                //btn_LevhaBakir.Enabled = false;
                                //btn_LevhaAluminyum.Enabled = false;

                                _list_token_token.Add(1);

                                break;
                            case 2:
                                btn_Bakir.BackColor = Color.SlateGray;
                                btn_Aluminyum.BackColor = Color.SteelBlue;
                                btn_LevhaBakir.BackColor = Color.SlateGray;
                                btn_LevhaAluminyum.BackColor = Color.SlateGray;

                                //btn_Bakir.Enabled = false;
                                //btn_Aluminyum.Enabled = false;
                                //btn_LevhaBakir.Enabled = false;
                                //btn_LevhaAluminyum.Enabled = false;
                                _list_token_token.Add(2);
                                break;
                            case 3:
                                btn_Bakir.BackColor = Color.SlateGray;
                                btn_Aluminyum.BackColor = Color.SlateGray;
                                btn_LevhaBakir.BackColor = Color.SteelBlue;
                                btn_LevhaAluminyum.BackColor = Color.SlateGray;

                                //btn_Bakir.Enabled = false;
                                //btn_Aluminyum.Enabled = false;
                                //btn_LevhaBakir.Enabled = false;
                                //btn_LevhaAluminyum.Enabled = false;
                                _list_token_token.Add(3);
                                break;
                            case 4:
                                btn_Bakir.BackColor = Color.SlateGray;
                                btn_Aluminyum.BackColor = Color.SlateGray;
                                btn_LevhaBakir.BackColor = Color.SlateGray;
                                btn_LevhaAluminyum.BackColor = Color.SteelBlue;

                                //btn_Bakir.Enabled = false;
                                //btn_Aluminyum.Enabled = false;
                                //btn_LevhaBakir.Enabled = false;
                                //btn_LevhaAluminyum.Enabled = false;
                                _list_token_token.Add(4);
                                break;
                            case 5:
                                btn_11600.BackColor = Color.SteelBlue;
                                btn_16500.BackColor = Color.SlateGray;
                                btn_31200.BackColor = Color.SlateGray;
                                btn_35000.BackColor = Color.SlateGray;

                                //btn_11600.Enabled = false;
                                //btn_16500.Enabled = false;
                                //btn_31200.Enabled = false;
                                //btn_35000.Enabled = false;
                                _list_token_token.Add(5);
                                break;
                            case 6:
                                btn_11600.BackColor = Color.SlateGray;
                                btn_16500.BackColor = Color.SteelBlue;
                                btn_31200.BackColor = Color.SlateGray;
                                btn_35000.BackColor = Color.SlateGray;

                                //btn_11600.Enabled = false;
                                //btn_16500.Enabled = false;
                                //btn_31200.Enabled = false;
                                //btn_35000.Enabled = false;
                                _list_token_token.Add(6);
                                break;
                            case 7:
                                btn_11600.BackColor = Color.SlateGray;
                                btn_16500.BackColor = Color.SlateGray;
                                btn_31200.BackColor = Color.SteelBlue;
                                btn_35000.BackColor = Color.SlateGray;

                                //btn_11600.Enabled = false;
                                //btn_16500.Enabled = false;
                                //btn_31200.Enabled = false;
                                //btn_35000.Enabled = false;
                                _list_token_token.Add(7);
                                break;
                            case 8:
                                btn_11600.BackColor = Color.SlateGray;
                                btn_16500.BackColor = Color.SlateGray;
                                btn_31200.BackColor = Color.SlateGray;
                                btn_35000.BackColor = Color.SteelBlue;

                                //btn_11600.Enabled = false;
                                //btn_16500.Enabled = false;
                                //btn_31200.Enabled = false;
                                //btn_35000.Enabled = false;
                                _list_token_token.Add(8);
                                break;
                            case 9:
                                int x;
                                x = cb_formGenis.FindString(_formWidth);
                                cb_formGenis.SelectedIndex = x;
                                //cb_formGenis.Enabled = false;
                                _list_token_token.Add(9);
                                break;
                            case 10:
                                btn_3mm.BackColor = Color.SteelBlue;
                                btn_6mm.BackColor = Color.SlateGray;

                                //recipeSelection.btn_3mm.Enabled = false;
                                //recipeSelection.btn_6mm.Enabled = false;
                                _list_token_token.Add(10);
                                break;
                            case 11:
                                btn_3mm.BackColor = Color.SlateGray;
                                btn_6mm.BackColor = Color.SteelBlue;

                                //recipeSelection.btn_3mm.Enabled = false;
                                //recipeSelection.btn_6mm.Enabled = false;
                                _list_token_token.Add(11);
                                break;
                            //_formWidth direkt form genişliğini veriyor
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {

                ;
            }

            _resultOfSelectedRecipe = sNon_materialInfo_1 + "_" + sformHeight_1 + "_" + sformWidth_1 + "_" + sformThickness_1 + "_";
            return _resultOfSelectedRecipe;

        }
        #endregion

        /*DENEME!!!
        #region LİSTE İÇİN REÇETE PARAMETRELERİNİ AYIRIR (filter_formParameters() methodu ile)
        public List<string> Filter_formParameters(string button_ID, List<string> parameterName, List<string> recipeName)
        {
            parameterName.Clear();

            foreach (var item in recipeName)
            {
                string item_first = item.Split('_').First();

                if (item_first.Contains("mm"))
                {
                    item_first = item.Remove(item_first.Length - 2);
                    if (item_first.Equals(button_ID))
                    {
                        parameterName.Add(item.Substring(item_first.Length + 3));
                    }
                }
                else
                {
                    if (item_first.Equals(button_ID))
                    {
                        parameterName.Add(item.Substring(item_first.Length + 1));
                    }
                }
            }
            return parameterName;
        }
        #endregion*/

        private void cb_formListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.HotTracking = false;
            //this form
            listView1.Columns.Add("", 1);
            listView1.Columns.Add("Seçilebilecek Reçeteler", listView1.Width - 1, HorizontalAlignment.Left);
            //listView1.FullRowSelect = true;

            //ColumnHeader cHeader = new ColumnHeader();
            //cHeader.Text = "Seçilebilecek Reçeteler";
            //cHeader.Name = "cName";
            //cHeader.Width = listView1.Width;
            //listView1.Columns.Add(cHeader);

        }

        private void btn_Iptal_Click(object sender, EventArgs e)
        {
            resultOfSelectedRecipe_add = "İptal Edildi";

            if (label_text.Text == "Reçete Farklı Kaydet".ToUpper())
            {
                resultOfSelectedRecipe_SaveAs_iptal = true;
            }
            else
            {
                resultOfSelectedRecipe = null;
            }
            this.Dispose();
        }

        private void tb_userEntry_TextChanged(object sender, EventArgs e)
        {

            string text = recipeSelection.tb_userEntry.Text;
            if (recipeSelection.tb_userEntry.TextLength > 0)
            {
                if (String.IsNullOrEmpty(text) || text.Contains(".") || text.Contains(" ") || text.Any(ch => !Char.IsLetterOrDigit(ch)))
                {
                    if (text.Contains("."))
                    {
                        text = text.Remove(text.LastIndexOf("."));
                    }
                    if (text.Contains(" "))
                    {
                        text = text.Remove(text.LastIndexOf(" "));
                    }
                    if (text.Any(ch => !Char.IsLetterOrDigit(ch)))
                    {
                        text = text.Remove(text.Length - 1);
                    }
                    recipeSelection.tb_userEntry.Text = text;
                    MyMessageBox.ShowMessageBox("Girilen text boşluk,nokta ve özel karakter içeremez.");
                }
                else
                {
                    userEntry = recipeSelection.tb_userEntry.Text;
                }
            }
            else
            {
                userEntry = null;
            }

        }

        private void tb_userEntry_MouseUp(object sender, MouseEventArgs e)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                if (Wow64DisableWow64FsRedirection(ref wow64Value))
                {
                    process_ScreenKeyboard.StartInfo.FileName = "osk.exe";//Filename
                    process_ScreenKeyboard.Start();
                    Wow64EnableWow64FsRedirection(wow64Value);
                }
            }
            else
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            if (Non_materialInfo_add != null && formHeight_add != null && formWidth_add != null && formThickness_add != null &&
                listView1.SelectedItems.Count > 0 && b_ShowSelection_For_Machine == true)
            {
                b_ShowSelection_For_Machine = false;
                this.Dispose();

            }
            else if (Non_materialInfo_add != null && formHeight_add != null && formWidth_add != null && formThickness_add != null &&
                listView1.SelectedItems.Count > 0 && b_ShowSelection == true)
            {
                _list_token = list_token;
                b_ShowSelection = false;
                this.Dispose();
            }
            else if (Non_materialInfo_add != null && formHeight_add != null && formWidth_add != null && formThickness_add != null &&
                userEntry != null && b_AddRecipe == true)
            {
                resultOfSelectedRecipe_add = Non_materialInfo_add + "_" + formHeight_add + "_" + formWidth_add + "_" + formThickness_add + "_" + userEntry;
                b_AddRecipe = false;
                this.Dispose();
            }
            else if (sNon_materialInfo_1 != null && sformHeight_1 != null && sformWidth_1 != null && sformThickness_1 != null && userEntry != null && b_SaveAsRecipe == true)
            {
                resultOfSelectedRecipe_add = sNon_materialInfo_1 + "_" + sformHeight_1 + "_" + sformWidth_1 + "_" + sformThickness_1 + "_" + userEntry;
                b_SaveAsRecipe = false;
                this.Dispose();
            }
            else if (Non_materialInfo_add == null || formHeight_add == null || formWidth_add == null || formThickness_add == null ||
                b_ShowSelection_For_Machine == false || userEntry == null || b_ShowSelection == false || b_AddRecipe == false || b_SaveAsRecipe == false)
            {
                if (userEntry == null || b_SaveAsRecipe == true || b_AddRecipe == true || b_ShowSelection == true || b_ShowSelection_For_Machine == true)
                {
                    resultOfSelectedRecipe_add = null;
                    MyMessageBox.ShowMessageBox("Reçete bilgilerini eksiksiz giriniz!");
                }
            }
            else
            {
                this.Dispose();
            }
            resultOfSelectedRecipe = fooOfSelectedRecipe;
            s_userEntry = tb_userEntry.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fooListViewChanged.EventFired();
            if (listView1.SelectedItems.Count > 0)
            {
                fooOfSelectedRecipe = listView1.SelectedItems[0].Text;

            }
            else
            {
                ;
            }
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Consolas", 16, FontStyle.Bold))
                {
                    Color myColor = Color.FromArgb(118, 93, 105);
                    SolidBrush myBrush = new SolidBrush(myColor);

                    e.Graphics.FillRectangle(myBrush, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.WhiteSmoke, e.Bounds, sf);
                }
            }
        }

        private void listView1_DrawItem_1(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                Color myColor = Color.FromArgb(131, 175, 155);
                SolidBrush myBrush = new SolidBrush(myColor);
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(myBrush, e.Bounds);
                e.DrawFocusRectangle();
            }
        }
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = listView1.GetItemAt(0, e.Y);
            if (clickedItem != null)
            {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
            }
        }

        private void btn_AddButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            AddButton.Filter_formParameters();
        }

        private void btn_DeleteButton_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            DeleteButton.Filter_formParameters();
        }

        #region ///////////////////////       KLAVYE        \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        const string Kernel32dll = "Kernel32.Dll";
        [DllImport(Kernel32dll, EntryPoint = "Wow64DisableWow64FsRedirection")]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

        [DllImport(Kernel32dll, EntryPoint = "Wow64EnableWow64FsRedirection")]
        public static extern bool Wow64EnableWow64FsRedirection(IntPtr ptr);

        IntPtr wow64Value;

        Process process_ScreenKeyboard = new Process();
        #endregion


    }
}