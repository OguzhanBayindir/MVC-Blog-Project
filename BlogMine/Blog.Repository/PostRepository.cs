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
    public class PostRepository : DataRepository<Post, int>
    {

        BlogContext database = Tools.GetConnection();
        ResultProcess<Post> result = new ResultProcess<Post>();

        public override Result<int> Delete(int id)
        {
            Post toDelete = database.Posts.SingleOrDefault(x => x.PostID == id);

            database.Posts.Remove(toDelete);

            return result.GetResult(database);

        }

        public override Result<List<Post>> GetLatestObject(int Quantity)
        {
            return result.GetListResults(database.Posts.OrderByDescending(t => t.PostID).Take(Quantity).ToList());
        }

        public override Result<Post> GetObjectByID(int id)
        {
            Post selected = database.Posts.SingleOrDefault(x => x.PostID == id);

            return result.GetT(selected);

        }

        public override Result<int> Insert(Post item)
        {
            database.Posts.Add(item);

            return result.GetResult(database);

        }

        public override Result<List<Post>> List()
        {
            return result.GetListResults(database.Posts.ToList());

        }

        public override Result<int> Update(Post item)
        {
            Post toUpdate = database.Posts.SingleOrDefault(x => x.PostID == item.PostID);

            toUpdate.PostContent = item.PostContent;
            toUpdate.Title = item.Title;
            toUpdate.PostDate = item.PostDate;
            toUpdate.Photo = item.Photo;
            toUpdate.PostExcerpt = item.PostExcerpt;
            toUpdate.UserId = item.UserId;
            toUpdate.CategoryId = item.CategoryId;

            return result.GetResult(database);

        }
        //static char[] breakCharacters = new char[] { '!', ',', '?', '.', ' ' };

        //public static string ReturnExcerpt(string input)

        //{
        //    int wordsLimit = 30;

        //    string excerpt = "";
            
        //    while (excerpt.Length < 30)
        //    {
        //        foreach (var item in input.Split(breakCharacters))
        //        {
        //            excerpt = excerpt + item + " ";

        //            if (excerpt.Length >= 30)
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    return excerpt + "...";
        //}
    }
}
