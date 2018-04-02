using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace DemoProject
{
    public partial class ExportDbContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SerializeButton_Click(object sender, EventArgs e)
        {
            GetRows();
        }

        /// <summary>
        /// Gathering db content into list of objects
        /// </summary>
        protected void GetRows()
        {
            List<Car> rows = new List<Car>();
            using (SampleDatabaseEntities db = new SampleDatabaseEntities())
            {
                try
                {
                    foreach (var item in db.CarsTables)
                    {
                        rows.Add(new Car(item.Factory, item.Model, (int)item.Warranty, (DateTime)item.ModelYear));
                    }                   
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Problem with db export: " + ex.Message;
                }
                
                Serialize(rows);
            }
        }

        /// <summary>
        /// Serializing into xml file on server
        /// </summary>
        /// <param name="rows"></param>
        protected void Serialize(List<Car> rows)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));            
            string filename = String.Format("{0:dd_MM_yyyy_HH_mm_ss}", DateTime.Now) + "_export.xml";
            string path = Server.MapPath("~/UserFiles/") + filename;

            using (TextWriter writer = new StreamWriter(path))
            {
                try
                {
                    serializer.Serialize(writer, rows);
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Problem with XML serialization: " + ex.Message;
                }
            }                        
            DonwloadFileToClient(path);
            Finalization(path);
        }

        /// <summary>
        /// Download file to client computer; removing xml file from server
        /// </summary>
        /// <param name="path"></param>
        protected void DonwloadFileToClient(string path)
        {            
            try
            {
                FileInfo file = new FileInfo(path);
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.Flush();
                file.Delete();
                Response.End();                
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Problem with downloading XML: " + ex.Message;
            }
        }

        protected void Finalization(string path)
        {
            File.Delete(path);
            StatusLabel.Text = "Export XML completed!";            
        }
    }
}