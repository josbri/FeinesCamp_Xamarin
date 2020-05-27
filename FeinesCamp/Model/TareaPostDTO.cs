using System;
namespace FeinesCamp.Model
{
    public class TareaPostDTO
    {

        public string Name { get; set; }

        public int LandID { get; set; }


        public string ClientName { get; set; }

        public int UserID { get; set; }

        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }

        public string CommentPre { get; set; }
        public string CommentPost { get; set; }

        public string Material { get; set; }
        public bool Completed { get; set; }

        public string Image { get; set; }

        public float Time { get; set; }

        public TareaPostDTO()
        {
        }
    }
}
