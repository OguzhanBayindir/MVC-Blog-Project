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
    public class TagRepository : DataRepository<Tag, int>
    {

        BlogContext database = Tools.GetConnection();
        ResultProcess<Tag> result = new ResultProcess<Tag>();

        public override Result<int> Delete(int id)
        {
            Tag toDelete = database.Tags.SingleOrDefault(x => x.TagID == id);

            database.Tags.Remove(toDelete);

            return result.GetResult(database);

        }

        public override Result<List<Tag>> GetLatestObject(int Quantity)
        {
            return result.GetListResults(database.Tags.OrderByDescending(t => t.TagID).Take(Quantity).ToList());
        }

        public override Result<Tag> GetObjectByID(int id)
        {
            Tag selected = database.Tags.SingleOrDefault(x => x.TagID == id);

            return result.GetT(selected);

        }

        public override Result<int> Insert(Tag item)
        {
            database.Tags.Add(item);

            return result.GetResult(database);

        }

        public override Result<List<Tag>> List()
        {
            return result.GetListResults(database.Tags.ToList());

        }

        public override Result<int> Update(Tag item)
        {
            Tag toUpdate = database.Tags.SingleOrDefault(x => x.TagID == item.TagID);

            toUpdate.TagName = item.TagName;

            return result.GetResult(database);

        }
    }
}
