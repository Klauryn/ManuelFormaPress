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

namespace Csharp.RecipePars
{
    public partial class AddRecipe : Form
    {
        public AddRecipe()
        {
            InitializeComponent();
            tb_Entry.Text = "Reçete ismi giriniz...";
        }
        private eUpdate_RecipeList fooUpdateRecipes;
        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if(tb_Entry.Text=="" || tb_Entry.Text==null || tb_Entry.Text == "Reçete ismi giriniz...")
            {
                MyMessageBox.ShowMessageBox("Reçete ismi boş bırakılamaz!");
            }
            else
            {
                if (tb_Entry.Text.Contains("."))
                {
                    MyMessageBox.ShowMessageBox("Reçete ismi nokta içeremez!");
                }
                else
                {
                    int offeredRecipeId = RecipePars_ToPLC.offer_RecipeId();
                    System.IO.File.Copy(System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//RecipeParameters_Empty.xml",
                        System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//" + tb_Entry.Text + "_" + offeredRecipeId.ToString() + ".xml");
                    MyMessageBox.ShowMessageBox(tb_Entry.Text.ToString() + " isimli reçete başarıyla eklendi");
                    fooUpdateRecipes = new eUpdate_RecipeList();
                    fooUpdateRecipes.EventFired();
                    process_ScreenKeyboard.Close();
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


        const string Kernel32dll = "Kernel32.Dll";
        [DllImport(Kernel32dll, EntryPoint = "Wow64DisableWow64FsRedirection")]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

        [DllImport(Kernel32dll, EntryPoint = "Wow64EnableWow64FsRedirection")]
        public static extern bool Wow64EnableWow64FsRedirection(IntPtr ptr);

        IntPtr wow64Value;

        Process process_ScreenKeyboard = new Process();
        private void tb_Entry_Click(object sender, EventArgs e)
        {
            tb_Entry.Text = null;
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
}
