using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp.Pages.Signals
{
    public partial class uc_SignalsPage : UserControl
    {
        public uc_SignalsPage()
        {
            InitializeComponent();

            flowLayoutPanel_1.Controls.Clear();
            flowLayoutPanel_2.Controls.Clear();
            flowLayoutPanel_3.Controls.Clear();



            uc_signal signal1 = new uc_signal(true, "deneme");
            flowLayoutPanel_1.Controls.Add(signal1);
            uc_signal signal2 = new uc_signal(true, "deneme");
            flowLayoutPanel_1.Controls.Add(signal2);

            uc_signal signal3 = new uc_signal(false, "deneme");
            flowLayoutPanel_2.Controls.Add(signal3);
            uc_signal signal4 = new uc_signal(false, "deneme");
            flowLayoutPanel_2.Controls.Add(signal4);

            uc_signal signal5 = new uc_signal(true, "deneme");
            flowLayoutPanel_3.Controls.Add(signal5);
            uc_signal signal6 = new uc_signal(false, "deneme");
            flowLayoutPanel_3.Controls.Add(signal6);
            uc_signal signal7 = new uc_signal(true, "deneme");
            flowLayoutPanel_3.Controls.Add(signal7);
            uc_signal signal8 = new uc_signal(false, "deneme");
            flowLayoutPanel_3.Controls.Add(signal8);
            uc_signal signal9 = new uc_signal(true, "deneme");
            flowLayoutPanel_3.Controls.Add(signal9);

            uc_signal signal10 = new uc_signal(true, "deneme");
            flowLayoutPanel_3.Controls.Add(signal10);
            uc_signal signal11 = new uc_signal(false, "deneme");
            flowLayoutPanel_3.Controls.Add(signal11);
            uc_signal signal12 = new uc_signal(true, "deneme");
            flowLayoutPanel_3.Controls.Add(signal12);
            uc_signal signal13 = new uc_signal(false, "deneme");
            flowLayoutPanel_3.Controls.Add(signal13);
            uc_signal signal14 = new uc_signal(true, "deneme");
            flowLayoutPanel_3.Controls.Add(signal14);
        }

        private void uc_SignalsPage_Load(object sender, EventArgs e)
        {

            //IO.Bools[0];
        }
    }
}
