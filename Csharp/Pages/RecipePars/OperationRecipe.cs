using Csharp.EventsAggregator;
using Csharp.Pages.General;
using Csharp.Pages.RecipePars;
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

namespace Csharp.RecipePars
{
    public partial class OperationRecipe : Form
    {
        static OperationRecipe newAddRecipe;
        //static int buttonResult;
        public OperationRecipe()
        {
            InitializeComponent();
        }
        public static int ShowMessageBox(string sMsg)
        {
            //newMessageBox = new MyMessageBox();
            //newMessageBox.label_msg.Text = sMsg;
            //newMessageBox.label_tittle.Text = "Uyarı!"; // Default Title
            //newMessageBox.ShowDialog();
            //return buttonResult;
            return 1;
        }
        public static int ShowMessageBox(string sMsg, bool IsOkCancel)
        {
            //newMessageBox = new MyMessageBox();
            //newMessageBox.label_msg.Text = sMsg;
            //newMessageBox.label_tittle.Text = "Uyarı!"; // Default Title
            //newMessageBox.btn_Ok.Visible = false;
            //newMessageBox.btn_Accept.Visible = true;
            //newMessageBox.btn_Cancel.Visible = true;
            //newMessageBox.ShowDialog();
            //return buttonResult;
            return 1;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //buttonResult = 1;
            //newMessageBox.Dispose();
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            //buttonResult = 1;
            //newMessageBox.Dispose();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //buttonResult = 2;
            //newMessageBox.Dispose();
        }

        private void tb_Entry_Click(object sender, EventArgs e)
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            string osk = null;

            if (osk == null)
            {
                osk = Path.Combine(Path.Combine(windir, "sysnative"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = Path.Combine(Path.Combine(windir, "system32"), "osk.exe");
                if (!File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = "osk.exe";
            }

            Process.Start(osk);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private eUpdate_RecipeList fooUpdateRecipes;
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (staticSelectedRecipe.sName == RecipePars_ToPLC.sDisplaying_RecipeName)
            {
                MyMessageBox.ShowMessageBox("Seçili reçete silinemez!");
            }
            else
            {
                if (MyMessageBox.ShowMessageBox(RecipePars_ToPLC.sDisplaying_RecipeName + " isimli reçete silinecek! Onaylıyor musunuz?", true) == 1)
                {
                    uc_RecipeParsPage uc_recipeParsPage = new uc_RecipeParsPage();
                    System.IO.File.Delete(System.Threading.Thread.GetDomain().BaseDirectory
                        + "//RecipeParameters" + "//" + RecipePars_ToPLC.sDisplaying_RecipeName + ".xml");
                    fooUpdateRecipes = new eUpdate_RecipeList();
                    fooUpdateRecipes.EventFired();
                }
                else
                {
                    ;
                }
            }
            this.Close();
            this.Dispose();
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            /*this.Close();
            this.Dispose();*/
            /*SaveAsRecipe _saveasRecipe = new SaveAsRecipe();
            _saveasRecipe.ShowDialog();
            this.Close();
            this.Dispose();*/

            string sSelectedRecipe = RecipeSelection.SaveAsRecipeSelection(RecipePars_ToPLC.Read_Recipe_Names(), "Reçete Farklı Kaydet", "Kaydet");

            if (sSelectedRecipe != null && sSelectedRecipe != "İptal Edildi")
            {
                if (sSelectedRecipe.Contains("."))
                {
                    MyMessageBox.ShowMessageBox("Reçete ismi nokta içeremez!");
                }
                else
                {
                    int offeredRecipeId = RecipePars_ToPLC.offer_RecipeId();
                    System.IO.File.Copy(System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//" + RecipePars_ToPLC.sDisplaying_RecipeName + ".xml" /*"//RecipeParameters_Empty.xml"*/,
                        System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//" + sSelectedRecipe + "_" + offeredRecipeId.ToString() + ".xml");
                    MyMessageBox.ShowMessageBox(sSelectedRecipe + " isimli reçete başarıyla eklendi");
                    fooUpdateRecipes = new eUpdate_RecipeList();
                    fooUpdateRecipes.EventFired();
                }
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            /*this.Close();
            this.Dispose();*/
            string sSelectedRecipe = RecipeSelection.AddRecipeSelection(RecipePars_ToPLC.Read_Recipe_Names(), "Reçete Ekle", "Ekle");

            if (sSelectedRecipe != null && sSelectedRecipe != "İptal Edildi")
            {
                if (sSelectedRecipe.Contains("."))
                {
                    MyMessageBox.ShowMessageBox("Reçete ismi nokta içeremez!");
                }
                else
                {
                    int offeredRecipeId = RecipePars_ToPLC.offer_RecipeId();
                    System.IO.File.Copy(System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//RecipeParameters_Empty.xml",
                        System.Threading.Thread.GetDomain().BaseDirectory + "//RecipeParameters" + "//" + sSelectedRecipe + "_" + offeredRecipeId.ToString() + ".xml");
                    MyMessageBox.ShowMessageBox(sSelectedRecipe + " isimli reçete başarıyla eklendi");
                    fooUpdateRecipes = new eUpdate_RecipeList();
                    fooUpdateRecipes.EventFired();
                }
            }

            /*AddRecipe _addRecipe = new AddRecipe();
            _addRecipe.ShowDialog();*/
            //this.Close();
            //this.Dispose();
        }
    }
}
