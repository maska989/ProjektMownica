using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using komunikaty;


namespace Mownica
{
    public partial class frmSerwer : Form
    {
        private TcpListener listener = null;
        private TcpClient klient = null;
        private bool czypolaczono = false;
        private BinaryReader r = null;
        private BinaryWriter w = null;
        public frmSerwer()
        {
            InitializeComponent();
        }

        public void wyswietl(RichTextBox o,string tekst)
        {
            o.Focus();
            o.AppendText(tekst);
            o.ScrollToCaret();
            TextWysyl.Focus();
        }

        private void Polaczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            wyswietl(TextLog,"Czekam na połaczenie\n");
            listener = new TcpListener(int.Parse(txtPort.Text));
            listener.Start();
            while (!listener.Pending())
            {
                if (this.Polaczenie.CancellationPending)
                {
                    if (klient != null) klient.Close();
                    listener.Stop();
                    czypolaczono = false;
                    cmdSluchaj.Text = "czekaj na połączenie";
                    return;
                }
            }

            klient = listener.AcceptTcpClient();
            wyswietl(TextLog, "Zażadano połączenia\n");
            NetworkStream stream = klient.GetStream();
            w = new BinaryWriter(stream);
            r = new BinaryReader(stream);
            if(r.ReadString() == komunikatyKlienta.zadaj)
            {
                w.Write(komunikatySerwera.OK);
                wyswietl(TextLog, "Połączono\n");
                czypolaczono = true;
                TextWysyl.Enabled = true;
                Odbieranie.RunWorkerAsync();
            }
            else
            {
                wyswietl(TextLog, "Klient odrzucony\nRozlaczono\n");
                if (klient !=null) klient.Close();
                listener.Stop();
                czypolaczono = false;
            }

        }

        private void Odbieranie_DoWork(object sender, DoWorkEventArgs e)
        {
            string tekst;
            while ((tekst = r.ReadString()) != komunikatyKlienta.rozlacz)
            {
                wyswietl(TextOdczyt, "===Rozmówca===\n" + Text + '\n');
            }
            wyswietl(TextLog, "Rozlaczono\n");
            czypolaczono = false;
            klient.Close();
            listener.Stop();
            cmdSluchaj.Text = "Czekaj na połączenie";
        }

        private void cmdWyslij_Click(object sender, EventArgs e)
        {
            try
            {
                string tekst = TextWysyl.Text;
                if (tekst == "") { TextWysyl.Focus(); return; }
                if (tekst[tekst.Length - 1] == '\n') { tekst = tekst.TrimEnd('\n'); }
                w.Write(tekst);
                wyswietl(TextOdczyt, "===Ja===\n" + tekst + '\n');
                TextWysyl.Text = "";
            }
            catch { }

        }


        private void TextWysyl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmdWyslij.Enabled && e.KeyChar == (char)13) { cmdWyslij_Click(sender, e); }
        }

        private void cmdSluchaj_Click(object sender, EventArgs e)
        {
            if(cmdSluchaj.Text == "Connect")
            {
                Polaczenie.RunWorkerAsync();
                cmdSluchaj.Text = "Disconnect";
            }
            else
            {
                if (czypolaczono)
                {
                    w.Write(komunikatySerwera.Rozlacz);
                    listener.Stop();
                    if(klient != null)
                    {
                        klient.Close();
                    }
                    czypolaczono = false;
                }
                wyswietl(TextLog, "Rozlaczono\n");
                cmdSluchaj.Text = "Czekaj na połączenie";
                cmdWyslij.Enabled = false;
                Polaczenie.CancelAsync();
                Odbieranie.CancelAsync();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (czypolaczono)
            {
                w.Write(komunikatySerwera.Rozlacz);
                listener.Stop();
                if (klient != null) { klient.Close(); }
                czypolaczono = false;
            }
            Polaczenie.CancelAsync();
            Odbieranie.CancelAsync();
        }
    }
}
