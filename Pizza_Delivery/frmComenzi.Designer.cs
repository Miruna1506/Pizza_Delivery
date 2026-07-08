namespace Pizza_Delivery
{
    partial class frmComenzi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnEditeaza = new System.Windows.Forms.Button();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.lvComenzi = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.btnSterge);
            this.panel1.Controls.Add(this.btnEditeaza);
            this.panel1.Controls.Add(this.btnAdauga);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1753, 70);
            this.panel1.TabIndex = 1;
            // 
            // btnSterge
            // 
            this.btnSterge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSterge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSterge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSterge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSterge.Location = new System.Drawing.Point(336, 22);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(100, 35);
            this.btnSterge.TabIndex = 2;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = false;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnEditeaza
            // 
            this.btnEditeaza.BackColor = System.Drawing.Color.SkyBlue;
            this.btnEditeaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditeaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditeaza.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditeaza.Location = new System.Drawing.Point(183, 22);
            this.btnEditeaza.Name = "btnEditeaza";
            this.btnEditeaza.Size = new System.Drawing.Size(100, 35);
            this.btnEditeaza.TabIndex = 1;
            this.btnEditeaza.Text = "Editeaza";
            this.btnEditeaza.UseVisualStyleBackColor = false;
            this.btnEditeaza.Click += new System.EventHandler(this.btnEditeaza_Click);
            // 
            // btnAdauga
            // 
            this.btnAdauga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdauga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdauga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdauga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdauga.Location = new System.Drawing.Point(34, 22);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(100, 35);
            this.btnAdauga.TabIndex = 0;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // lvComenzi
            // 
            this.lvComenzi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComenzi.FullRowSelect = true;
            this.lvComenzi.GridLines = true;
            this.lvComenzi.HideSelection = false;
            this.lvComenzi.Location = new System.Drawing.Point(0, 70);
            this.lvComenzi.MultiSelect = false;
            this.lvComenzi.Name = "lvComenzi";
            this.lvComenzi.Size = new System.Drawing.Size(1753, 719);
            this.lvComenzi.TabIndex = 2;
            this.lvComenzi.UseCompatibleStateImageBehavior = false;
            this.lvComenzi.View = System.Windows.Forms.View.Details;
            this.lvComenzi.SelectedIndexChanged += new System.EventHandler(this.lvComenzi_SelectedIndexChanged);
            // 
            // frmComenzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 789);
            this.Controls.Add(this.lvComenzi);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmComenzi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionare Comenzi";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnEditeaza;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.ListView lvComenzi;
    }
}