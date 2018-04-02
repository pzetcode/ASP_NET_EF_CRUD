using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoProject
{
    public partial class AddCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addCar_InsertItem()
        {
            var item = new CarsTable();

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                using (SampleDatabaseEntities db = new SampleDatabaseEntities())
                {
                    db.CarsTables.Add(item);
                    db.SaveChanges();
                }
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DbcontentGridView.aspx");
        }

        protected void addCar_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/DbcontentGridView.aspx");
        }
    }
}