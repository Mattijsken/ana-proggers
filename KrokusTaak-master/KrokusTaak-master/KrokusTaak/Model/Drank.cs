using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class Drank
    {

        public enum DrankTypes
        {
            Frisdrank,
            Alcoholisch,
            Warm,
            Water
        }

        public string Naam { get; set; }
        public DrankTypes DrankType { get; set; }
    }
}
