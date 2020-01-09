namespace Mownica
{
    partial class frmSerwer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextOdczyt = new System.Windows.Forms.RichTextBox();
            this.TextWysyl = new System.Windows.Forms.RichTextBox();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdSluchaj = new System.Windows.Forms.Button();
            this.cmdWyslij = new System.Windows.Forms.Button();
            this.Polaczenie = new System.ComponentModel.BackgroundWorker();
            this.Odbieranie = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // TextOdczyt
            // 
            this.TextOdczyt.Location = new System.Drawing.Point(13, 13);
            this.TextOdczyt.Name = "TextOdczyt";
            this.TextOdczyt.ReadOnly = true;
            this.TextOdczyt.Size = new System.Drawing.Size(255, 96);
            this.TextOdczyt.TabIndex = 0;
            this.TextOdczyt.Text = "";
            // 
            // TextWysyl
            // 
            this.TextWysyl.Location = new System.Drawing.Point(13, 125);
            this.TextWysyl.Name = "TextWysyl";
            this.TextWysyl.Size = new System.Drawing.Size(255, 96);
            this.TextWysyl.TabIndex = 1;
            this.TextWysyl.Text = "";
            this.TextWysyl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextWysyl_KeyPress);
            // 
            // TextLog
            // 
            this.TextLog.Location = new System.Drawing.Point(13, 227);
            this.TextLog.Name = "TextLog";
            this.TextLog.Size = new System.Drawing.Size(255, 96);
            this.TextLog.TabIndex = 2;
            this.TextLog.Text = "";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(633, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8000";
            // 
            // cmdSluchaj
            // 
            this.cmdSluchaj.Location = new System.Drawing.Point(633, 39);
            this.cmdSluchaj.Name = "cmdSluchaj";
            this.cmdSluchaj.Size = new System.Drawing.Size(155, 23);
            this.cmdSluchaj.TabIndex = 5;
            this.cmdSluchaj.Text = "Czekaj na połączenie";
            this.cmdSluchaj.UseVisualStyleBackColor = true;
            this.cmdSluchaj.Click += new System.EventHandler(this.cmdSluchaj_Click);
            // 
            // cmdWyslij
            // 
            this.cmdWyslij.Enabled = false;
            this.cmdWyslij.Location = new System.Drawing.Point(633, 69);
            this.cmdWyslij.Name = "cmdWyslij";
            this.cmdWyslij.Size = new System.Drawing.Size(155, 23);
            this.cmdWyslij.TabIndex = 6;
            this.cmdWyslij.Text = "Send";
            this.cmdWyslij.UseVisualStyleBackColor = true;
            this.cmdWyslij.Click += new System.EventHandler(this.cmdWyslij_Click);
            // 
            // Polaczenie
            // 
            this.Polaczenie.WorkerSupportsCancellation = true;
            this.Polaczenie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Polaczenie_DoWork);
            // 
            // Odbieranie
            // 
            this.Odbieranie.WorkerSupportsCancellation = true;
            this.Odbieranie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Odbieranie_DoWork);
            // 
            // frmSerwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 351);
            this.Controls.Add(this.cmdWyslij);
            this.Controls.Add(this.cmdSluchaj);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.TextWysyl);
            this.Controls.Add(this.TextOdczyt);
            this.Name = "frmSerwer";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextOdczyt;
        private System.Windows.Forms.RichTextBox TextWysyl;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button cmdSluchaj;
        private System.Windows.Forms.Button cmdWyslij;
        private System.ComponentModel.BackgroundWorker Polaczenie;
        private System.ComponentModel.BackgroundWorker Odbieranie;
    }
}

