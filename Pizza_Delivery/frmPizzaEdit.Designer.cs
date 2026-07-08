namespace Pizza_Delivery
{
    partial class frmPizzaEdit
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
            this.components = new System.ComponentModel.Container();
            this.txtDenumire = new System.Windows.Forms.TextBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.txtIngrediente = new System.Windows.Forms.TextBox();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.epPizza = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDimensiune = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.epPizza)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDenumire
            // 
            this.txtDenumire.Location = new System.Drawing.Point(145, 41);
            this.txtDenumire.Name = "txtDenumire";
            this.txtDenumire.Size = new System.Drawing.Size(298, 22);
            this.txtDenumire.TabIndex = 0;
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(145, 137);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(298, 22);
            this.txtPret.TabIndex = 2;
            // 
            // txtIngrediente
            // 
            this.txtIngrediente.Location = new System.Drawing.Point(145, 196);
            this.txtIngrediente.Multiline = true;
            this.txtIngrediente.Name = "txtIngrediente";
            this.txtIngrediente.Size = new System.Drawing.Size(298, 67);
            this.txtIngrediente.TabIndex = 3;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.BackColor = System.Drawing.Color.LightGreen;
            this.btnSalveaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalveaza.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalveaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalveaza.ForeColor = System.Drawing.Color.Black;
            this.btnSalveaza.Location = new System.Drawing.Point(237, 303);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(86, 30);
            this.btnSalveaza.TabIndex = 4;
            this.btnSalveaza.Text = "Salveaza";
            this.btnSalveaza.UseVisualStyleBackColor = false;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.BackColor = System.Drawing.Color.IndianRed;
            this.btnAnuleaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnuleaza.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnuleaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnuleaza.Location = new System.Drawing.Point(356, 303);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(87, 30);
            this.btnAnuleaza.TabIndex = 5;
            this.btnAnuleaza.Text = "Anuleaza";
            this.btnAnuleaza.UseVisualStyleBackColor = false;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // epPizza
            // 
            this.epPizza.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Denumire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dimensiune";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ingrediente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pret";
            // 
            // cboDimensiune
            // 
            this.cboDimensiune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDimensiune.FormattingEnabled = true;
            this.cboDimensiune.Location = new System.Drawing.Point(145, 89);
            this.cboDimensiune.Name = "cboDimensiune";
            this.cboDimensiune.Size = new System.Drawing.Size(298, 24);
            this.cboDimensiune.TabIndex = 11;
            // 
            // frmPizzaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(473, 356);
            this.Controls.Add(this.cboDimensiune);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.txtIngrediente);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.txtDenumire);
            this.Name = "frmPizzaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pizza";
            ((System.ComponentModel.ISupportInitialize)(this.epPizza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDenumire;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.TextBox txtIngrediente;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Button btnAnuleaza;
        private System.Windows.Forms.ErrorProvider epPizza;
        private System.Windows.Forms.ComboBox cboDimensiune;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}