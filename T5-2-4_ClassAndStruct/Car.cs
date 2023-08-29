using System;
namespace T5_2_4_ClassAndStruct;

// in line documentation
/// <summary>
/// A standard car.
/// </summary>
public sealed class Car : Vehicle //car inherits from vehicle in this line using the colon (it is the child of vehicle)
{
    // Implementing a getter as a function.
    public override string VehicleType
    {
        get
        {
            return "Car";
        }
    }

    // Impementing a getter with a Lamda.
    public override int NumberOfWheels => 4;

    //private field (lower cases) under a Public property (upper case)
    private readonly Transmission transmission; // no get/set : therefore = field (otherwise = priperty)
    public override Transmission Transmission
    {
        get
        {
            return transmission;
        }
    }

    public Car(string name, Transmission transmission) : base(name) //constructor as does not have the tostring 
    {
        this.transmission = transmission;
    }

    public override string ToString()
    {
        return $"{VehicleType} - {Name} ({Transmission})";
    }
}
