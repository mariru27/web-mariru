using ITEC_WebApp.Models;
using System.Linq;

namespace ITEC_WebApp.Data
{
    public class Initializator
    {
        public static void Init(ContextITEC context)
        {
            context.Database.EnsureCreated();
            if (context.Test.Any())
            {
                return;
            }


            Test test = new Test { Name = "edw" };
            context.Test.Add(test);
            context.SaveChanges();

        }


    }
}
