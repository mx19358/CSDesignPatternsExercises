using T5_2_5_Interfaces;

List<IBelonging> belongings = new()
{
    new Bench("Teak Bench", 6, GardenLocation.Patio),
    new GardenPlant("Silver Birch", GardenLocation.Bed, "Full sun"),
    new GardenPlant("Mint", GardenLocation.Pot, "Regular watering"),
    new Sofa("Two seater sofa", 4, RoomName.Kitchen),
    new Sofa("Four seater sofa", 6, RoomName.LivingRoom),
    new HousePlant("Venus Fly Trap", RoomName.Bedroom, "Needs mosquitos"),
};



Console.WriteLine("All Items");
Console.WriteLine("---------");

foreach (var belonging in belongings)
{
    Console.WriteLine(belonging); // remember that this is implicitly calling item.ToString()
}

Console.WriteLine();





Console.WriteLine("Garden Items");
Console.WriteLine("------------");

foreach (var belonging in belongings)
{
    if (belonging is IGardenItem gardenItem) //casting belonging to gardenItem
    {
        Console.WriteLine($"{belonging.Name} belongs at {gardenItem.GardenLocation}"); // remember that this is implicitly calling item.ToString()
    }
}

Console.WriteLine();





Console.WriteLine("Indoor Furniture");
Console.WriteLine("----------------");

// uses LINQ - more on this later
foreach (var belonging in belongings.Where(x => x is IIndoorItem && x is IFurnitureItem)) //
{
    Console.WriteLine(belonging); // remember that this is implicitly calling item.ToString()
}
//belongings.Where(x => x is IIndoorItem && x is IFurnitureItem)).ToList().ForEach(x => Console.WriteLine(x)) --> example of using LINQ for functional programming ( a lot faster and more powerful than for loop presented)

Console.WriteLine();





Console.ReadKey();