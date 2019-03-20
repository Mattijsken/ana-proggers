using System;

namespace KrokusTaak
{
    public class Werknemer : Persoon
    {

        public Werknemer()
        {
        }
            public Werknemer( string csvLine)
        {
            string[] values = csvLine.Split(';');
            VoorNaam = Convert.ToString(values[0]);
            AchterNaam = Convert.ToString(values[1]);
            Adres = Convert.ToString(values[2]);
            Email = Convert.ToString(values[3]);
            Telefoon = Convert.ToString(values[4]);
            dateAdded = Convert.ToDateTime(values[5]);
        }
    }
}