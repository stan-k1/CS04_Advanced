using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CS04_Advanced
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Colors;

        public string this[int c]
        {
            get => Colors[c];
            set => Colors.Insert(c, value);
        }

        public string this[float b]
        {
            get => Colors[(int)b]+"from float";
            set => Colors.Insert((int)b, value + " from float");
        }

        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }




    }
}
