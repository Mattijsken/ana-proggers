using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class DrankenBestand
    {
        public List<Drank> alleDranken { get; set; }

        public DrankenBestand()
        {
            alleDranken = new List<Drank>();
        }

        public void Add(Drank drank)
        {
            alleDranken.Add(drank);
        }

        public bool Remove(Drank drank)
        {
            return alleDranken.Remove(drank);
        }

        public Drank Find(string naam)
        {
            foreach (Drank drank in alleDranken)
            {
                if (drank.Naam.ToLower() == naam.ToLower())
                    return drank;
            }
            return null;
        }
    }
}
