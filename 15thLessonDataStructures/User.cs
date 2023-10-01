using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15thLessonDataStructures
{
    internal class User
    {
        private string _name;
        
        public User(string name = "John")
        {
            _name = name;
        }

        public string Name => _name;

    }
}
