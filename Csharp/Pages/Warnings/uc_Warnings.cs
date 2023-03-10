using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Ios;

namespace Csharp.Pages.Warnings
{
    public partial class uc_Warnings : UserControl
    {
        public uc_Warnings()
        {
            InitializeComponent();
            flowLayoutPanel_1.Controls.Clear();
        }
        private void uc_StartCondPage_Load(object sender, EventArgs e)
        {
            DisplayWarnings();
            timer1.Enabled = true;
        }

        uc_warning Warning0 = new uc_warning("Çanak seviye az!");
        uc_warning Warning1 = new uc_warning("Warning1");
        uc_warning Warning2 = new uc_warning("Warning2");
        uc_warning Warning3 = new uc_warning("Warning3");
        uc_warning Warning4 = new uc_warning("Warning4");
        uc_warning Warning5 = new uc_warning("Warning5");
        uc_warning Warning6 = new uc_warning("Warning6");
        uc_warning Warning7 = new uc_warning("Warning7");
        uc_warning Warning8 = new uc_warning("Warning8");
        uc_warning Warning9 = new uc_warning("Warning9");
        uc_warning Warning10 = new uc_warning("Warning10");
        uc_warning Warning11 = new uc_warning("Warning11");
        uc_warning Warning12 = new uc_warning("Warning12");
        uc_warning Warning13 = new uc_warning("Warning13");
        uc_warning Warning14 = new uc_warning("Warning14");
        uc_warning Warning15 = new uc_warning("Warning15");
        uc_warning Warning16 = new uc_warning("Warning16");
        uc_warning Warning17 = new uc_warning("Warning17");
        uc_warning Warning18 = new uc_warning("Warning18");
        uc_warning Warning19 = new uc_warning("Warning19");
        uc_warning Warning20 = new uc_warning("Warning20");
        private void DisplayWarnings()
        { 
            //0
            if (IO.Bits.Is_OnWarning0 == true && flowLayoutPanel_1.Controls.Contains(Warning0)==false)
            {
                flowLayoutPanel_1.Controls.Add(Warning0);
            }
            else if(IO.Bits.Is_OnWarning0 == false) { flowLayoutPanel_1.Controls.Remove(Warning0); }
            //1
            if (IO.Bits.Is_OnWarning1 == true && flowLayoutPanel_1.Controls.Contains(Warning1) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning1);
            }
            else if (IO.Bits.Is_OnWarning1 == false) { flowLayoutPanel_1.Controls.Remove(Warning1); }
            //2
            if (IO.Bits.Is_OnWarning2 == true && flowLayoutPanel_1.Controls.Contains(Warning2) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning2);
            }
            else if (IO.Bits.Is_OnWarning2 == false) { flowLayoutPanel_1.Controls.Remove(Warning2); }
            //3
            if (IO.Bits.Is_OnWarning3 == true && flowLayoutPanel_1.Controls.Contains(Warning3) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning3);
            }
            else if (IO.Bits.Is_OnWarning3 == false) { flowLayoutPanel_1.Controls.Remove(Warning3); }
            //4
            if (IO.Bits.Is_OnWarning4 == true && flowLayoutPanel_1.Controls.Contains(Warning4) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning4);
            }
            else if (IO.Bits.Is_OnWarning4 == false) { flowLayoutPanel_1.Controls.Remove(Warning4); }
            //5
            if (IO.Bits.Is_OnWarning5 == true && flowLayoutPanel_1.Controls.Contains(Warning5) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning5);
            }
            else if (IO.Bits.Is_OnWarning5 == false) { flowLayoutPanel_1.Controls.Remove(Warning5); }
            //6
            if (IO.Bits.Is_OnWarning6 == true && flowLayoutPanel_1.Controls.Contains(Warning6) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning6);
            }
            else if (IO.Bits.Is_OnWarning6 == false) { flowLayoutPanel_1.Controls.Remove(Warning6); }
            //7
            if (IO.Bits.Is_OnWarning7 == true && flowLayoutPanel_1.Controls.Contains(Warning7) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning7);
            }
            else if (IO.Bits.Is_OnWarning7 == false) { flowLayoutPanel_1.Controls.Remove(Warning7); }
            //8
            if (IO.Bits.Is_OnWarning8 == true && flowLayoutPanel_1.Controls.Contains(Warning8) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning8);
            }
            else if (IO.Bits.Is_OnWarning8 == false) { flowLayoutPanel_1.Controls.Remove(Warning8); }
            //9
            if (IO.Bits.Is_OnWarning9 == true && flowLayoutPanel_1.Controls.Contains(Warning9) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning9);
            }
            else if (IO.Bits.Is_OnWarning9 == false) { flowLayoutPanel_1.Controls.Remove(Warning9); }
            //10
            if (IO.Bits.Is_OnWarning10 == true && flowLayoutPanel_1.Controls.Contains(Warning10) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning10);
            }
            else if (IO.Bits.Is_OnWarning10 == false) { flowLayoutPanel_1.Controls.Remove(Warning10); }
            //11
            if (IO.Bits.Is_OnWarning11 == true && flowLayoutPanel_1.Controls.Contains(Warning11) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning11);
            }
            else if (IO.Bits.Is_OnWarning11 == false) { flowLayoutPanel_1.Controls.Remove(Warning11); }
            //12
            if (IO.Bits.Is_OnWarning12 == true && flowLayoutPanel_1.Controls.Contains(Warning12) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning12);
            }
            else if (IO.Bits.Is_OnWarning12 == false) { flowLayoutPanel_1.Controls.Remove(Warning12); }
            //13
            if (IO.Bits.Is_OnWarning13 == true && flowLayoutPanel_1.Controls.Contains(Warning13) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning13);
            }
            else if (IO.Bits.Is_OnWarning13 == false) { flowLayoutPanel_1.Controls.Remove(Warning13); }
            //14
            if (IO.Bits.Is_OnWarning14 == true && flowLayoutPanel_1.Controls.Contains(Warning14) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning14);
            }
            else if (IO.Bits.Is_OnWarning14 == false) { flowLayoutPanel_1.Controls.Remove(Warning14); }
            //15
            if (IO.Bits.Is_OnWarning15 == true && flowLayoutPanel_1.Controls.Contains(Warning15) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning15);
            }
            else if (IO.Bits.Is_OnWarning15 == false) { flowLayoutPanel_1.Controls.Remove(Warning15); }
            //16
            if (IO.Bits.Is_OnWarning16 == true && flowLayoutPanel_1.Controls.Contains(Warning16) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning16);
            }
            else if (IO.Bits.Is_OnWarning16 == false) { flowLayoutPanel_1.Controls.Remove(Warning16); }
            //17
            if (IO.Bits.Is_OnWarning17 == true && flowLayoutPanel_1.Controls.Contains(Warning17) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning17);
            }
            else if (IO.Bits.Is_OnWarning17 == false) { flowLayoutPanel_1.Controls.Remove(Warning17); }
            //18
            if (IO.Bits.Is_OnWarning18 == true && flowLayoutPanel_1.Controls.Contains(Warning18) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning18);
            }
            else if (IO.Bits.Is_OnWarning18 == false) { flowLayoutPanel_1.Controls.Remove(Warning18); }
            //19
            if (IO.Bits.Is_OnWarning19 == true && flowLayoutPanel_1.Controls.Contains(Warning19) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning19);
            }
            else if (IO.Bits.Is_OnWarning19 == false) { flowLayoutPanel_1.Controls.Remove(Warning19); }
            //20
            if (IO.Bits.Is_OnWarning20 == true && flowLayoutPanel_1.Controls.Contains(Warning20) == false)
            {
                flowLayoutPanel_1.Controls.Add(Warning20);
            }
            else if (IO.Bits.Is_OnWarning20 == false) { flowLayoutPanel_1.Controls.Remove(Warning20); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayWarnings();
        }
    }
}