namespace Csharp.Pages.Signals
{
    partial class uc_signal
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.variable_bit = new CustomControls.RJControls.RectangleShape();
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.rectangleShape1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.AliceBlue;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.rectangleShape1.BorderColor = System.Drawing.Color.LightBlue;
            this.rectangleShape1.BorderRadius = 15;
            this.rectangleShape1.BorderSize = 3;
            this.rectangleShape1.Controls.Add(this.variable_bit);
            this.rectangleShape1.Controls.Add(this.tb_Text);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(525, 39);
            this.rectangleShape1.TabIndex = 0;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            // 
            // variable_bit
            // 
            this.variable_bit.BackColor = System.Drawing.Color.Crimson;
            this.variable_bit.BackgroundColor = System.Drawing.Color.Crimson;
            this.variable_bit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.variable_bit.BorderRadius = 0;
            this.variable_bit.BorderSize = 0;
            this.variable_bit.ForeColor = System.Drawing.Color.White;
            this.variable_bit.Location = new System.Drawing.Point(18, 11);
            this.variable_bit.Name = "variable_bit";
            this.variable_bit.Size = new System.Drawing.Size(18, 18);
            this.variable_bit.TabIndex = 2;
            this.variable_bit.TextColor = System.Drawing.Color.White;
            // 
            // tb_Text
            // 
            this.tb_Text.BackColor = System.Drawing.Color.AliceBlue;
            this.tb_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Text.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_Text.ForeColor = System.Drawing.Color.Black;
            this.tb_Text.Location = new System.Drawing.Point(42, 11);
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.Size = new System.Drawing.Size(465, 18);
            this.tb_Text.TabIndex = 1;
            this.tb_Text.Text = " Text";
            // 
            // uc_signal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rectangleShape1);
            this.Name = "uc_signal";
            this.Size = new System.Drawing.Size(525, 39);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RectangleShape rectangleShape1;
        private System.Windows.Forms.TextBox tb_Text;
        public CustomControls.RJControls.RectangleShape variable_bit;
    }
}
