using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        public enum Gender
        {
            Male = 1,
            Female = 2
        }

        static void Main(string[] args)
        {
            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        }
    }
}
