using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using proyecto_1_programacion.Clases;
using System;
using System.Windows.Forms;

namespace proyecto_1_programacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonConsulta_Click(object sender, EventArgs e)
        {
            string tema = textBoxTema.Text.Trim();

            if (string.IsNullOrWhiteSpace(tema))
            {
                MessageBox.Show("Por favor, ingresa un tema para investigar.", "Atención");
                return;
            }

            progressBarProceso.Style = ProgressBarStyle.Marquee;
            buttonConsulta.Enabled = false;
            buttonExportarWord.Enabled = false;

            try
            {
                IAservice servicioIA = new IAservice();
                string prompt = $"Haz una investigación detallada en al menos 3 párrafos sobre el tema: {tema}";
                string resultado = await servicioIA.ConsultarIA(prompt);
                richTextBoxResultado.Text = resultado;
                BDService baseDatos = new BDService();
                baseDatos.GuardarResultado(tema, resultado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error");
            }
            finally
            {
                progressBarProceso.Style = ProgressBarStyle.Blocks;
                buttonConsulta.Enabled = true;
                buttonExportarWord.Enabled = true;
            }
        }

        private void buttonExportarWord_Click(object sender, EventArgs e)
        {
            string tema = textBoxTema.Text.Trim();
            string resultado = richTextBoxResultado.Text.Trim();

            if (string.IsNullOrEmpty(tema) || string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show("Por favor, completa tanto el tema como el contenido antes de exportar.");
                return;
            }

            GenerarWord generador = new GenerarWord();
            generador.CrearDocumentoWord(tema, resultado);
        }

        private void buttonExportarPower_Click(object sender, EventArgs e)
        {
            string tema = textBoxTema.Text;
            string contenido = richTextBoxResultado.Text;

            GenerarPowerPoint generador = new GenerarPowerPoint();
            generador.CrearPresentacionPowerPoint(tema, contenido);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

    



