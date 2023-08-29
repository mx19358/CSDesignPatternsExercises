// foreach loops are in the next tutorial.

// for loops
for (int i = 0; i < 10; i++) // for(starting condition ; running condition ; increase by 1) --> usually for loops don't use greater/less than OR EQUAL TO
{
    Console.Write($"{i} ");
}

Console.WriteLine();
Console.WriteLine();

for (int i = 10; i > 0; i--) // for(starting condition ; continuation condition ; decrease by 1)
{
    Console.Write($"{i} ");
}

Console.WriteLine();
Console.WriteLine();

for (int i = 0; i < 10; i += 2) // increases i by increments of 2
{
    Console.Write($"{i} ");
}

Console.WriteLine();
Console.WriteLine();



// while loops
char firstInput = ' ';

while (firstInput != 's')
{
    Console.Write("Press 's' to stop: ");
    firstInput = Console.ReadKey().KeyChar;
    Console.WriteLine();
}

Console.WriteLine();




// do loops
var secondInput = 's';

do
{
    Console.Write("Press 's' to stop: ");
    secondInput = Console.ReadKey().KeyChar;
    Console.WriteLine();
} while (secondInput != 's');

Console.WriteLine();




// oops
int count = 0;

while (true)
{
    Console.WriteLine($"Count: {count++:N0}");
}

Console.WriteLine();




Console.ReadKey();