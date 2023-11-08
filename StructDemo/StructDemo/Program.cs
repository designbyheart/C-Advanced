using System;
using System.Collections;

namespace StructDemo
{

    struct Coffee
    {
        private double price = 0;
        private int coffeeID = 0;

        public string Name { get; set; }
        public string Bean { get; set; }
        public string CountryOfOrigin { get; set; }

        public int Strength { get; set; }

        public Coffee(string name, string country, double price, string bean = "dark")
        {
            this.price = price;
            this.Name = name;
            this.Bean = bean;
            this.CountryOfOrigin = country;
        }

        public Coffee(int coffeeID, string bean, string country)
        {
            this.coffeeID = coffeeID;
            this.Bean = bean;
            this.Name = country;
            this.CountryOfOrigin = country;
        }

        public static double CalculateOrder(Coffee[] coffeeList)
        {
            double price = 0;
            foreach (Coffee coffee in coffeeList)
            {
                price += coffee.price;
            }
            return price;
        }
    }

    enum TravelMethod {
       Walk, Horseback

    }
    class  Character
    {
        public Character() { 
        
        }

        public string Class = "Character";
        public int Level = 1;
        public int HitPoints = 0;
        public TravelMethod TravelMethod = TravelMethod.Walk;

        public void Describe(TravelMethod tipTransporta) {
            this.TravelMethod = tipTransporta;
            Console.WriteLine("You're traveling to your destination on {0}.",  tipTransporta);
        }
    }
    class Program
    {
        static public void Main()
        {
            var character = new Character
            {
                Class = "Wizard",
                Level = 4,
                HitPoints = 28
            };

        }


        public void ArrayListDemo()
        {
            // Create a new ArrayList collection.
            ArrayList beverages = new();
            var beverages2 = new ArrayList();

            // Create some items to add to the collection.
            Coffee coffee1 = new Coffee(4, "Arabica", "Columbia");
            Coffee coffee2 = new Coffee(3, "Arabica", "Vietnam");
            Coffee coffee3 = new Coffee(4, "Robusta", "Indonesia");
            // Add the items to the collection.
            // Items are implicitly cast to the Object type when you add them. beverages.Add(coffee1);
            beverages.Add(coffee2);
            beverages.Add(coffee3);
            // Retrieve items from the collection.
            // Items must be explicitly cast back to their original type. Coffee firstCoffee = (Coffee)beverages[0];
            Coffee secondCoffee = (Coffee)beverages[1];
        }

        public void HashDemo() {
            // Create a new Hashtable collection.
            Hashtable ingredients = new Hashtable();
            // Add some key/value pairs to the collection. ingredients.Add("Café au Lait", "Coffee, Milk"); ingredients.Add("Café Mocha", "Coffee, Milk, Chocolate"); ingredients.Add("Cappuccino", "Coffee, Milk, Foam"); ingredients.Add("Irish Coffee", "Coffee, Whiskey, Cream, Sugar"); ingredients.Add("Macchiato", "Coffee, Milk, Foam");
            // Check whether a key exists.
            if (ingredients.ContainsKey("Café Mocha"))
            {
                // Retrieve the value associated with a key.
                Console.WriteLine("The ingredients of a Café Mocha are: {0}", ingredients["Café Mocha"]);
            }

            foreach (string key in ingredients.Keys)
            {
                Console.WriteLine(ingredients[key]);
            }

        }
    }
}