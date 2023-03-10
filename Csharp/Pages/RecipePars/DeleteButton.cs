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
using CustomControls.RJControls;

namespace Csharp.RecipePars
{
    public partial class DeleteButton : Form
    {
        private string filename = System.Threading.Thread.GetDomain().BaseDirectory + "//MachineParameters.xml";
        private int lastIndex;
        private int lastIndex_Combobox;
        private static DeleteButton deleteButton;
        private eMachineParameterChanged foo_eMachineParameter; 
        
        public DeleteButton()
        {
            InitializeComponent(); 

            foo_eMachineParameter = new eMachineParameterChanged();

            roundedButton_1.Visible = false;
            roundedButton_2.Visible = false;
            roundedButton_3.Visible = false;
            roundedButton_4.Visible = false;
            roundedButton_7.Visible = false;
            roundedButton_8.Visible = false;
            roundedButton_5.Visible = false;
            roundedButton_6.Visible = false;
            roundedButton_9.Visible = false;
            roundedButton_10.Visible = false;
            roundedButton_11.Visible = false;
            roundedButton_12.Visible = false;

            cb_formGenis.Items.Clear();

            for (int i = 18; i < 29; i++)
            {
                if (MachinePars_ToPLC.dicMachinePars_Bools[i].Value)
                {
                    switch ("roundedButton_" + (i - 17))
                    {
                        case "roundedButton_1":
                            roundedButton_1.Visible = true;
                            roundedButton_1.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_2":
                            roundedButton_2.Visible = true;
                            roundedButton_2.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_3":
                            roundedButton_3.Visible = true;
                            roundedButton_3.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_4":
                            roundedButton_4.Visible = true;
                            roundedButton_4.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_5":
                            roundedButton_5.Visible = true;
                            roundedButton_5.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_6":
                            roundedButton_6.Visible = true;
                            roundedButton_6.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_7":
                            roundedButton_7.Visible = true;
                            roundedButton_7.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_8":
                            roundedButton_8.Visible = true;
                            roundedButton_9.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_9":
                            roundedButton_9.Visible = true;
                            roundedButton_9.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_10":
                            roundedButton_10.Visible = true;
                            roundedButton_10.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_11":
                            roundedButton_11.Visible = true;
                            roundedButton_11.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;
                        case "roundedButton_12":
                            roundedButton_12.Visible = true;
                            roundedButton_12.Text = MachinePars_ToPLC.dicMachinePars_Bools[i].Alias;
                            break;

                        default:
                            break;
                    }
                }
            }
            for (int i = 31; i <= 63; i++)
            {
                if (MachinePars_ToPLC.dicMachinePars_Nums[i].Item1.Value == 1)
                {
                    cb_formGenis.Items.Add(MachinePars_ToPLC.dicMachinePars_Nums[i].Item1.Alias.ToString());
                }
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lastIndex != 0)
            {
                MachinePars_ToPLC.dicMachinePars_Bools[lastIndex].Value = false;
                MachinePars_ToPLC.dicMachinePars_Bools[lastIndex].Alias = "Reserve_" + lastIndex;
                foreach (var item in MachinePars_ToPLC.dicMachinePars_Bools)
                {
                    MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Bools"].Rows[item.Key]["Value"] = MachinePars_ToPLC.dicMachinePars_Bools[item.Key].Value;
                    MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Bools"].Rows[item.Key]["Alias"] = MachinePars_ToPLC.dicMachinePars_Bools[item.Key].Alias;
                }
                MachinePars_ToPLC.ds_machinePars.WriteXml(filename);

                MyMessageBox.ShowMessageBox("Yeni tip başarıyla silindi!");
            }

            if (lastIndex_Combobox != 0)
            {
                MachinePars_ToPLC.dicMachinePars_Nums[lastIndex_Combobox].Item1.Value = 0;
                MachinePars_ToPLC.dicMachinePars_Nums[lastIndex_Combobox].Item1.Alias = "Reserve_" + lastIndex_Combobox;
                foreach (var item in MachinePars_ToPLC.dicMachinePars_Nums)
                {
                    MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Nums"].Rows[item.Key]["Value"] = MachinePars_ToPLC.dicMachinePars_Nums[item.Key].Item1.Value;
                    MachinePars_ToPLC.ds_machinePars.Tables["Machine Parameters Nums"].Rows[item.Key]["Alias"] = MachinePars_ToPLC.dicMachinePars_Nums[item.Key].Item1.Alias;
                }
                MachinePars_ToPLC.ds_machinePars.WriteXml(filename);

                MyMessageBox.ShowMessageBox("Yeni tip başarıyla silindi!");
            }
            this.Close();
            this.Dispose();

        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        public static void Filter_formParameters()
        {
            deleteButton = new DeleteButton();
            deleteButton.ShowDialog();
        }
        private void roundedButton_1_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_1.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 18;
            //MachinePars_ToPLC.dicMachinePars_Bools[18].Value = true;
        }

        private void roundedButton_2_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_2.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 19;
            //MachinePars_ToPLC.dicMachinePars_Bools[19].Value = true;
        }

        private void roundedButton_3_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_3.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 20;
            //MachinePars_ToPLC.dicMachinePars_Bools[20].Value = true;
        }

        private void roundedButton_4_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_4.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 21;
            //MachinePars_ToPLC.dicMachinePars_Bools[21].Value = true;
        }

        private void roundedButton_5_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_5.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 22;
            //MachinePars_ToPLC.dicMachinePars_Bools[22].Value = true;
        }

        private void roundedButton_6_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_6.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 23;
            //MachinePars_ToPLC.dicMachinePars_Bools[23].Value = true;
        }

        private void roundedButton_7_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_7.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 24;
            //MachinePars_ToPLC.dicMachinePars_Bools[24].Value = true;
        }

        private void roundedButton_8_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_8.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 25;
            //MachinePars_ToPLC.dicMachinePars_Bools[25].Value = true;
        }

        private void roundedButton_9_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_9.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 26;
            //MachinePars_ToPLC.dicMachinePars_Bools[26].Value = true;
        }

        private void roundedButton_10_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_10.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 27;
            //MachinePars_ToPLC.dicMachinePars_Bools[27].Value = true;
        }

        private void roundedButton_11_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_11.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 28;
            //MachinePars_ToPLC.dicMachinePars_Bools[28].Value = true;
        }

        private void roundedButton_12_Click(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            roundedButton_12.BackColor = Color.FromArgb(42, 100, 65);

            lastIndex = 29;
            //MachinePars_ToPLC.dicMachinePars_Bools[29].Value = true;
        }

        private void cb_formGenis_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonDefaultColor();
            cb_formGenis.BackColor = Color.FromArgb(42, 100, 65);

            for (int i = 31; i <= 63; i++)
            {
                if (cb_formGenis.SelectedIndex != -1)
                {
                    string selectedItem = cb_formGenis.SelectedItem.ToString();
                    if (selectedItem == MachinePars_ToPLC.dicMachinePars_Nums[i].Item1.Alias)
                    {
                        lastIndex_Combobox = i;
                    }
                }
            }
        }
        private void ButtonDefaultColor()
        {
            roundedButton_1.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_2.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_3.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_4.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_7.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_8.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_5.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_6.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_9.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_10.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_11.BackColor = Color.FromArgb(131, 175, 155);
            roundedButton_12.BackColor = Color.FromArgb(131, 175, 155);
            cb_formGenis.BackColor = Color.FromArgb(131, 175, 155);
        }
    }
}

