using Csharp.Pages.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Csharp.Pages.RecipePars;
using Csharp.EventsAggregator;
using Csharp.Pages.MachinePars;
using System.Runtime.InteropServices.ComTypes;

namespace Csharp.RecipePars
{
    public partial class AddButton : Form
    {

        private eMachineParameterChanged foo_eMachineParameter;
        public AddButton()
        {
            InitializeComponent();
            tb_Entry.Text = "Tip ismi giriniz...";
            foo_eMachineParameter = new eMachineParameterChanged();
        }
        private eUpdate_RecipeList fooUpdateRecipes;
        private static AddButton addButton;
        public static List<string> addButtonList = new List<string>();
        RecipeSelection recipeSelection;
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if (tb_Entry.Text == "" || tb_Entry.Text == null || tb_Entry.Text == "Tip ismi giriniz...")
            {
                MyMessageBox.ShowMessageBox("Tip ismi boş bırakılamaz!");
            }
            else if (info == "" || info == null)
            {
                MyMessageBox.ShowMessageBox("Tip seçiniz!");
            }
            else
            {
                if (tb_Entry.Text.Contains("."))
                {
                    MyMessageBox.ShowMessageBox("Tip ismi nokta içeremez!");
                }
                else
                {
                    process_ScreenKeyboard.Close();
                    addButtonList.Clear();
                    if (info != "c")
                    {
                        if (info != null && info != "")
                        {
                            MachinePars_ToPLC.dicMachinePars_Bools[lastIndex].Alias = tb_Entry.Text;
                            MachinePars_ToPLC.dicMachinePars_Bools[lastIndex].Value = true;

                            foreach (var item in MachinePars_ToPLC.dicMachinePars_Bools)
                            {
                                MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Bools"].Rows[item.Key]["Value"] = MachinePars_ToPLC.dicMachinePars_Bools[item.Key].Value;
                                MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Bools"].Rows[item.Key]["Alias"] = MachinePars_ToPLC.dicMachinePars_Bools[item.Key].Alias;
                            }
                            MachinePars_ToPLC.ds_machinePars.WriteXml(filename);

                            addButtonList.Add(info);
                            addButtonList.Add(tb_Entry.Text);
                            MyMessageBox.ShowMessageBox("Yeni tip başarıyla eklendi!");
                        }
                    }
                    else
                    {
                        if (info != null && info != "")
                        {
                            recipeSelection = new RecipeSelection();
                            for (int i = 31; i <= 63; i++)
                            {
                                if (/*MachinePars_ToPLC.dicMachinePars_Nums[i].Alias == tb_Entry.Text || */recipeSelection.cb_formGenis.Items.Contains(tb_Entry.Text))
                                {
                                    MyMessageBox.ShowMessageBox("Bu tip daha önce eklenmiştir. \nLütfen daha farklı bir değer giriniz!");
                                    return;
                                }
                                else
                                {
                                    MachinePars_ToPLC.dicMachinePars_Nums[lastIndex].Item1.Alias = tb_Entry.Text;
                                    MachinePars_ToPLC.dicMachinePars_Nums[lastIndex].Item1.Value = 1;

                                    foreach (var item in MachinePars_ToPLC.dicMachinePars_Nums)
                                    {
                                        MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Nums"].Rows[item.Key]["Value"] = MachinePars_ToPLC.dicMachinePars_Nums[item.Key].Item1.Value;
                                        MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Nums"].Rows[item.Key]["Alias"] = MachinePars_ToPLC.dicMachinePars_Nums[item.Key].Item1.Alias;
                                    }
                                    MachinePars_ToPLC.ds_machinePars.WriteXml(filename);
                                    addButtonList.Add(info);
                                    addButtonList.Add(tb_Entry.Text);
                                    MyMessageBox.ShowMessageBox("Yeni tip başarıyla eklendi!");
                                    return;
                                }
                                
                            }
                            

                        }
                    }

                    this.Close();
                    this.Dispose();
                }
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
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

        private void tb_Entry_Click(object sender, EventArgs e)
        {
            tb_Entry.Text = null;
            if (info == "c" || info == "d")
            {

                //NumPad ekrana sığmaz ise sığdıralım.
                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                int MouseXPos = MousePosition.X - 100;
                int MouseYPos = MousePosition.Y + 25;
                while (MouseXPos > resolution.Width - 382)
                {
                    MouseXPos = MouseXPos - 1;
                }
                while (MouseYPos > resolution.Height - 335)
                {
                    MouseYPos = MouseYPos - 1;
                }
                double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
                if (dNumPadResult != 999999)
                {
                    tb_Entry.Text = dNumPadResult.ToString();
                }
            }
            else
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

        }
        private string info;
        private int lastIndex;
        string filename = System.Threading.Thread.GetDomain().BaseDirectory + "//MachineParameters.xml";
        private void btn_malzemeInfo_Click(object sender, EventArgs e)
        {
            btn_malzemeInfo.BackColor = Color.FromArgb(42, 100, 65);
            btn_formHight.BackColor = Color.FromArgb(131, 175, 155);
            btn_formWidth.BackColor = Color.FromArgb(131, 175, 155);
            btn_formThickness.BackColor = Color.FromArgb(131, 175, 155);

            info = "a";
            for (int i = 18; i <= 21; i++)
            {
                lastIndex = 0;
                if (!MachinePars_ToPLC.dicMachinePars_Bools[i].Value)
                {
                    lastIndex = i;
                    return;
                }
            }
        }
        private void btn_formHight_Click(object sender, EventArgs e)
        {
            btn_malzemeInfo.BackColor = Color.FromArgb(131, 175, 155);
            btn_formHight.BackColor = Color.FromArgb(42, 100, 65);
            btn_formWidth.BackColor = Color.FromArgb(131, 175, 155);
            btn_formThickness.BackColor = Color.FromArgb(131, 175, 155);
            info = "b";
            for (int i = 22; i <= 25; i++)
            {
                lastIndex = 0;
                if (!MachinePars_ToPLC.dicMachinePars_Bools[i].Value)
                {
                    lastIndex = i;
                    return;
                }
            }
        }
        private void btn_formWidth_Click(object sender, EventArgs e)
        {
            btn_malzemeInfo.BackColor = Color.FromArgb(131, 175, 155);
            btn_formHight.BackColor = Color.FromArgb(131, 175, 155);
            btn_formWidth.BackColor = Color.FromArgb(42, 100, 65);
            btn_formThickness.BackColor = Color.FromArgb(131, 175, 155);
            info = "c";
            for (int i = 31; i <= 63; i++)
            {
                lastIndex = 0;
                if (MachinePars_ToPLC.dicMachinePars_Nums[i].Item1.Value == 0)
                {
                    lastIndex = i;
                    return;
                }
            }
        }
        private void btn_formThickness_Click(object sender, EventArgs e)
        {
            btn_malzemeInfo.BackColor = Color.FromArgb(131, 175, 155);
            btn_formHight.BackColor = Color.FromArgb(131, 175, 155);
            btn_formWidth.BackColor = Color.FromArgb(131, 175, 155);
            btn_formThickness.BackColor = Color.FromArgb(42, 100, 65);
            info = "d";
            for (int i = 26; i <= 29; i++)
            {
                lastIndex = 0;
                if (!MachinePars_ToPLC.dicMachinePars_Bools[i].Value)
                {
                    lastIndex = i;
                    return;
                }
            }
        }
        public static void Filter_formParameters()
        {
            addButton = new AddButton();
            addButton.ShowDialog();
        }

    }
}
