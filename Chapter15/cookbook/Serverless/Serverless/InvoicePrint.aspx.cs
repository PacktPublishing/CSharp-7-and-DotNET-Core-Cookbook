using System;
using System.Web.UI;
using DocRaptor.Client;
using DocRaptor.Model;
using DocRaptor.Api;
using System.IO;
using System.Net;
using System.Text;

namespace Serverless
{
    public partial class InvoicePrint : System.Web.UI.Page
    {
        public enum MessageType { Error, Warning }
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ToggleErrorDisplay(); TogglePrintResult();", true);
        }

        protected void lnkPrintInvoice_Click(object sender, EventArgs e)
        {
            bool blnPrinted = false;
            try
            {
                Configuration.Default.Username = "YOUR_API_KEY_HERE";
                DocApi docraptor = new DocApi();

                Doc doc = new Doc(
                  Test: true,
                  Name: "docraptor-csharp.pdf",
                  DocumentType: Doc.DocumentTypeEnum.Pdf,
                  DocumentContent: GetInvoiceContent()//,
                  //PrinceOptions: new PrinceOptions(Media: "screen")
                );

                byte[] create_response = docraptor.CreateDoc(doc);
                File.WriteAllBytes(@"C:\temp\invoiceDownloads\invoice.pdf", create_response);
                blnPrinted = true;
            }
            catch (Exception ex) when (!blnPrinted)
            {
                AlertMessage(ex.Message, MessageType.Error);
            }
            finally
            {
                if (blnPrinted)
                {
                    lblPrintDetails.Text = "Your Invoice has been printed.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "TogglePrintResult();", true);
                }
            }
        }

        private string GetInvoiceContent()
        {
            WebRequest req = WebRequest.Create("http://localhost:37464/invoice.html");
            WebResponse resp = req.GetResponse();
            Stream st = resp.GetResponseStream();
            StreamReader sr = new StreamReader(st, Encoding.ASCII);
            return sr.ReadToEnd();
        }

        protected void AlertMessage(string messageDetails, MessageType messageType)
        {
            lblErrorDetails.Text = messageDetails;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ToggleErrorDisplay();", true);
        }
    }
}