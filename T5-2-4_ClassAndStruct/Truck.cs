using System;
namespace T5_2_4_ClassAndStruct;


/// <summary>
/// A truck that's either a van or articulated lorry.
/// </summary>
public sealed class Truck : Vehicle
{
    /// <summary>
    /// The type of truck.
    /// </summary>
    public TruckType TruckType { get; private set; } // public TruckType(type) defines the property TruckType // get method retrieves the field behind // field value is set in constructor


    // Implementing a getter as a function.
    public override string VehicleType
    {
        get
        {
            return TruckType switch
            {
                TruckType.Van => "Van",
                TruckType.Articulated => "Articulated Lorry",
                _ => throw new NotImplementedException(),
            };
        }
    }

    // Impementing a getter with a function.
    public override int NumberOfWheels
    {
        get
        {
            return TruckType switch
            {
                TruckType.Van => 4,
                TruckType.Articulated => 10,
                _ => throw new NotImplementedException(),
            };
        }
    }

    public override Transmission Transmission => Transmission.Automatic;


    public Truck(string name, TruckType truckType) : base(name)
    {
        this.TruckType = truckType;
    }

    public override string ToString()
    {
        return $"{VehicleType} - {Name} with {NumberOfWheels} wheels";
    }
}
