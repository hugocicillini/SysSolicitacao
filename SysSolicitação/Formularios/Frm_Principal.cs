using NAudio.Wave;
using System;
using System.IO;
using System.Windows.Forms;

namespace SysSolicitação
{
    public partial class Frm_Principal : Form
    {

        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        public Login obj_Login_Atual = new Login();

        public Frm_Principal()
        {
            InitializeComponent();
            string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoArquivo = Path.Combine(diretorioBase, "guns.mp3");

            audioFile = new AudioFileReader(caminhoArquivo);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Volume = 0.2f;
        }

        private void tm_Principal_Tick(object sender, EventArgs e)
        {
            tsslb_Data.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            tsslb_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gêneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Genero obj_Frm_Genero = new Frm_Genero();
            obj_Frm_Genero.ShowDialog();
        }

        private void artistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Artista obj_Frm_Artista = new Frm_Artista();
            obj_Frm_Artista.ShowDialog();
        }

        private void espetáculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Espetaculo obj_Frm_Espetaculo = new Frm_Espetaculo();
            obj_Frm_Espetaculo.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cliente obj_Frm_Cliente = new Frm_Cliente();
            obj_Frm_Cliente.ShowDialog();
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Funcionario obj_Frm_Funcionario = new Frm_Funcionario();
            obj_Frm_Funcionario.ShowDialog();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Pedido obj_Frm_Pedido = new Frm_Pedido();
            obj_Frm_Pedido.ShowDialog();
        }

        private void Frm_Principal_Shown(object sender, EventArgs e)
        {
            outputDevice.Play();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Stop();
                btn_Stop.Text = "▷";
            }
            else if (outputDevice.PlaybackState == PlaybackState.Stopped)
            {
                outputDevice.Play();
                btn_Stop.Text = "| |";
            }
        }
    }
}
