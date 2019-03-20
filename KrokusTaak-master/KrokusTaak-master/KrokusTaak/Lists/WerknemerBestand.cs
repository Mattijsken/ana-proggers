using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class WerknemerBestand
    {
        public List<Werknemer> alleWerknemers { get; set; }

        public WerknemerBestand()
        {
            alleWerknemers = new List<Werknemer>();
        }
        public void Add(Werknemer werknemer)
        {
            alleWerknemers.Add(werknemer);
        }

        public bool Remove(Werknemer werknemer)
        {
            return alleWerknemers.Remove(werknemer);
        }

        public Werknemer Find(string achternaam)
        {
            foreach (Werknemer persoon in alleWerknemers)
            {
                if (persoon.AchterNaam.ToLower() == achternaam.ToLower())
                    return persoon;
            }

            return null;
        }
    }
}