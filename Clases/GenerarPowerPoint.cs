using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using P = DocumentFormat.OpenXml.Presentation;

public class GenerarPowerPoint
{
    public void CrearPresentacionPowerPoint(string tema, string contenido)
    {
        string carpeta = @"C:\Users\ASUS\OneDrive\Documentos\Ing en sistemas 1 semsetre\Tercer semestre\Programacion 1\programas\proyecto 1 programacion\Investigaciones";
        Directory.CreateDirectory(carpeta);

        string rutaArchivo = Path.Combine(carpeta, $"{tema.Replace(" ", "_")}.pptx");

        using (PresentationDocument presentationDocument = PresentationDocument.Create(rutaArchivo, DocumentFormat.OpenXml.PresentationDocumentType.Presentation))
        {
            PresentationPart presentationPart = presentationDocument.AddPresentationPart();
            presentationPart.Presentation = new Presentation();
            SlideMasterPart slideMasterPart = presentationPart.AddNewPart<SlideMasterPart>();
            slideMasterPart.SlideMaster = new SlideMaster(new CommonSlideData(new ShapeTree()));

            SlideLayoutPart slideLayoutPart = slideMasterPart.AddNewPart<SlideLayoutPart>();
            slideLayoutPart.SlideLayout = new SlideLayout(new CommonSlideData(new ShapeTree()));

            slideMasterPart.SlideMaster.Append(new SlideLayoutIdList(
                new SlideLayoutId() { Id = 1, RelationshipId = slideMasterPart.GetIdOfPart(slideLayoutPart) }));

            SlideIdList slideIdList = new SlideIdList();
            presentationPart.Presentation.Append(slideIdList);

            uint slideId = 256;

            // Título
            SlidePart titleSlidePart = presentationPart.AddNewPart<SlidePart>();
            titleSlidePart.Slide = new Slide(new CommonSlideData(new ShapeTree()));
            slideIdList.Append(new SlideId() { Id = slideId++, RelationshipId = presentationPart.GetIdOfPart(titleSlidePart) });

            var titleTree = titleSlidePart.Slide.CommonSlideData.ShapeTree;
            titleTree.Append(CreateTextShape("Investigación sobre: " + tema, 200000, 200000, 6000000, 1000000, 4400));
            titleSlidePart.Slide.Save();

            // Contenido (1 párrafo por diapositiva)
            string[] parrafos = contenido.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string parrafo in parrafos)
            {
                SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
                slidePart.Slide = new Slide(new CommonSlideData(new ShapeTree()));
                slideIdList.Append(new SlideId() { Id = slideId++, RelationshipId = presentationPart.GetIdOfPart(slidePart) });

                var shapeTree = slidePart.Slide.CommonSlideData.ShapeTree;
                shapeTree.Append(CreateTextShape(parrafo.Trim(), 200000, 200000, 6000000, 1000000, 3000));

                slidePart.Slide.Save();
            }

            presentationPart.Presentation.Save();
        }

        System.Windows.Forms.MessageBox.Show("Presentación PowerPoint generada correctamente en: " + rutaArchivo);
    }


    private P.Shape CreateTextShape(string text, int offsetX, int offsetY, int width, int height, int fontSize)
    {
        return new P.Shape(
            new P.NonVisualShapeProperties(
                new P.NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "TextBox" },
                new P.NonVisualShapeDrawingProperties(new A.ShapeLocks() { NoGrouping = true }),
                new ApplicationNonVisualDrawingProperties()
            ),
            new P.ShapeProperties(
                new A.Transform2D(
                    new A.Offset() { X = offsetX, Y = offsetY },
                    new A.Extents() { Cx = width, Cy = height })
            ),
            new P.TextBody(
                new A.BodyProperties(),
                new A.ListStyle(),
                new A.Paragraph(
                    new A.Run(
                        new A.RunProperties() { FontSize = fontSize },
                        new A.Text(text)
                    )
                )
            )
        );
    }
}
