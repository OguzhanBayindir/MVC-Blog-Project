using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Common;
using Blog.Entity;
using Blog.Entity.Model;

namespace Blog.Repository
{
    public class CategoryRepository : DataRepository<Category, int>
    {

        BlogContext database = Tools.GetConnection();
        ResultProcess<Category> result = new ResultProcess<Category>();

        public override Result<int> Delete(int id)
        {
            Category toDelete = database.Categories.SingleOrDefault(x => x.CategoryID == id);

            database.Categories.Remove(toDelete);

            return result.GetResult(database);

        }

        public override Result<List<Category>> GetLatestObject(int Quantity)
        {
            return result.GetListResults(database.Categories.OrderByDescending(t => t.CategoryID).Take(Quantity).ToList());
        }

        public override Result<Category> GetObjectByID(int id)
        {
            Category selected = database.Categories.SingleOrDefault(x => x.CategoryID == id);

            return result.GetT(selected);

        }

        public override Result<int> Insert(Category item)
        {
            database.Categories.Add(item);

            return result.GetResult(database);

        }

        public override Result<List<Category>> List()
        {
            return result.GetListResults(database.Categories.ToList());

        }

        public override Result<int> Update(Category item)
        {
            Category toUpdate = database.Categories.SingleOrDefault(x => x.CategoryID == item.CategoryID);

            toUpdate.CategoryName = item.CategoryName;
            toUpdate.CategoryPhoto = item.CategoryPhoto;
            toUpdate.CategoryDescription = item.CategoryDescription;


            return result.GetResult(database);

        }
    }
}
