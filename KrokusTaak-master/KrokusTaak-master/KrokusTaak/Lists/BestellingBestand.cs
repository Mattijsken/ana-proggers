using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class BestellingBestand
    {
        public List<Bestelling> alleBestellingen { get; set; }

        public BestellingBestand()
        {
            alleBestellingen = new List<Bestelling>();
        }

        public void Add(Bestelling bestelling)
        {
            alleBestellingen.Add(bestelling);
        }

        public bool Remove(Bestelling bestelling)
        {
            return alleBestellingen.Remove(bestelling);
        }

        public Bestelling Find(int ID)
        {
            foreach (Bestelling bestelling in alleBestellingen)
            {
                if (bestelling.ID == ID)
                    return bestelling;
            }

            return null;
        }
    }
}
