using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class Persoon
    {
        public string VoorNaam { get; set; } = "";
        public string AchterNaam { get; set; } = "";
        public string Adres { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefoon { get; set; } = "";
        public DateTime dateAdded { get; set; }
    }
}