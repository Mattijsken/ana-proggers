using System;
using System.Collections.Generic;

namespace KrokusTaak
{
    public class Klant : Persoon
    {

        public Klant()
        {
        }
        public Klant(string csvLine)
        {
            string[] values = csvLine.Split(';');
            string[] ingredienten = values[1].Split(',');
            List<Ingredient> ingredientenLijst = new List<Ingredient>();
            for (int i = 0; i < ingredienten.Length; i++)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.Name = ingredienten[i];
                ingredientenLijst.Add(ingredient);
            }

            KortingsCode= Convert.ToString(values[0]);
            Allergieen = ingredientenLijst;
            VoorNaam = Convert.ToString(values[2]);
            AchterNaam = Convert.ToString(values[3]);
            Adres = Convert.ToString(values[4]);
            Email = Convert.ToString(values[5]);
            Telefoon = Convert.ToString(values[6]);
            dateAdded = Convert.ToDateTime(values[7]);

        }
        public string KortingsCode { get; set; }
        public List<Ingredient> Allergieen { get; set; }
    }
}