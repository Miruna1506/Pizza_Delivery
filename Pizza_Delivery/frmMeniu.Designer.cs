namespace Pizza_Delivery
{
    partial class frmMeniu
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
            this.btnPizza = new System.Windows.Forms.Button();
            this.btnComenzi = new System.Windows.Forms.Button();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.lblSubTitlu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPizza
            // 
            this.btnPizza.BackColor = System.Drawing.Color.LightGreen;
            this.btnPizza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPizza.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPizza.Location = new System.Drawing.Point(104, 238);
            this.btnPizza.Name = "btnPizza";
            this.btnPizza.Size = new System.Drawing.Size(220, 50);
            this.btnPizza.TabIndex = 0;
            this.btnPizza.Text = "Gestionare Pizza";
            this.btnPizza.UseVisualStyleBackColor = false;
            this.btnPizza.Click += new System.EventHandler(this.btnPizza_Click);
            // 
            // btnComenzi
            // 
            this.btnComenzi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnComenzi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComenzi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComenzi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComenzi.Location = new System.Drawing.Point(104, 132);
            this.btnComenzi.Name = "btnComenzi";
            this.btnComenzi.Size = new System.Drawing.Size(220, 50);
            this.btnComenzi.TabIndex = 1;
            this.btnComenzi.Text = "Gestionare Comenzi";
            this.btnComenzi.UseVisualStyleBackColor = false;
            this.btnComenzi.Click += new System.EventHandler(this.btnComenzi_Click);
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTitlu.Location = new System.Drawing.Point(85, 9);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(281, 41);
            this.lblTitlu.TabIndex = 2;
            this.lblTitlu.Text = "Pizza Delivery App";
            // 
            // lblSubTitlu
            // 
            this.lblSubTitlu.AutoSize = true;
            this.lblSubTitlu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitlu.Location = new System.Drawing.Point(30, 65);
            this.lblSubTitlu.Name = "lblSubTitlu";
            this.lblSubTitlu.Size = new System.Drawing.Size(378, 23);
            this.lblSubTitlu.TabIndex = 3;
            this.lblSubTitlu.Text = "Selectează secțiunea pe care vrei să o gestionezi";
            // 
            // frmMeniu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(456, 341);
            this.Controls.Add(this.lblSubTitlu);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.btnComenzi);
            this.Controls.Add(this.btnPizza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMeniu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pizza Delivery - Meniu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPizza;
        private System.Windows.Forms.Button btnComenzi;
        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Label lblSubTitlu;
    }
}