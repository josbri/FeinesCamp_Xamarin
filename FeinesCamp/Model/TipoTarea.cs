using System;
namespace FeinesCamp.Model
{
    public class TipoTarea
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string Image { get; set; }

        public TipoTarea()
        {
        }
    }
}
