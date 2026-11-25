namespace SistemaCadastro
{
    partial class FrmLogin
    {
        
        private System.ComponentModel.IContainer components = null;

        
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.BtnConfirmaCadastro = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entrar";
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtuser.Location = new System.Drawing.Point(211, 156);
            this.txtuser.Margin = new System.Windows.Forms.Padding(4);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(387, 34);
            this.txtuser.TabIndex = 16;
            this.txtuser.TextChanged += new System.EventHandler(this.txtuser_TextChanged);
            // 
            // txtsenha
            // 
            this.txtsenha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtsenha.Location = new System.Drawing.Point(211, 227);
            this.txtsenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.Size = new System.Drawing.Size(387, 34);
            this.txtsenha.TabIndex = 17;
            this.txtsenha.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnConfirmaCadastro
            // 
            this.BtnConfirmaCadastro.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.BtnConfirmaCadastro.FlatAppearance.BorderSize = 0;
            this.BtnConfirmaCadastro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnConfirmaCadastro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirmaCadastro.ForeColor = System.Drawing.Color.Black;
            this.BtnConfirmaCadastro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnConfirmaCadastro.Location = new System.Drawing.Point(310, 300);
            this.BtnConfirmaCadastro.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConfirmaCadastro.Name = "BtnConfirmaCadastro";
            this.BtnConfirmaCadastro.Size = new System.Drawing.Size(126, 60);
            this.BtnConfirmaCadastro.TabIndex = 18;
            this.BtnConfirmaCadastro.Text = "Entrar";
            this.BtnConfirmaCadastro.UseVisualStyleBackColor = true;
            this.BtnConfirmaCadastro.UseWaitCursor = true;
            this.BtnConfirmaCadastro.Click += new System.EventHandler(this.BtnConfirmaCadastro_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Location = new System.Drawing.Point(328, 367);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(88, 44);
            this.btnFechar.TabIndex = 19;
            this.btnFechar.Text = "Sair";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.UseWaitCursor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 27);
            this.label2.TabIndex = 20;
            this.label2.Text = "Usuário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 27);
            this.label3.TabIndex = 21;
            this.label3.Text = "Senha:";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.BtnConfirmaCadastro);
            this.Controls.Add(this.txtsenha);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.Button BtnConfirmaCadastro;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}