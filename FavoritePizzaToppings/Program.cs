// read file into a string and deserialize JSON to a type
//Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"c:\movie.json"));

// deserialize JSON directly from a file
//using (StreamReader file = File.OpenText(@"c:\movie.json"))
//{
//    JsonSerializer serializer = new JsonSerializer();
//    Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
//}

using FavoritePizzaToppings;
using Newtonsoft.Json;

string result = File.ReadAllText("C:\\Users\\rkers\\source\\repos\\FavoritePizzaToppings\\FavoritePizzaToppings\\pizzas.json");
List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(result);



//using (StreamReader file= File.OpenText(@"C:\Users\rkers\source\repos\FavoritePizzaToppings\FavoritePizzaToppings\pizzas.json"))
//{
//    JsonSerializer serializer = new JsonSerializer();
//    var pizzas2 = serializer.Deserialize(file, typeof(List<Pizza>)) as List<Pizza>;
//}

 Dictionary<string, int> toppingsCounter = new Dictionary<string, int>();

pizzas.ForEach(pizza =>
{
    string toppingsAsString = String.Join(" & ", pizza.Toppings.OrderByDescending(x => x));

if (!toppingsCounter.ContainsKey(toppingsAsString))
    {
        toppingsCounter[toppingsAsString] = 1;
    }
else
    {
        toppingsCounter[toppingsAsString]++;
    };
});

//var mostPopularPizzaToppings = toppingsCounter.OrderByDescending(toppingCombo => toppingCombo.Value).Take(1).FirstOrDefault();
//var maxValue = toppingsCounter.Max();



////Console.WriteLine($" The most popular pizza is {mostPopularPizzaToppings.Key}, and it was ordered {mostPopularPizzaToppings.Value}");



int count = 0; 
foreach (var i in toppingsCounter.OrderByDescending(x => x.Value))
{
    if (count < 20)
    {
        Console.WriteLine($"{i.Key} was ordered {i.Value} times.");
        count++;
    }
    else
    {
        break;
    }
}









    Console.ReadLine();