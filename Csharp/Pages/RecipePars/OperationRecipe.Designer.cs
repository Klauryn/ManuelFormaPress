namespace Csharp.RecipePars
{
    partial class OperationRecipe
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
            this.btn_Close = new CustomControls.RJControls.RoundedButton();
            this.btn_Delete = new CustomControls.RJControls.RoundedButton();
            this.btn_SaveAs = new CustomControls.RJControls.RoundedButton();
            this.btn_Add = new CustomControls.RJControls.RoundedButton();
            this.rectangleShape1 = new CustomControls.RJControls.RectangleShape();
            this.label_tittle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.rectangleShape1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Close, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_Delete, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_SaveAs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rectangleShape1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 220);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Red;
            this.btn_Close.BackgroundColor = System.Drawing.Color.Red;
            this.btn_Close.BorderColor = System.Drawing.Color.LightCoral;
            this.btn_Close.BorderRadius = 10;
            this.btn_Close.BorderSize = 1;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(6, 179);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(238, 35);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Kapat";
            this.btn_Close.TextColor = System.Drawing.Color.White;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Delete.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btn_Delete.BorderColor = System.Drawing.Color.LightBlue;
            this.btn_Delete.BorderRadius = 10;
            this.btn_Delete.BorderSize = 1;
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(6, 136);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(238, 34);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Sil";
            this.btn_Delete.TextColor = System.Drawing.Color.White;
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_SaveAs.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btn_SaveAs.BorderColor = System.Drawing.Color.LightBlue;
            this.btn_SaveAs.BorderRadius = 10;
            this.btn_SaveAs.BorderSize = 1;
            this.btn_SaveAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SaveAs.FlatAppearance.BorderSize = 0;
            this.btn_SaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveAs.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveAs.ForeColor = System.Drawing.Color.White;
            this.btn_SaveAs.Location = new System.Drawing.Point(6, 93);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(238, 34);
            this.btn_SaveAs.TabIndex = 1;
            this.btn_SaveAs.Text = "Farklı Kaydet";
            this.btn_SaveAs.TextColor = System.Drawing.Color.White;
            this.btn_SaveAs.UseVisualStyleBackColor = false;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Add.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btn_Add.BorderColor = System.Drawing.Color.LightBlue;
            this.btn_Add.BorderRadius = 10;
            this.btn_Add.BorderSize = 1;
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(6, 50);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(238, 34);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Ekle";
            this.btn_Add.TextColor = System.Drawing.Color.White;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Gainsboro;
            this.rectangleShape1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.rectangleShape1.BorderColor = System.Drawing.Color.LightGray;
            this.rectangleShape1.BorderRadius = 0;
            this.rectangleShape1.BorderSize = 3;
            this.rectangleShape1.Controls.Add(this.label_tittle);
            this.rectangleShape1.ForeColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(6, 6);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(238, 35);
            this.rectangleShape1.TabIndex = 4;
            this.rectangleShape1.TextColor = System.Drawing.Color.White;
            // 
            // label_tittle
            // 
            this.label_tittle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_tittle.AutoSize = true;
            this.label_tittle.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_tittle.ForeColor = System.Drawing.Color.Black;
            this.label_tittle.Location = new System.Drawing.Point(34, 6);
            this.label_tittle.Name = "label_tittle";
            this.label_tittle.Size = new System.Drawing.Size(170, 22);
            this.label_tittle.TabIndex = 1;
            this.label_tittle.Text = "REÇETE İŞLEMLERİ";
            this.label_tittle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OperationRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 220);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OperationRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rectangleShape1.ResumeLayout(false);
            this.rectangleShape1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.RJControls.RoundedButton btn_Close;
        private CustomControls.RJControls.RoundedButton btn_Delete;
        private CustomControls.RJControls.RoundedButton btn_SaveAs;
        private CustomControls.RJControls.RoundedButton btn_Add;
        private CustomControls.RJControls.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label_tittle;
    }
}