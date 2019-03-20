using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class KlantenBestand
    {
        public List<Klant> alleKlanten { get; set; }


        public KlantenBestand()
        {
            alleKlanten = new List<Klant>();
        }

        public void Add(Klant klant)
        {
            alleKlanten.Add(klant);
        }

        public bool Remove(Klant klant)
        {
            return alleKlanten.Remove(klant);
        }

        public Klant Find(string achternaam)
        {
            foreach (Klant klant in alleKlanten)
            {
                if (klant.AchterNaam.ToLower() == achternaam.ToLower())
                    return klant;
            }
            return null;
        }
    }
}
