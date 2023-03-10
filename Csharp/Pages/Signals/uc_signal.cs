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
    public partial class uc_signal : UserControl
    {
        public uc_signal(bool var,string text)
        {
            InitializeComponent();
            VariableProperty = var;
            TextProperty = text;
        }
        private bool _variable;
        private string _text;

        [Category("Custom Props")]
        public bool VariableProperty
        { 
            get { return _variable; }
            set { _variable = value;if (_variable) { variable_bit.BackColor = Color.Green; } else { variable_bit.BackColor = Color.Red; } }
        }
        [Category("Custom Props")]
        public string TextProperty
        {
            get { return _text; }
            set { _text = value; tb_Text.Text = value; }
        }
    }
}
