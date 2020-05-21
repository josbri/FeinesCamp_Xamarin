using System;
namespace FeinesCamp.Model
{
    public class Tarea
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int LandID { get; set; }

        public LandGetDTO Land { get; set; }

        public string ClientName { get; set; }

        public int UserID { get; set; }
        public DateTime Created { get; set; }

        public DateTime Finished { get; set; }

        public string CommentPre { get; set; }
        public string CommentPro { get; set; }

        public bool Completed { get; set; }

        public bool Facturada { get; set; }
        public string Image { get; set; }

        public float Time { get; set; }
        public Tarea()
        {
        }
    }
}
