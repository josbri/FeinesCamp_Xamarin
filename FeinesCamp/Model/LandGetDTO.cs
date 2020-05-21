using System;
namespace FeinesCamp.Model
{
    public class LandGetDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int ClientID { get; set; }

        public ClientGetDTO Client { get; set; }

        public LandGetDTO()
        {
        }
    }
}
