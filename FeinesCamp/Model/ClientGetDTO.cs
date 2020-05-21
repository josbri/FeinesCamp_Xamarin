using System;
using System.Collections.Generic;

namespace FeinesCamp.Model
{
    public class ClientGetDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<LandGetDTO> Land { get; set; }

        public int UserID { get; set; }

        public ClientGetDTO()
        {
        }
    }
}
