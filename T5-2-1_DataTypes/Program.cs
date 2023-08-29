int int1 = 1;
int int2 = 2;
var result1 = int1 + int2;

Console.WriteLine($"{int1} + {int2} = {result1} and is of type '{result1.GetType()}'");

Console.WriteLine();




double double1 = 3.1415;
var result2 = double1 * int2;

Console.WriteLine($"{double1} * {int2} = {result2} and is of type '{result2.GetType()}'");

Console.WriteLine();




string str1 = "Simon";
var str2 = "Ziegler";
var result3 = str1 + str2;

Console.WriteLine($"'{str1}' + '{str2}' is '{result3}' and is of type '{result3.GetType()}'");

Console.WriteLine();




// This is an array, which is both a built in data type and a collection, which we will see in a later tutorial.
string[] names = { str1, str2 };
// Hover your mouse over the word "Join" to see VS intellisense explaining the Join method for you.
var result4 = string.Join(' ', names);

Console.WriteLine($"'{str1}' joined with the char ' ' with '{str2}' is '{result4}' and is of type '{result4.GetType()}'");

Console.WriteLine();


Console.WriteLine($" {names[0]} {names[^1]}"); // if you want to return: the first value = 0 ; the last value = ^1
Console.WriteLine($"{str1[3]}"); // returns the 4th character of str1 !! FIRST CHARACTER == 0 !!
string newResults = str2.Replace("er", "wibble"); //use single quotation for replacing a single character for another single character ; use speec marks for replacing a string with another strng
Console.WriteLine($"{newResults} --> {str2}"); // as we defined a new string called newResults in the same line, str2 remains the same --> to change str2 : str2 = str2.Replace("er", "wibble");


// Again hover your mouse over the "Join" method to see that this is a *different* join method to the previous one,
// taking a string concatenation argument rather than a char as before
var result5 = string.Join(" and ", names);

Console.WriteLine($"'{str1}' joined with the string \" and \" '{str2}' is '{result5}' and is of type '{result5.GetType()}'");

Console.WriteLine();





Console.WriteLine($"int1 = '{int1}' and str1 = '{str1}' before attempted modification in a method");

TestModifyingData(int2, str1); // defines variables used in "method"

Console.WriteLine($"int1 = '{int1}' and str1 = '{str1}' after failed attempt at modification in a method");



Console.ReadKey(); // prevents program from ending (important on Mac laptops)



// This is a "method" - it's highly unusual to put one among top level statements like this - don't do it.
void TestModifyingData(int integer, string str)
{
    integer = integer + 1;
    str = str + "...";
    Console.WriteLine($"integer = '{integer}' and str = '{str}' after modification within a method");
}

