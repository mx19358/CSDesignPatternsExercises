Random random = new(); // Random = class type 
int randomNumber = random.Next(1, 11); //random number between including 1 and ex

// if ... else statement #1 - note that you don't need the else bit.
Console.Write($"{randomNumber} is "); //write means that next time you write it keeps it on the same line 

if (randomNumber % 2 != 1) // % = modulus --> modulus 2 tests for odd or even
{
    Console.WriteLine("even.");
}   // bracing allows you to have multiple lines of code in an if statement --> standard for single line if statements too
else
{
    Console.WriteLine("odd.");
}

Console.WriteLine();




// if ... else if ... else statement.
Console.Write($"{randomNumber} is ");

if (randomNumber >= 6)
{
    Console.WriteLine("greater than or equal to six.");
}
else if (randomNumber % 2 == 0)
{
    Console.WriteLine("less than six and even.");
}
else if (randomNumber >= 4)
{
    Console.WriteLine("greater than 4.");
}
else
{
    Console.WriteLine("less than six and odd.");
}

Console.WriteLine();




// if statement testing a boolean value directly = note how you don't need a comparison operator to ask if it's true.
bool boolean = randomNumber % 2 == 1;

Console.Write($"{randomNumber} is still ");

if (!boolean) // not boolean --> ! = not
{
    Console.WriteLine("even.");
}
else
{
    Console.WriteLine("odd.");
}

Console.WriteLine();





// switch statement.--> used in C
Console.Write($"{randomNumber} is ");

switch (randomNumber)
{
    case 1:
    case 2:
    case 3:
        Console.WriteLine("between one and three."); //
        break; //leave switch statement

    case 4:
    case 5:
    case 6:
        Console.WriteLine("between four and six.");
        break;

    default: //all other cases
        Console.WriteLine("big.");
        break;
}

Console.WriteLine();




// switch expression (C# 8 onwards). --> must define each case individually
var sentenceCompletion = randomNumber switch
{
    1 => "one.",
    2 => "two.",
    3 => "three.",
    _ => "who cares?" // underscore = default
};

Console.Write($"{randomNumber} is {sentenceCompletion}");

Console.WriteLine();




Console.ReadKey();
