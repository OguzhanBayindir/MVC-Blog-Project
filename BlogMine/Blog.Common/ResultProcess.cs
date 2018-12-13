using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Common
{
    public class ResultProcess<T>
    {
        public Result<int> GetResult(BlogContext database)
        {
            Result<int> result = new Result<int>();



            int sonuc = database.SaveChanges();

            if (sonuc > 0)
            {
                result.IsSucceeded = true;
                result.ProcessResult = sonuc;
                result.UserMessage = "Succesful";

            }

            else
            {
                result.IsSucceeded = false;
                result.ProcessResult = sonuc;
                result.UserMessage = "Not succesful";

            }

            return result;

        }

        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();

            if (data != null)
            {
                result.IsSucceeded = true;
                result.ProcessResult = data;
                result.UserMessage = "Successful..";

            }
            else
            {
                result.IsSucceeded = false;
                result.ProcessResult = data;
                result.UserMessage = "Not succesful";


            }

            return result;
        }

        public Result<List<T>> GetListResults(List<T> data)

        {
            Result<List<T>> result = new Result<List<T>>();

            if (data != null)
            {
                result.IsSucceeded = true;
                result.ProcessResult = data;
                result.UserMessage = "Succesful";

            }

            else
            {
                result.IsSucceeded = false;
                result.ProcessResult = data;
                result.UserMessage = "Not succesful";

            }

            return result;
        }



    }
}
