using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    public class Recept
    {

        public Recept()
        {
        }
        public Recept(string csvLine)
        {
            string[] values = csvLine.Split(';');
            string[] ingredienten = values[2].Split(',');
            List<Ingredient> ingredientenLijst = new List<Ingredient>() ;
            for (int i = 0; i < ingredienten.Length; i++)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.Name = ingredienten[i];
                ingredientenLijst.Add(ingredient);
            }

            Naam = Convert.ToString(values[0]);
            ReceptType = (ReceptTypes) Enum.Parse(typeof(ReceptTypes), values[1]);
            Ingredients = ingredientenLijst;
            Werkwijze = Convert.ToString(values[3]);
          
        }

        public enum ReceptTypes
        {
            Voorgerecht,
            Soep,
            Hoofdgerecht,
            Dessert
        }

        public string Naam { get; set; }
        public ReceptTypes ReceptType { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Werkwijze { get; set; }
    }
}