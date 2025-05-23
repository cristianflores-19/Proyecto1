namespace proyecto_1_programacion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxTema = new TextBox();
            buttonConsulta = new Button();
            richTextBoxResultado = new RichTextBox();
            buttonExportarWord = new Button();
            progressBarProceso = new ProgressBar();
            buttonExportarPower = new Button();
            SuspendLayout();
            // 
            // textBoxTema
            // 
            textBoxTema.Location = new Point(12, 101);
            textBoxTema.Name = "textBoxTema";
            textBoxTema.Size = new Size(347, 27);
            textBoxTema.TabIndex = 0;
            // 
            // buttonConsulta
            // 
            buttonConsulta.BackColor = Color.DarkGray;
            buttonConsulta.Font = new Font("Verdana", 12F, FontStyle.Bold);
            buttonConsulta.Location = new Point(124, 134);
            buttonConsulta.Name = "buttonConsulta";
            buttonConsulta.Size = new Size(127, 43);
            buttonConsulta.TabIndex = 1;
            buttonConsulta.Text = "Consultar";
            buttonConsulta.UseVisualStyleBackColor = false;
            buttonConsulta.Click += buttonConsulta_Click;
            // 
            // richTextBoxResultado
            // 
            richTextBoxResultado.BackColor = Color.DarkGray;
            richTextBoxResultado.Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBoxResultado.ForeColor = Color.Black;
            richTextBoxResultado.Location = new Point(365, 12);
            richTextBoxResultado.Name = "richTextBoxResultado";
            richTextBoxResultado.Size = new Size(759, 348);
            richTextBoxResultado.TabIndex = 2;
            richTextBoxResultado.Text = "";
            // 
            // buttonExportarWord
            // 
            buttonExportarWord.BackColor = Color.DarkGray;
            buttonExportarWord.Font = new Font("Verdana", 12F, FontStyle.Bold);
            buttonExportarWord.Location = new Point(678, 377);
            buttonExportarWord.Name = "buttonExportarWord";
            buttonExportarWord.Size = new Size(187, 43);
            buttonExportarWord.TabIndex = 3;
            buttonExportarWord.Text = "Exportar Word";
            buttonExportarWord.UseVisualStyleBackColor = false;
            buttonExportarWord.Click += buttonExportarWord_Click;
            // 
            // progressBarProceso
            // 
            progressBarProceso.Location = new Point(12, 233);
            progressBarProceso.Name = "progressBarProceso";
            progressBarProceso.Size = new Size(347, 29);
            progressBarProceso.TabIndex = 4;
            // 
            // buttonExportarPower
            // 
            buttonExportarPower.BackColor = Color.DarkGray;
            buttonExportarPower.Font = new Font("Verdana", 12F, FontStyle.Bold);
            buttonExportarPower.Location = new Point(625, 426);
            buttonExportarPower.Name = "buttonExportarPower";
            buttonExportarPower.Size = new Size(295, 43);
            buttonExportarPower.TabIndex = 5;
            buttonExportarPower.Text = "Exportar Power Point";
            buttonExportarPower.UseVisualStyleBackColor = false;
            buttonExportarPower.Click += buttonExportarPower_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.photo_1663970206579_c157cba7edda;
            ClientSize = new Size(1178, 555);
            Controls.Add(buttonExportarPower);
            Controls.Add(progressBarProceso);
            Controls.Add(buttonExportarWord);
            Controls.Add(richTextBoxResultado);
            Controls.Add(buttonConsulta);
            Controls.Add(textBoxTema);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTema;
        private Button buttonConsulta;
        private RichTextBox richTextBoxResultado;
        private Button buttonExportarWord;
        private ProgressBar progressBarProceso;
        private Button buttonExportarPower;
    }
}
