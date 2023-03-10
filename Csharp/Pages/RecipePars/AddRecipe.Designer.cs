namespace Csharp.RecipePars
{
    partial class AddRecipe
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.label_tittle = new System.Windows.Forms.Label();
            this.rectangleShape2 = new CustomControls.RJControls.RectangleShape();
            this.tb_Entry = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Accept = new CustomControls.RJControls.RoundedButton();
            this.btn_Cancel = new CustomControls.RJControls.RoundedButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.rectangleShape1.SuspendLayout();
            this.rectangleShape2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.SteelBlue;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.rectangleShape1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rectangleShape1.BorderRadius = 5;
            this.rectangleShape1.BorderSize = 0;
            this.rectangleShape1.Controls.Add(this.label_tittle);
            this.rectangleShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(3, 3);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(425, 33);
            this.rectangleShape1.TabIndex = 1;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            // 
            // label_tittle
            // 
            this.label_tittle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_tittle.AutoSize = true;
            this.label_tittle.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_tittle.Location = new System.Drawing.Point(132, 6);
            this.label_tittle.Name = "label_tittle";
            this.label_tittle.Size = new System.Drawing.Size(170, 22);
            this.label_tittle.TabIndex = 0;
            this.label_tittle.Text = "Yeni Reçete Ekle";
            this.label_tittle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.White;
            this.rectangleShape2.BackgroundColor = System.Drawing.Color.White;
            this.rectangleShape2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rectangleShape2.BorderRadius = 10;
            this.rectangleShape2.BorderSize = 0;
            this.rectangleShape2.Controls.Add(this.tb_Entry);
            this.rectangleShape2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rectangleShape2.ForeColor = System.Drawing.Color.White;
            this.rectangleShape2.Location = new System.Drawing.Point(3, 42);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(425, 100);
            this.rectangleShape2.TabIndex = 0;
            this.rectangleShape2.TextColor = System.Drawing.Color.White;
            // 
            // tb_Entry
            // 
            this.tb_Entry.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Entry.Location = new System.Drawing.Point(9, 13);
            this.tb_Entry.Multiline = true;
            this.tb_Entry.Name = "tb_Entry";
            this.tb_Entry.Size = new System.Drawing.Size(407, 75);
            this.tb_Entry.TabIndex = 0;
            this.tb_Entry.Click += new System.EventHandler(this.tb_Entry_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Accept);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 43);
            this.panel1.TabIndex = 2;
            // 
            // btn_Accept
            // 
            this.btn_Accept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Accept.BackColor = System.Drawing.Color.Green;
            this.btn_Accept.BackgroundColor = System.Drawing.Color.Green;
            this.btn_Accept.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Accept.BorderRadius = 10;
            this.btn_Accept.BorderSize = 0;
            this.btn_Accept.FlatAppearance.BorderSize = 0;
            this.btn_Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accept.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Accept.ForeColor = System.Drawing.Color.White;
            this.btn_Accept.Location = new System.Drawing.Point(106, 3);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(72, 36);
            this.btn_Accept.TabIndex = 5;
            this.btn_Accept.Text = "EKLE";
            this.btn_Accept.TextColor = System.Drawing.Color.White;
            this.btn_Accept.UseVisualStyleBackColor = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Cancel.BackColor = System.Drawing.Color.Red;
            this.btn_Cancel.BackgroundColor = System.Drawing.Color.Red;
            this.btn_Cancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_Cancel.BorderRadius = 10;
            this.btn_Cancel.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(259, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 36);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "İPTAL";
            this.btn_Cancel.TextColor = System.Drawing.Color.White;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // AddRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 194);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.rectangleShape2.ResumeLayout(false);
            this.rectangleShape2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.RJControls.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label_tittle;
        private CustomControls.RJControls.RectangleShape rectangleShape2;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RoundedButton btn_Accept;
        private CustomControls.RJControls.RoundedButton btn_Cancel;
        private System.Windows.Forms.TextBox tb_Entry;
    }
}