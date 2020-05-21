using System;
namespace FeinesCamp.Model
{
    public class Land
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public int ClientID { get; set; }

        public Client Client { get; set; }

        public Land()
        {
        }
    }
}
