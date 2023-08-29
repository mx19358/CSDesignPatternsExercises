using T5_2_4_ClassAndStruct;

List<Vehicle> vehicles = new()
{
    new Motorbike("Ducati"),
    new Motorbike("Honda"),
    new Car("Mini", Transmission.Manual),
    new Car("Kia", Transmission.Automatic),
    new Truck("White", TruckType.Van),
    new Truck("Volvo", TruckType.Articulated),
};

foreach (var vehicle in vehicles)
{
    Console.WriteLine(vehicle); // this implicitly calls the ToString() method of the vehicle in question - method can be overridden if you specify
}

Console.WriteLine();




// Notice the two different options for declaring and setting a class/struct.
var testClass = new TestClass() { Value = "class text" };
TestStruct testStruct = new() { Value = "struct text" };

Console.WriteLine($"Class: {testClass.Value}, Struct: {testStruct.Value}");

MessWithValues(testClass, testStruct);

Console.WriteLine($"Class: {testClass.Value}, Struct: {testStruct.Value}");




Console.ReadKey();

static void MessWithValues(TestClass testClass, TestStruct testStruct)
{
    testClass.Value = "Messed With";
    testStruct.Value = "Messed With";
}
