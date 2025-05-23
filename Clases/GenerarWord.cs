using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;

namespace proyecto_1_programacion.Clases
{
    public class GenerarWord
    {
    public void CrearDocumentoWord(string tema, string contenidio)
        {
            string carpeta = @"C:\Users\ASUS\OneDrive\Documentos\Ing en sistemas 1 semsetre\Tercer semestre\Programacion 1\programas\proyecto 1 programacion\Investigaciones";
            Directory.CreateDirectory(carpeta);

            string rutaArchivo = Path.Combine(carpeta, $"{tema.Replace(" ", "_")}.docx");

            using (WordprocessingDocument documento = WordprocessingDocument.Create(rutaArchivo, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = documento.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                // Título centrado
                Paragraph titulo = new Paragraph(new Run(new Text($"Investigación sobre: {tema}")));
                titulo.ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
                body.Append(titulo);
                body.Append(new Paragraph(new Run(new Text("")))); // espacio

                // Contenido en párrafos
                string[] parrafos = contenidio.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string parrafo in parrafos)
                {
                    Paragraph p = new Paragraph(new Run(new Text(parrafo.Trim())));
                    body.Append(p);
                }

                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }

            System.Windows.Forms.MessageBox.Show("Documento Word generado correctamente en: " + rutaArchivo);
        }
    }
}
