using T5_2_5_Interfaces; //Add --> Project Reference (uses interfaces from this namespace)
using T5_2_6_Generics; //defines namespace to be used

BelongingList<IBelonging> belongings = new()
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





Console.WriteLine("Indoor Items");
Console.WriteLine("------------");
Console.WriteLine($"{belongings.IndoorItemCount()} items:");

foreach (var indoorItem in belongings.IndoorItems())
{
    Console.WriteLine(indoorItem); // remember that this is implicitly calling item.ToString()
}

Console.WriteLine();





Console.ReadKey();