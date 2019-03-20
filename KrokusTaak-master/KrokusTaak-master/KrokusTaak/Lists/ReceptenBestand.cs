using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KrokusTaak.Recept;

namespace KrokusTaak
{
    public class ReceptenBestand
    {
        public List<Recept> alleRecepten { get; set; }

        public ReceptenBestand()
        {
            alleRecepten = new List<Recept>();
            Recept testRecept = new Recept();
            testRecept.Naam = "test";
            testRecept.ReceptType = ReceptTypes.Voorgerecht;
            Ingredient ingredient1 = new Ingredient();
            Ingredient ingredient2 = new Ingredient();
            ingredient1.Name = "test1"; 
            ingredient2.Name = "test2";
            testRecept.Ingredients = new List<Ingredient> { ingredient1, ingredient2};
            testRecept.Werkwijze = "test test";
            alleRecepten.Add(testRecept);

        }
        
        public void Add(Recept recept)
        {
            alleRecepten.Add(recept);
        }

        public bool Remove(Recept recept)
        {
            return alleRecepten.Remove(recept);
        }

        public Recept Find(string naam)
        {
            foreach(Recept recept in alleRecepten)
            {
                if (recept.Naam.ToLower() == naam.ToLower())
                    return recept;
            }
            return null;
        }


    }
}
