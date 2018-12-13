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
    public class CommentRepository : DataRepository<Comment, int>
    {

        BlogContext database = Tools.GetConnection();
        ResultProcess<Comment> result = new ResultProcess<Comment>();

        public override Result<int> Delete(int id)
        {
            Comment toDelete = database.Comments.SingleOrDefault(x => x.CommentID == id);

            database.Comments.Remove(toDelete);

            return result.GetResult(database);

        }

        public override Result<List<Comment>> GetLatestObject(int Quantity)
        {
            return result.GetListResults(database.Comments.OrderByDescending(t => t.CommentID).Take(Quantity).ToList());
        }

        public override Result<Comment> GetObjectByID(int id)
        {
            Comment selected = database.Comments.SingleOrDefault(x => x.CommentID == id);

            return result.GetT(selected);

        }

        public Result<Comment> GetObjectByPostIDAndUserID(int userId, int postId, int commentID)
        {
            Comment selected = database.Comments.SingleOrDefault(x => x.CommentID == commentID && x.PostId == postId && x.UserId == x.UserId);

            return result.GetT(selected);

        }

        public Result<List<Comment>> GetObjectByPostID(int id)
        {
            List<Comment> selectedComments = database.Comments.Where(x => x.PostId == id).ToList();

            return result.GetListResults(selectedComments);

        }

        public override Result<int> Insert(Comment item)
        {
            database.Comments.Add(item);

            return result.GetResult(database);

        }

        public override Result<List<Comment>> List()
        {
            return result.GetListResults(database.Comments.ToList());

        }

        public override Result<int> Update(Comment item)
        {
            Comment toUpdate = database.Comments.SingleOrDefault(x => x.CommentID == item.CommentID);

            toUpdate.CommentContent = item.CommentContent;
            toUpdate.CommentDate = item.CommentDate;

            return result.GetResult(database);

        }
    }
}
