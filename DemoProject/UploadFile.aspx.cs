using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DemoProject
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                string path = null;
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/UserFiles/") + filename);
                    path = Server.MapPath("~/UserFiles/") + filename;
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "The file could not be uploaded. The following error occured: " + ex.Message;
                }
                
                ParseXml(path);
            }
        }

        /// <summary>
        /// Parsing xml; creating collection of objects
        /// </summary>
        /// <param name="path"></param>
        protected void ParseXml(string path)
        {
            IEnumerable<Car> rows = null; 
            try
            {
                XDocument doc = XDocument.Load(path);
                rows = from c in doc.Descendants("Car")
                                                    select new Car(
                                                         (string)c.Element("Factory").Value,
                                                         (string)c.Element("Model").Value,
                                                         (int)c.Element("Warranty"),
                                                         (DateTime)c.Element("Modelyear")
                                                        );             
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Problem with load XML content: " + ex.Message;
            }
            finally
            {
                File.Delete(path);
            }

            InsertRows(rows);
        }

        /// <summary>
        /// Inserting new rows into database
        /// </summary>
        /// <param name="rows"></param>
        protected void InsertRows(IEnumerable<Car> rows)
        {
            using (SampleDatabaseEntities db = new SampleDatabaseEntities())
            {
                try
                {
                    foreach (var item in rows)
                    {
                        CarsTable carsTable = new CarsTable();
                        carsTable.Factory = item.Factory;
                        carsTable.Model = item.Model;
                        carsTable.Warranty = item.Warranty;
                        carsTable.ModelYear = DateTime.Now;
                        db.CarsTables.Add(carsTable);
                    }

                    db.SaveChanges();
                    StatusLabel.Text = "Import success!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Problem with import: " + ex.Message;
                }
            }
        }
    }
}