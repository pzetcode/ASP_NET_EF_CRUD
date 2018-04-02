using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoProject
{
    public partial class Dbcontent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CarsTable> allRows = new List<CarsTable>();
            
            //gathering records
            using (SampleDatabaseEntities db = new SampleDatabaseEntities())
            {
                allRows = db.CarsTables.Select(x => x).ToList();
            }

            //feeding WebGrid
            WebGrid webGrid = new WebGrid(allRows, canPage: true, defaultSort: "Id", canSort: true, rowsPerPage: 5);
            dbRowsControl.Text = webGrid.GetHtml(
                columns: webGrid.Columns(
                    webGrid.Column("Id", "ID"),
                    webGrid.Column("Factory", "Company"),
                    webGrid.Column("Model", "Model"),
                    webGrid.Column("Warranty", "Warranty (years)"),
                    webGrid.Column("ModelYear", "Model Year", format: (item) => item.ModelYear.ToString("MM/yyyy"))
                    )
                ).ToString();
        }
    }
}