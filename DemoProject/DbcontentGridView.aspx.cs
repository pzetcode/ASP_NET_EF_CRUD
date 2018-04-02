using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoProject
{
    public partial class DbcontentGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Feeding grid with db rows
        /// </summary>
        /// <returns></returns>
        public IQueryable<CarsTable> carsGrid_GetData()
        {            
            SampleDatabaseEntities db = new SampleDatabaseEntities();
            var allRows = db.CarsTables.Select(x => x);
            return allRows;
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="Id"></param>
        public void carsGrid_UpdateItem(int Id)
        {
            using (SampleDatabaseEntities db = new SampleDatabaseEntities())
            {
                CarsTable item = null;
                item = db.CarsTables.Find(Id);
                if (item == null)
                {
                    ModelState.AddModelError("",
                      String.Format("Update issue: item id {0} not found in database.", Id));
                    return;
                }

                //UpdateModel(item);
                TryUpdateModel(item);
                
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deleting item
        /// </summary>
        /// <param name="Id"></param>
        public void carsGrid_DeleteItem(int Id)
        {
            using (SampleDatabaseEntities db = new SampleDatabaseEntities())
            {
                var item = new CarsTable { Id = Id };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Delete issue: item id {0} not found in database.", Id));
                }
            }
        }
    }
}