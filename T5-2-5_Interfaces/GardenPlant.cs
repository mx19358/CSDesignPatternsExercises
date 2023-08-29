using System;
using System.Xml.Linq;

namespace T5_2_5_Interfaces;


/// <summary>
/// A garden plant
/// </summary>
public class GardenPlant : IGardenItem, IPlant //you can only inherit from one class (in this case IGardenItem as it's the first one after the colon ??), it has inherited 2 interfaces
{
    public string Name { get; set; }
    public GardenLocation GardenLocation { get; set; }
    public string PreferredConditions { get; set; }

    public GardenPlant(string name, GardenLocation gardenLocation, string preferredConditions)
    {
        Name = name;
        GardenLocation = gardenLocation;
        PreferredConditions = preferredConditions;
    }

    public override string ToString()
    {
        return $"Garden Plant - {Name}, {GardenLocation}, {PreferredConditions}";
    }
}

