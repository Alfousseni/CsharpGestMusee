namespace MuseeApps.Forms
{
    partial class ListOeuvre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOeuvre));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.actualiser_btn = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imprimerOeuvre = new Bunifu.Framework.UI.BunifuThinButton2();
            this.oeuvreTableau = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oeuvreTableau)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.actualiser_btn);
            this.panel1.Controls.Add(this.bunifuLabel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.imprimerOeuvre);
            this.panel1.Controls.Add(this.oeuvreTableau);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // actualiser_btn
            // 
            this.actualiser_btn.ActiveBorderThickness = 1;
            this.actualiser_btn.ActiveCornerRadius = 20;
            this.actualiser_btn.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.actualiser_btn.ActiveForecolor = System.Drawing.Color.White;
            this.actualiser_btn.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.actualiser_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.actualiser_btn.BackColor = System.Drawing.Color.Honeydew;
            this.actualiser_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("actualiser_btn.BackgroundImage")));
            this.actualiser_btn.ButtonText = "Actualiser";
            this.actualiser_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actualiser_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualiser_btn.ForeColor = System.Drawing.Color.SeaGreen;
            this.actualiser_btn.IdleBorderThickness = 1;
            this.actualiser_btn.IdleCornerRadius = 1;
            this.actualiser_btn.IdleFillColor = System.Drawing.Color.SeaGreen;
            this.actualiser_btn.IdleForecolor = System.Drawing.Color.White;
            this.actualiser_btn.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.actualiser_btn.Location = new System.Drawing.Point(554, 8);
            this.actualiser_btn.Margin = new System.Windows.Forms.Padding(5);
            this.actualiser_btn.Name = "actualiser_btn";
            this.actualiser_btn.Size = new System.Drawing.Size(120, 41);
            this.actualiser_btn.TabIndex = 32;
            this.actualiser_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actualiser_btn.Click += new System.EventHandler(this.actualiser_btn_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuLabel1.Location = new System.Drawing.Point(140, 8);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(309, 40);
            this.bunifuLabel1.TabIndex = 31;
            this.bunifuLabel1.Text = "Listes Des Oeuvres";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuLabel1.Click += new System.EventHandler(this.bunifuLabel1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(538, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // imprimerOeuvre
            // 
            this.imprimerOeuvre.ActiveBorderThickness = 1;
            this.imprimerOeuvre.ActiveCornerRadius = 20;
            this.imprimerOeuvre.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.imprimerOeuvre.ActiveForecolor = System.Drawing.Color.White;
            this.imprimerOeuvre.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.imprimerOeuvre.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.imprimerOeuvre.BackColor = System.Drawing.Color.Honeydew;
            this.imprimerOeuvre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imprimerOeuvre.BackgroundImage")));
            this.imprimerOeuvre.ButtonText = "Imprimer";
            this.imprimerOeuvre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imprimerOeuvre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imprimerOeuvre.ForeColor = System.Drawing.Color.SeaGreen;
            this.imprimerOeuvre.IdleBorderThickness = 1;
            this.imprimerOeuvre.IdleCornerRadius = 1;
            this.imprimerOeuvre.IdleFillColor = System.Drawing.Color.SeaGreen;
            this.imprimerOeuvre.IdleForecolor = System.Drawing.Color.White;
            this.imprimerOeuvre.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.imprimerOeuvre.Location = new System.Drawing.Point(187, 389);
            this.imprimerOeuvre.Margin = new System.Windows.Forms.Padding(5);
            this.imprimerOeuvre.Name = "imprimerOeuvre";
            this.imprimerOeuvre.Size = new System.Drawing.Size(217, 47);
            this.imprimerOeuvre.TabIndex = 29;
            this.imprimerOeuvre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.imprimerOeuvre.Click += new System.EventHandler(this.imprimerOeuvre_Click);
            // 
            // oeuvreTableau
            // 
            this.oeuvreTableau.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.oeuvreTableau.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.oeuvreTableau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oeuvreTableau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.oeuvreTableau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oeuvreTableau.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.oeuvreTableau.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oeuvreTableau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.oeuvreTableau.ColumnHeadersHeight = 40;
            this.oeuvreTableau.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.oeuvreTableau.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.oeuvreTableau.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.oeuvreTableau.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.oeuvreTableau.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.oeuvreTableau.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.oeuvreTableau.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.oeuvreTableau.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.oeuvreTableau.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.oeuvreTableau.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.oeuvreTableau.CurrentTheme.Name = null;
            this.oeuvreTableau.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.oeuvreTableau.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.oeuvreTableau.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.oeuvreTableau.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.oeuvreTableau.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oeuvreTableau.DefaultCellStyle = dataGridViewCellStyle3;
            this.oeuvreTableau.EnableHeadersVisualStyles = false;
            this.oeuvreTableau.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.oeuvreTableau.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.oeuvreTableau.HeaderBgColor = System.Drawing.Color.Empty;
            this.oeuvreTableau.HeaderForeColor = System.Drawing.Color.White;
            this.oeuvreTableau.Location = new System.Drawing.Point(21, 54);
            this.oeuvreTableau.Name = "oeuvreTableau";
            this.oeuvreTableau.RowHeadersVisible = false;
            this.oeuvreTableau.RowHeadersWidth = 51;
            this.oeuvreTableau.RowTemplate.Height = 40;
            this.oeuvreTableau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.oeuvreTableau.Size = new System.Drawing.Size(511, 327);
            this.oeuvreTableau.TabIndex = 1;
            this.oeuvreTableau.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.oeuvreTableau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oeuvreTableau_CellClick);
            // 
            // ListOeuvre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListOeuvre";
            this.Text = "ListArticle";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oeuvreTableau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 imprimerOeuvre;
        private Bunifu.UI.WinForms.BunifuDataGridView oeuvreTableau;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 actualiser_btn;
    }
}