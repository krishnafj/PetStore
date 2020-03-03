using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Models
{
    public class Pet
    {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public Tag[] tags { get; set; }
        public string status { get; set; }
    }
}
