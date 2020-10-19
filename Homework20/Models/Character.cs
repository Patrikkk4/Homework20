using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework20.Models
{
    public class Character
    {
        public string Image { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public Character(string image, string name, string bio)
        {
            Image = image;
            Name = name;
            Bio = bio;
        }

        public Character()
        {
        }
    }
}
