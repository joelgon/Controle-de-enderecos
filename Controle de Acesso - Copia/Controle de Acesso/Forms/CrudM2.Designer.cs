namespace Controle_de_Acesso.Forms
{
    partial class CrudM2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrudM2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Funcionario = new System.Windows.Forms.ToolStripMenuItem();
            this.Enderecos = new System.Windows.Forms.ToolStripMenuItem();
            this.Moradores = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Funcionario,
            this.Enderecos,
            this.Moradores});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1362, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Funcionario
            // 
            this.Funcionario.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Funcionario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Funcionario.Name = "Funcionario";
            this.Funcionario.Size = new System.Drawing.Size(87, 20);
            this.Funcionario.Text = "Funcionarios";
            this.Funcionario.Click += new System.EventHandler(this.Funcionario_Click);
            // 
            // Enderecos
            // 
            this.Enderecos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Enderecos.Name = "Enderecos";
            this.Enderecos.Size = new System.Drawing.Size(73, 20);
            this.Enderecos.Text = "Endereços";
            this.Enderecos.Click += new System.EventHandler(this.Enderecos_Click);
            // 
            // Moradores
            // 
            this.Moradores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Moradores.Name = "Moradores";
            this.Moradores.Size = new System.Drawing.Size(76, 20);
            this.Moradores.Text = "Moradores";
            this.Moradores.Click += new System.EventHandler(this.Moradores_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1362, 715);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CrudM2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CrudM2";
            this.Text = "CrudM2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Funcionario;
        private System.Windows.Forms.ToolStripMenuItem Enderecos;
        private System.Windows.Forms.ToolStripMenuItem Moradores;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}