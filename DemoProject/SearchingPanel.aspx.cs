using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoProject
{
    public partial class SearchingPanel : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelNoRecords.Text = "";
        }      

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SearchingPanel?Factory=" + TextBoxFactory.Text);
        }

        public IQueryable<CarsTable> carsGrid_GetData([QueryString] string factory)
        {
            SampleDatabaseEntities db = new SampleDatabaseEntities();
            var allRows = db.CarsTables.Select(x => x).Where(x => x.Factory == factory);

            //checking if button clicked to avoid message on page load
            if (allRows.Count()==0 && ClientQueryString.Count() > 0)
            {
                LabelNoRecords.Text = "<br />No records found";
            }

            return allRows;
        }
    }
}