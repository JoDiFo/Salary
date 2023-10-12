namespace Salary
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.PositionsBtn = new System.Windows.Forms.Button();
            this.TaxesBtn = new System.Windows.Forms.Button();
            this.StatementBtn = new System.Windows.Forms.Button();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.LogoLbl = new System.Windows.Forms.Label();
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.CloseChildBtn = new System.Windows.Forms.Button();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.ChildFormPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.LogoPanel.SuspendLayout();
            this.TitleBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.SearchBtn);
            this.panelMenu.Controls.Add(this.PositionsBtn);
            this.panelMenu.Controls.Add(this.TaxesBtn);
            this.panelMenu.Controls.Add(this.StatementBtn);
            this.panelMenu.Controls.Add(this.LogoPanel);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 606);
            this.panelMenu.TabIndex = 0;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.SearchBtn.Location = new System.Drawing.Point(0, 260);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(220, 60);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // PositionsBtn
            // 
            this.PositionsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.PositionsBtn.FlatAppearance.BorderSize = 0;
            this.PositionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PositionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PositionsBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.PositionsBtn.Location = new System.Drawing.Point(0, 200);
            this.PositionsBtn.Name = "PositionsBtn";
            this.PositionsBtn.Size = new System.Drawing.Size(220, 60);
            this.PositionsBtn.TabIndex = 3;
            this.PositionsBtn.Text = "Positions";
            this.PositionsBtn.UseVisualStyleBackColor = true;
            this.PositionsBtn.Click += new System.EventHandler(this.PositionsBtn_Click);
            // 
            // TaxesBtn
            // 
            this.TaxesBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaxesBtn.FlatAppearance.BorderSize = 0;
            this.TaxesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TaxesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TaxesBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.TaxesBtn.Location = new System.Drawing.Point(0, 140);
            this.TaxesBtn.Name = "TaxesBtn";
            this.TaxesBtn.Size = new System.Drawing.Size(220, 60);
            this.TaxesBtn.TabIndex = 2;
            this.TaxesBtn.Text = "Taxes";
            this.TaxesBtn.UseVisualStyleBackColor = true;
            this.TaxesBtn.Click += new System.EventHandler(this.TaxesBtn_Click);
            // 
            // StatementBtn
            // 
            this.StatementBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatementBtn.FlatAppearance.BorderSize = 0;
            this.StatementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatementBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatementBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.StatementBtn.Location = new System.Drawing.Point(0, 80);
            this.StatementBtn.Name = "StatementBtn";
            this.StatementBtn.Size = new System.Drawing.Size(220, 60);
            this.StatementBtn.TabIndex = 1;
            this.StatementBtn.Text = "Statement";
            this.StatementBtn.UseVisualStyleBackColor = true;
            this.StatementBtn.Click += new System.EventHandler(this.StatementBtn_Click);
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.LogoPanel.Controls.Add(this.LogoLbl);
            this.LogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoPanel.Location = new System.Drawing.Point(0, 0);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(220, 80);
            this.LogoPanel.TabIndex = 0;
            // 
            // LogoLbl
            // 
            this.LogoLbl.AutoSize = true;
            this.LogoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoLbl.ForeColor = System.Drawing.Color.LightGray;
            this.LogoLbl.Location = new System.Drawing.Point(82, 28);
            this.LogoLbl.Name = "LogoLbl";
            this.LogoLbl.Size = new System.Drawing.Size(56, 25);
            this.LogoLbl.TabIndex = 0;
            this.LogoLbl.Text = "Logo";
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.TitleBarPanel.Controls.Add(this.CloseChildBtn);
            this.TitleBarPanel.Controls.Add(this.TitleLbl);
            this.TitleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarPanel.Location = new System.Drawing.Point(220, 0);
            this.TitleBarPanel.Name = "TitleBarPanel";
            this.TitleBarPanel.Size = new System.Drawing.Size(982, 80);
            this.TitleBarPanel.TabIndex = 1;
            // 
            // CloseChildBtn
            // 
            this.CloseChildBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseChildBtn.BackgroundImage")));
            this.CloseChildBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseChildBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseChildBtn.FlatAppearance.BorderSize = 0;
            this.CloseChildBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseChildBtn.Location = new System.Drawing.Point(902, 0);
            this.CloseChildBtn.Name = "CloseChildBtn";
            this.CloseChildBtn.Size = new System.Drawing.Size(80, 80);
            this.CloseChildBtn.TabIndex = 1;
            this.CloseChildBtn.UseVisualStyleBackColor = true;
            this.CloseChildBtn.Click += new System.EventHandler(this.CloseChildBtn_Click);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft JhengHei", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLbl.ForeColor = System.Drawing.Color.White;
            this.TitleLbl.Location = new System.Drawing.Point(266, 23);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(450, 35);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "HOME";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChildFormPanel
            // 
            this.ChildFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildFormPanel.Location = new System.Drawing.Point(220, 80);
            this.ChildFormPanel.Name = "ChildFormPanel";
            this.ChildFormPanel.Size = new System.Drawing.Size(982, 526);
            this.ChildFormPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 606);
            this.Controls.Add(this.ChildFormPanel);
            this.Controls.Add(this.TitleBarPanel);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1150, 575);
            this.Name = "MainForm";
            this.panelMenu.ResumeLayout(false);
            this.LogoPanel.ResumeLayout(false);
            this.LogoPanel.PerformLayout();
            this.TitleBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button PositionsBtn;
        private System.Windows.Forms.Button TaxesBtn;
        private System.Windows.Forms.Button StatementBtn;
        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label LogoLbl;
        private System.Windows.Forms.Panel ChildFormPanel;
        private System.Windows.Forms.Button CloseChildBtn;
    }
}