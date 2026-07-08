namespace Pizza_Delivery
{
    partial class frmPizza
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

        private void InitializeComponent()
        {
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnEditeaza = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.lvPizza = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnAdauga
            // 
            this.btnAdauga.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdauga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdauga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdauga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdauga.Location = new System.Drawing.Point(12, 12);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(96, 35);
            this.btnAdauga.TabIndex = 0;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnEditeaza
            // 
            this.btnEditeaza.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEditeaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditeaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditeaza.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditeaza.Location = new System.Drawing.Point(147, 12);
            this.btnEditeaza.Name = "btnEditeaza";
            this.btnEditeaza.Size = new System.Drawing.Size(90, 35);
            this.btnEditeaza.TabIndex = 1;
            this.btnEditeaza.Text = "Editeaza";
            this.btnEditeaza.UseVisualStyleBackColor = false;
            this.btnEditeaza.Click += new System.EventHandler(this.btnEditeaza_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.BackColor = System.Drawing.Color.IndianRed;
            this.btnSterge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSterge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSterge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSterge.Location = new System.Drawing.Point(284, 12);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(95, 35);
            this.btnSterge.TabIndex = 2;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = false;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // lvPizza
            // 
            this.lvPizza.FullRowSelect = true;
            this.lvPizza.GridLines = true;
            this.lvPizza.HideSelection = false;
            this.lvPizza.Location = new System.Drawing.Point(12, 60);
            this.lvPizza.MultiSelect = false;
            this.lvPizza.Name = "lvPizza";
            this.lvPizza.Size = new System.Drawing.Size(812, 411);
            this.lvPizza.TabIndex = 3;
            this.lvPizza.UseCompatibleStateImageBehavior = false;
            this.lvPizza.View = System.Windows.Forms.View.Details;
            this.lvPizza.SelectedIndexChanged += new System.EventHandler(this.lvPizza_SelectedIndexChanged);
            // 
            // frmPizza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(836, 483);
            this.Controls.Add(this.lvPizza);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnEditeaza);
            this.Controls.Add(this.btnAdauga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPizza";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestionare Pizza";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnEditeaza;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.ListView lvPizza;
    }
}