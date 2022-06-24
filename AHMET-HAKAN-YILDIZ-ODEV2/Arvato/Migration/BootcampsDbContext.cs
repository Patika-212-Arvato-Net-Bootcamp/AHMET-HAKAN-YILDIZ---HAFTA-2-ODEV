using Arvato.Model;

namespace Arvato.Migration
{
    public class BootcampsDbContext
    {
        public static List<Bootcamp> Bootcamps = new List<Bootcamp>()
        {
            new Bootcamp
            {
                Id = 1,
                Subject=".Net Core",
                Company="Arvato",
                Beginning=new DateTime(2022,05,16),
                Finish=new DateTime(2022,05,27),
                ActPass=false
            },

            new Bootcamp
            {
                Id = 2,
                Subject="Node.js",
                Company="Yemeksepeti",
                Beginning=new DateTime(2022,06,16),
                Finish=new DateTime(2022,06,27),
                ActPass=false
            },

             new Bootcamp
            {
                Id = 3,
                Subject="Machine Learning With Python",
                Company="Google",
                Beginning=new DateTime(2022,07,16),
                Finish=new DateTime(2022,07,27),
                ActPass=true
            },

             new Bootcamp
            {
                Id = 4,
                Subject="Front End",
                Company="Trendyol",
                Beginning=new DateTime(2022,07,16),
                Finish=new DateTime(2022,07,29),
                ActPass=true
            }
        };
    }
}
