using Blog.Common;
using Blog.Entity;
using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
    public class UserRoleRepository : DataRepository<UserRole, int>
    {
        BlogContext database = Tools.GetConnection();
        ResultProcess<UserRole> result = new ResultProcess<UserRole>();

        public override Result<int> Delete(int id)
        {
            UserRole toDelete = database.UserRoles.SingleOrDefault(x => x.UserRoleID == id);

            database.UserRoles.Remove(toDelete);

            return result.GetResult(database);

        }

        public override Result<List<UserRole>> GetLatestObject(int Quantity)
        {
            return result.GetListResults(database.UserRoles.OrderByDescending(t => t.UserRoleID).Take(Quantity).ToList());
        }

        public override Result<UserRole> GetObjectByID(int id)
        {
            UserRole selected = database.UserRoles.SingleOrDefault(x => x.UserRoleID == id);

            return result.GetT(selected);

        }

        public override Result<int> Insert(UserRole item)
        {
            database.UserRoles.Add(item);

            return result.GetResult(database);

        }

        public override Result<List<UserRole>> List()
        {
            return result.GetListResults(database.UserRoles.ToList());

        }

        public override Result<int> Update(UserRole item)
        {
            UserRole toUpdate = database.UserRoles.SingleOrDefault(x => x.UserRoleID == item.UserRoleID);

            toUpdate.Rolename = item.Rolename;

            return result.GetResult(database);

        }
    }
}
