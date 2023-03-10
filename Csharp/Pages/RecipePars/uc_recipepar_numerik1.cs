using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Csharp.Pages.General;
using Csharp.EventsAggregator;

namespace Csharp.Pages.RecipePars
{
    public partial class uc_recipepar_numerik1 : UserControl
    {
        private eRecipeParameterChanged fooChanged;
        public uc_recipepar_numerik1()
        {
            InitializeComponent();
            fooChanged = new eRecipeParameterChanged();
        }
        private void tb_value_MouseDown(object sender, MouseEventArgs e)
        {
            //NumPad ekrana sığmaz ise sığdıralım.
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int MouseXPos = MousePosition.X - 100;
            int MouseYPos = MousePosition.Y + 25;
            while(MouseXPos>resolution.Width-382)
            {
                MouseXPos = MouseXPos - 1;
            }
            while (MouseYPos > resolution.Height-335)
            {
                MouseYPos = MouseYPos - 1;
            }
            double dNumPadResult = MyNumPad.ShowNumPad(MouseXPos, MouseYPos);
            if (dNumPadResult != 999999)
            {
                tb_value.Text = dNumPadResult.ToString();
                fooChanged.EventFired();
            }    
        }
    }
}
