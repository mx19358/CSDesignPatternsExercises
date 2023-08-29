using System;
namespace T5_2_4_ClassAndStruct;


/// <summary>
/// A standard motorbike.
/// </summary>
public sealed class Motorbike : Vehicle
{
    // Implementing a getter as a function.
    public override string VehicleType
    {
        get
        {
            return "Motorbike";
        }
    }

    // Impementing a getter with a Lamda.
    public override int NumberOfWheels => 2; // => is a POINTER (to aviod having to retype the 'get' ... part of the code

    public override Transmission Transmission => Transmission.Manual;


    public Motorbike(string name) : base(name)
    {
    }

    public override string ToString()
    {
        return $"{VehicleType} - {Name}";
    }
}

