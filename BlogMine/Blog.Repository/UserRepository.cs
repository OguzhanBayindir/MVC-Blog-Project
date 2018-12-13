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
    public class UserRepository : DataRepository<User, int>
    {

        BlogContext database = Tools.GetConnection();
        ResultProcess<User> result = new ResultProcess<User>();

        public override Result<int> Delete(int id)
        {
            User toDelete = database.Users.SingleOrDefault(x => x.UserID == id);

            database.Users.Remove(toDelete);

            return result.GetResult(database);

        }

        public override Result<List<User>> GetLatestObject(int Quantity)
        {
            return result.GetListResults(database.Users.OrderByDescending(t => t.UserID).Take(Quantity).ToList());
        }

        public override Result<User> GetObjectByID(int id)
        {
            User selected = database.Users.SingleOrDefault(x => x.UserID == id);

            return result.GetT(selected);

        }

        public override Result<int> Insert(User item)
        {
            database.Users.Add(item);

            return result.GetResult(database);

        }

        public override Result<List<User>> List()
        {
            return result.GetListResults(database.Users.ToList());

        }

        public override Result<int> Update(User item)
        {
            User toUpdate = database.Users.SingleOrDefault(x => x.UserID == item.UserID);

            toUpdate.Password = item.Password;
            toUpdate.Fullname = item.Fullname;
            toUpdate.Photo = item.Photo;
            toUpdate.UserRoleId = item.UserRoleId;

            return result.GetResult(database);

        }
    }
}
