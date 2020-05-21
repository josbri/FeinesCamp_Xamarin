using System;
using System.Collections;
using System.Collections.Generic;

namespace FeinesCamp.Model
{
    public class Client
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Land> Land { get; set; }

        public int UserID { get; set; }

        public Client()
        {
        }
    }
}
