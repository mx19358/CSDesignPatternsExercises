# C# Basics
Simon Ziegler, 28 August 2023

## 1. What are C# and .NET?
C# is a "managed language" that runs under the [.NET environment](https://learn.microsoft.com/en-us/dotnet/). .NET is a program that Microsoft publish for major tech operating systems, including Windows, macOS, Linux, iOS and Android. The `dotnet` program is published in two varieties: (i) the "runtime" which is capable of running compiled .NET assemblies and (ii) the Software Development Kit ("SDK") which compiles code to assemblies, performs publishing tasks and can also run assemblies. The SDK is downloaded with Visual Studio, and Visual Studio uses the SDK to build and run your code.

The C# programming language allows you to build many types of applications, such as:
- Business applications to capture, analyze, and process data
- Dynamic web applications that can be accessed from a web browser
- Games, both 2D and 3D
- Financial and scientific applications
- Cloud-based applications
- Mobile applications

C# is derived from the earlier groundbreaking languages C and C++, which date from the early '70s and early '80s respectively. **C is a very low level language** with a limited core instruction set, where higher level functionality is introduced by incorporating libraries into systems. Being a low level language it's "close to the metal" meaning that there's a tight relationship between what you code and the compiled machine code. This makes C programs extremely fast (important at a time when computers were very low powered) but also prone to unreliability since programmers had free rein to write to any memory address. C++ added object orientation to C, and generally C++ compilers are used for compiling C code. Since C/C++ compile to machine code for the specific microprocessor on the machine where the code is compiled, the compiled programs are not portable to other architectures, requiring compilation separately for any additional architecture.

Being a managed language, C# resolves a lot of problems associated with low level C/C++:
1. It is a "compile once, run anywhere" model, given that all you need to run your assembly for any given architecture is the ability to install the .NET runtime.
2. .NET manages memory for you. There's no need to allocate and de-allocate large areas of memory as required in C/C++, because this is done for you. Unlike C/C++ if you try to access an index of an array beyond that array's bounds, you will get a runtime exception.
3. There are no pointers, so again no ability to access areas of memory to which you should have no access.
4. Not related specifically to being a managed language, C#/.NET benefits from a vast offering of packages from (Nuget)[nuget.org], including more packages from Microsoft, open source ("OSS") packages and commercial packages for which a paid licence is required. [@MarkStega](https://github.com/MarkStega) and I run the [Material.Blazor](https://github.com/Material-Blazor/) GitHub account that publishes four OSS packages to Nuget.

So:
- C# is the programming language (also F# and VB.NET).
- .NET is the platform and compiles/publishes C# to .NET assemblies, then runs those assemblies.

### IDEs
Developers use a specialized tool known as an integrated development environment (IDE) to help speed up the process of writing, debugging, testing, updating/versioning, and releasing code. An IDE typically includes a suite of tools that support the software development process from beginning to end, a process known as the development lifecycle. The IDE tools enable the developer to work more efficiently and can help the developer, or team of developers, to write, debug, test, publish, and version their code more easily. 
- Visual Studio Code is one of the most popular IDEs among C# developers - a full-featured IDE that's quick and easy to install, and that it supports numerous extensions to enhance developer productivity.

## 2. Introduction to the `dotnet` command line tool and how it works with a CSPROJ file
The [.NET Command Line Interface](https://learn.microsoft.com/en-us/dotnet/core/tools/) ("CLI") is invoked by running the `dotnet` command from the command line. On windows the command line is run either from the command shell or better by running powershell - both from the start menu. Examples include:
- `dotnet build T01_CollectionPerformance.csproj`
- `dotnet restore T01_CollectionPerformance.csproj`
- `dotnet run T01_CollectionPerformance.csproj`

Note how in each case we are referencing the `CSPROJ` ("C # project file") file, which determines how a project should be built by .NET. The project file referenced above has the contents below. At some stage you will need to know how to configure these files.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Project Sdk="Microsoft.NET.Sdk">						<!-- Determines the SDK to be used -->

	<PropertyGroup>
		<OutputType>Exe</OutputType>					<!-- Determines that the output is an executable file -->
		<TargetFramework>net7.0</TargetFramework>			<!-- Specifies .NET version 7, the current version released in November 2022 (.NET 8 is imminent) -->
		<ImplicitUsings>enable</ImplicitUsings>				<!-- Google it -->
		<Nullable>enable</Nullable>					<!-- Google it -->
	</PropertyGroup>

	<ItemGroup>
		<PackageReference Include="Humanizer" Version="2.14.1" />	<!-- Imports the Humanizer Nuget package v 2.14.1 -->
		<PackageReference Include="morelinq" Version="3.4.2" />		<!-- Imports the morelinq Nuget package v 3.4.2 -->
	</ItemGroup>

</Project>
```
<figcaption><b>Figure 1 - Simple CSPROJ file</b></figcaption><br><br>

Also see the considerably more complex [CSPROJ](https://github.com/Material-Blazor/Material.Blazor/blob/main/Material.Blazor/Material.Blazor.csproj) file built by Mark for Material.Blazor.

The .NET software development kit (SDK) includes a command-line interface (CLI) that can also be accessed from **Visual Studio's integrated Terminal** (Developer PowerShell).

```dotnet
dotnet new console -o ./CsharpProjects/TestProject
```
The structure of a CLI command consists of three parts:
- The **driver** (ex. `dotnet`)
- The **command** (ex. `new console`)
- The **command arguments** (ex. `-o ./CsharpProjects/TestProject`) --> NB: Command arguments are _optional_ parameters that can be used to provide additional information. The previous command could be run without specifying the optional folder location: `dotnet new console` results in the new console application being created in the current folder location.

The `dotnet build` command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a .dll extension. Depending on the project type and settings, other files may also be included. 
![image](https://github.com/mx19358/CSDesignPatternsExercises/assets/143491084/2974ca02-4c89-4795-9f98-6155a9f0cb06)
<figcaption><b>Figure 1 - using `dotnet build` in the terminal</b></figcaption><br><br>

The `dotnet run` command runs the file from the terminal. This is useful for quick checks/fast iterative development from the command line. However, it relies on `dotnet build` command to build the code prior to using `dotnet run`.

## 3. Using `dotnet` with GitHub workflows
[GitHub](https://github.com/) (or its competitors [GitLab](https://about.gitlab.com/), [Bitbucket](https://bitbucket.org/) etc.) is a source code repository using the Git source code control system. This project is hosted on GitHub. GitHub offers much more than just source code control, and is a complete "Devops" environment for software development. This includes automated software build and deployment using GitHub workflows. A (rather complex) [example](https://github.com/Material-Blazor/Material.Blazor/blob/main/.github/workflows/GithubActionsRelease.yml), again written by Mark, deploys releases of Material.Blazor, both creating and publishing the project's [Nuget package](https://www.nuget.org/packages/Material.Blazor), and building and deploying the [website](https://material-blazor.com/).

## 4. Overall C# program structure
Bringing the previous sections together gives a good appreciation of the structure around building a .NET program or library, albeit without seeing the code. The image below is the structure of this repo at the time of writing. If you're reading this on GitHub you'll see the current structure to the left, otherwise from Visual Studio this is in the Solution Explorer.

<img src="https://user-images.githubusercontent.com/11708435/263727952-b0456204-28c9-4725-8fd0-a4757fd00ec8.png" alt="image" width="300">
<figcaption><b>Figure 2 - GitHub displayed repo structure</b></figcaption><br><br>

The repo is brought together by the solution file with a `.sln` extension at the top level; don't edit these manually. This file tells Visual Studio what projects belong to the overall solution, and how to show extraneous files, such as this documentation (in a Markdown, `.md` file) in the Solution Explorer. Each project within the solution/repo (VS terminology versus Git terminology) is controlled by its `.csproj` file. The projects then have the following file types:
- `.cs` files containing C# code
- resources
- images
- `.css`, `.js`, `.scss` and `.ts` files for web applications
- `.razor` and `.razor.cs` files, also for web applications using ASP.NET Blazor
- plenty of other files depending upon the project!

We are going to concern ourselves exclusively with `.cs` C# source code files from here on, with a nod towards `.csproj` files as we include nuget packages.

## 5. C# language
This last section of the course will focus on some core C# constructs, some standard classes associated with collections of data and a package called LINQ that manipulates these collections in a manner similar to SQL with databases. In fact there's a LINQ to SQL package as part of .NET.

### 5.1. Main method
To print an entire message to the output console, you used the first technique, `Console.WriteLine()`. At the end of the line, it added a line feed similar to how to **create a new line** of text by pressing Enter or Return.

To print to the output console, but **without adding a line** feed at the end, you used the second technique, `Console.Write()`. So, the next call to `Console.Write()` prints another message to the **same line**.

Up to and including C# version 9, you needed a Main method within a class as the entry point for a program as per the example below. This is what is shown in the Udemy course, which was recorded in 2017.

```csharp
namespace MyAppNamespace;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```
<figcaption><b>Figure 3 - C# 9 Main method</b></figcaption><br><br>

From C# version 10, released with .NET 6 in November 2020, this was significantly simplified with "top level statements", so the equivalent entry point for a program can now be:

```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```
<figcaption><b>Figure 4 - C# 10 top level statements</b></figcaption><br><br>

The primary job of the compiler is to convert your code into a format that the computer can understand.

The tutorials I have written for this course will use top level statements.

### 5.2. Language constructs

### 5.2.1. Built in data types and variables
C# has a set of value variable types listed below that represent simple data. Annotations are for those of particular immediate use. See the [C# language reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types) for more information.

Data types play a central role in C#. In fact, the emphasis on data types is one of the key distinguishing features of C# compared to other languages (e.g., JavaScript). The designers of C# believed they can _help developers avoid common software bugs_ by _enforcing data types_.

| C# type keyword | .NET type | Notes |
|:---|:---|:---|
| bool | System.Boolean | Boolean values, taking the value of either `true` or `false` - used extensively when decision logic is incorporated in code|
| byte | System.Byte | |
| sbyte | System.SByte | |
| char | System.Char | A single character |
| decimal | System.Decimal | A decimal value with total precision (28-29 digits post-decimal point). Compared to float and double, this **uses a lot of memory** and is **slower**, however **must be used for monetary amounts** where even tiny rounding errors are unacceptable. |
| double | System.Double | A double precision (~15-17 digits post-decimal point) floating point number (can have minor rounding errors). Good for most purposes, apart from where full precision is required (e.g. monetary amounts). |
| float | System.Single | A standard precision (~6-9 digits post-decimal point) floating point number. In general, I don't use floats because the memory overhead of using a double is usually irrelevant compared to the benefit if the far greater precision gained - only good for **fixed fractional values** (e.g. 1/2, 1/4, 1/8). |
| int | System.Int32 | A simple integer value |
| uint | System.UInt32 | An unsigned integer value |
| nint | System.IntPtr | |
| nuint | System.UIntPtr | |
| long | System.Int64 | A longer integer value |
| ulong | System.UInt64 | |
| short | System.Int16 | A shorter integer value - not sure of the point of these. |
| ushort | System.UInt16 | |
<figcaption><b>Table 1 - Built in value types</b></figcaption><br><br>

| C# type keyword | Literal suffix | Notes |
|:---|:---|:---|
| decimal | M m | |
| double | | Compiler defaults to double literal when **decimal** is entered WITHOUT a literal suffix |
| float | F f | |
| int | | Compiler defaults to int literal when a **whole number** is entered |
<figcaption><b>Table 2 - Literal suffixes</b></figcaption><br><br>

If you need to perform a **mathematical operation on numeric values**, you should use an `int`, `double`, or `decimal`. If you have data that is used for **presentation or text manipulation** (e.g. working with phone numbers/ZIP codes), you should use a `string` or `char` data type. If you need to work with the **words "true" and "false"** in your application, you would use a `string`. However, if you need to work with the **concept** of true or false when performing an evaluation, you use a `bool`.

A **variable** is a container for storing a type of value that is expected to change/vary throughout the execution of a program. Variables can be assigned, read, and changed and are used to store values that you intend to use later on in your code.
A **variable name** is a human-friendly label that the compiler assigns to a memory address. When you want to store or change a value in that memory address, or whenever you want to retrieve the stored value, you just use the variable name you created. 
To **CREATE** a new variable, you must first _declare the data type_ of the variable (using _Table 1_), and then _give it a name_. 
**Naming convention:**
- can contain **alphanumeric characters** and **underscores** (but NO other special characters)
- must BEGIN with a **letter** or **underscore** (however, refrain from using an underscore at the start as developers use the underscore for a special purpose)
- **case sensitive** - variable names of multiple words are in **camel case** (first letter of the word always in small letter and after that each word starts with a capital letter [e.g. camelCase])
- should be descriptive and meaningful in code - choose a name for your variable that represents the kind of data it will hold
- Don't use contractions/abbreviations --> variable name (and therefore purpose) may be unclear to others who are reading your code.
- Variable names shouldn't include the data type of the variable (e.g. `string`/`char`/`bool`)

The C# compiler can infer your variable's data type just by its initialized value. An **implicitly typed local variable** is created by using `var` followed by a variable initialization:
```csharp
var message = "Hello world!";
```
<figcaption><b>Figure 5 - Creating a string variable implicitly</b></figcaption><br><br>

The `var` keyword tells the C# compiler that the data type is implied by the assigned value. After the type is implied, the variable acts the same as if the actual data type had been used to declare it. The `var` keyword is used to save on keystrokes when types are lengthy or when the type is obvious from the context. Once the complier has determined the variable's data type, the type is locked in and therefore, the variable will never be able to hold values of a different data type - in Figure 5, the `message` variable is typed to be a `string` and will produce an error if changing to another data type (e.g., a double) is attempted. **REMEMBER:** you must give the value of the variable in order to use `var`. The `var` keyword can also be useful when planning the code for an application. When you begin developing code for a task, you may not immediately know what data type to use. Using `var` can help you develop your solution more dynamically.

Calling a data type a "value" type indicates that when a variable is passed into a method, its value is passed rather than a reference to the memory holding that variable.
There are also some built in reference types below whereby passing a variable of that type to a method passes a reference to the memory location holding that variable's data, and therefore the method can change the data value (generally considered to be a very bad idea). 


| C# type keyword | .NET type | Notes |
|:---|:---|:---|
| object | System.Object | All classes are an object. |
| string | System.String | A string of characters of arbitrary length. |
| dynamic | System.Object | |
<figcaption><b>Table 3 - Built in reference types</b></figcaption><br><br>

### Escape character sequences
An **escape character sequence** is an instruction to the runtime to insert a special character that will affect the output of your string.
- `\n` : creates a new line
- `\t` : inserts a tab space
- `\"` : inserts double-quotation marks within a literal string
- `\\` : displays a single backslash \ in the literal string

### Verbatim string literal
A **verbatim string literal** will keep all whitespace and characters without the need to use escape character sequences. To create a verbatim string, use the `@` directive before the literal string.
```csharp
Console.WriteLine(@"    c:\source\repos    
        (this is where your code goes)");
```

### Unicode escape characters
**Encoded characters** can be added in literal strings using the `\u` escape sequence, then a **four-character code** representing some character in **Unicode (UTF-16)**.
Some consoles (e.g. Windows Command Prompt) will not display all Unicode characters and will replace those characters with question mark characters instead. Furthermore, some characters require _UTF-32_ and therefore _require a different escape sequence_. This is a complicated subject, and therefore, you may need to use Google depending on your needs.

```csharp
// Output: こんにちは World!
Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!");

// To generate Japanese invoices:
// Output: 日本の請求書を生成するには：
Console.Write("\n\n\u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092\u751f\u6210\u3059\u308b\u306b\u306f\uff1a\n\t");
// User command to run an application
Console.WriteLine(@"c:\invoices\app.exe -j");
```

### String concatenation
**String concatenation** allows you to combine smaller literal and variable strings into a single string. The second value is appended to the end of the first value, etc. However, when printing concatenated strings, it is best to **avoid creating intermediate variables** if adding them doesn't increase readability; this means that, instead of doing this:
```csharp
string greeting = "Hello";
string firstName = "Bob";
string message = greeting + " " + firstName + "!"; //creating an intermediate variable
Console.WriteLine(message);
```
it is better to do the following:
```csharp
string firstName = "Bob";
string greeting = "Hello";
Console.WriteLine(greeting + " " + firstName + "!"); //avoiding the use of intermediate variables by performing the concatenation operation directly when needed
```

### String interpolation
**String interpolation** combines multiple values into a single literal string by using a "template" and one or more interpolation expressions. It provides an improvement over string concatenation by reducing the number of characters required in some situations.
- The literal string becomes a template when it's prefixed by the `$` character.
- An interpolation expression is a variable surrounded by an opening and closing curly brace symbol `{ }`.
```csharp
int version = 11;
string updateText = "Update to Windows";
Console.WriteLine($"{updateText} {version}!");
```
If you need to use a verbatim literal in your template, you can use both the verbatim literal prefix symbol `@` and the string interpolation `$` symbol together.
```csharp
string projectName = "First-Project";
Console.WriteLine($@"C:\Output\{projectName}\Data");

// Output:
C:\Output\First-Project\Data
```

### The addition operator
You can use the addition operator to:
- Add two numeric `int` values together.
```csharp
int firstNumber = 12;
int secondNumber = 7;
Console.WriteLine(firstNumber + secondNumber);

// Output:
19
```
- Concatenate operands of different data types together to force implicit type conversions.
```csharp
string firstName = "Bob";
int widgetsSold = 7;
Console.WriteLine(firstName + " sold " + widgetsSold + " widgets.");

// Output:
Bob sold 7 widgets.
```
```csharp
string firstName = "Bob";
int widgetsSold = 7;
Console.WriteLine(firstName + " sold " + widgetsSold + 7 + " widgets.");

// Output:
Bob sold 77 widgets.
```
Instead of adding the `int` variable `widgetsSold` to the literal `int` 7, the _compiler treats everything as a string_ and concatenates it all together. Use parentheses `( )` to perform both a calculation and concatenation in a single line of code:
```csharp
string firstName = "Bob";
int widgetsSold = 7;
Console.WriteLine(firstName + " sold " + (widgetsSold + 7) + " widgets."); //parentheses form the order of operations operator --> treats 7 as an int, just like widgetsSold

// Output:
Bob sold 14 widgets.
```

### Basic math operators
- `+` is the addition operator
- `-` is the subtraction operator
- `*` is the multiplication operator
- `/` is the division operator.
**NB:** when dividing `int` values, decimals will be removed from the result as `int` by definition holds no decimal points (e.g. 1.75 will become 1). To see division working properly, you need to use a data type that _supports fractional digits_ after the decimal point like `double` or `decimal`:
```csharp
decimal decimalQuotient = 7.0m / 5;
decimal decimalQuotient = 7 / 5.0m;
double decimalQuotient = 7.0 / 5.0;
Console.WriteLine($"Decimal quotient: {decimalQuotient}");

// Output:
Decimal quotient: 1.4
```
As you can see, you must declare the quotient (left of the assignment operator) as type `decimal`/`float`/`double` and at least one of numbers being divided must also be of type `decimal`/`float`/`double` (both numbers can also be `decimal`/`float`/`double` type). Therefore, the following codes will not produce accurate results:
```csharp
int decimalQuotient = 7 / 5.0m;
int decimalQuotient = 7.0m / 5;
int decimalQuotient = 7.0m / 5.0m;
decimal decimalQuotient = 7 / 5;

// Output:
1
```
However, if you need to perform division on `int` values and do not wish the result to be truncated, you must perform a data type cast from `int` to `decimal`/`float`/`double`. **Casting** is one type of data conversion that instructs the compiler to temporarily treat a value as if it were a different data type:
```csharp
int first = 7;
int second = 5;
Console.WriteLine( (decimal)first / (decimal)second );

// Output:
1.4
```
- `%` is the **modulus operator** - tells you the remainder of `int` division
```csharp
Console.WriteLine($"Modulus of 200/5 = {200 % 5}");
Console.WriteLine($"Modulus of 7/5 = {7 % 5}");

// Output:
Modulus of 200/5 = 0 //means that 200 (dividend) is divisible by 5 (divisor)
Modulus of 7/5 = 2
```

### Order of operations
C# follows the same order as BEDMAS except for exponents. While there's no exponent operator in C#, you can use the [System.Math.Pow method](https://learn.microsoft.com/en-us/dotnet/api/system.math.pow?view=net-7.0).
1. **B**rackets
2. **E**xponents
3. **D**ivision and **M**ultiplication (L --> R)
4. **A**ddition and **S**ubtraction (L --> R)

### Compound assignment operators
The compound assignment operators compound some operation in addition to assigning the result to the variable.
- `+=` is the _addition assignment_ operator. It adds the value on the right of the operator to the variable.
```csharp
int value = 0;     // value is 0.
value += 5;        // value is now 5.
```
- `-=` subtracts the value on the right of the operator from the variable.
```csharp
int value = 0;     // value is 0.
value -= 5;        // value is now -5.
```
- `*=` multiplies the value on the right of the operator by the variable.
```csharp
int value = 10;     // value is 10.
value *= 2;         // value is now 20.
```
- `++` increments the value of the variable by 1.
```csharp
int value = 0;     // value is 0.
value++;       	   // value is now 1.
```
- `--` decrements the value of the variable by 1.
```csharp
int value = 0;     // value is 0.
value --;          // value is now -1.
```
Depending on the position of the incrememnt and decrement operators, the operators perform their operation before or after they retrieve their value. In other words, if you use the operator before the value as in `++value`, then the increment will happen _before_ the value is retrieved. Likewise, `value++` will increment the value _after_ the value has been retrieved.
```csharp
int value = 1;
value++;
Console.WriteLine("First: " + value);
Console.WriteLine("Second: " + value++); //Retrieve the current value of the variable value and use that in the string interpolation operation and THEN Increment the value.
Console.WriteLine("Third: " + value);
Console.WriteLine("Fourth: " + (++value)); //Increment the value and THEN Retrieve the new incremented value of the variable value and use that in the string interpolation operation.

// Output:
First: 2
Second: 2
Third: 3
Fourth: 4
```

#### Exercise 5.2.1.
1. Run project `T5-2-1_DataTypes` to see some operations on `int`, `double` and `string` variables.
1. Add some code to print out the individual characters of the array `names` by printing `names[0]` and `names[1]`.
1. Now try the same for the next index, `names[3]` and see what happens.
1. Print out `str1[3]` to see how you can access an indvidual character of a string. Also try `str1[1000]` to see what happens.
1. Work out how to get a new string called `newResult` that takes the value "Ziegler" in `str2` and replaces the "er" with the text "wibble". Google it. Note that local variables like `newResult` by convention use
[camel case](https://www.c-sharpcorner.com/UploadFile/8a67c0/C-Sharp-coding-standards-and-naming-conventions/). Get to know coding conventions for whatever language you are using.

### 5.2.2. Conditionals
There are three types of conditional in C#:
- `if` ... `else if` ... `else` statements (from C/C++).
- `switch` statements (from C/C++).
- `switch` expressions (added for C# 8).

#### Exercise 5.2.2.
1. Run project `T5-2-2_Conditionals` to see `if` statements, `switch` statements and `switch` expressions in action.
1. In the first `if` statement we are testing to see if the `randomNumber` modulus two is equal to zero. Change this to test if `randomNumber` modulus 2 is not equal to 1 instead - the same result but with inverted logic (hint: '!=').
1. In the test with `else if` insert another `else if` before the current one, testing to see if `randomNumber` is greater than or equal to 4. Now change that 4 to 7 and see what happens.
1. In the `if (boolean)` example, invert the logic to test if `boolean` is false. There are two ways to do this, and one is not very obvious. Google is a better friend here than me.

### 5.2.3 Iteration
Whenever you're programming stuff, you'll find that you need to do the same thing over and again on a dataset. This is where you need to iterate across a dataset.
1. `for` loops have a starting condition, a termination condition and an increment statement.
1. `foreach` loops iterate over a given dataset, executing code "for each" element of that dataset.
1. `while` loops continue doing something while a condition is true. They assess the condition at the head of the loop so the code inside the loop is executed zero or more times.
1. `do ... while` loops are the ugly cousin of `while` loops. They test the condition at the end of the loop so they execute the loop's code one or more times. I'm sure there's a good use for them, but I
always felt that with clarity there's a better way of doing things.

#### Exercise 5.2.3.
1. Run project `T5-2-3_Iteration`.
1. Write some code that finds all the prime numbers up to and including a predetermined limit, built as a new console project that one of you commits to GitHub where you work together (this is called paired programming), and the other forks
(who has the faster laptop?). Code the limit as a `const` integer value. Try different ways of doing this and try to make it run as fast as possible by being clever with your algortithm. This is a 30 minute exercise.

### 5.2.4. Classes and structs
C# is an object orientated language, and objects come in two flavours: `struct` and `class`. That's a lie, there's also `record`, which you can Google (records seem to be little used, but I use them all across my business's
system, because I can make data immutable and therefore very safe with a `record`).

Both a `struct` and a `class` are data types that you can define, and which both hold data and methods that encapsulate functionality that you want to perform on the data in an object. A `struct` is a value type whereas a `class` is
a reference type. There are then variations on the theme of each, so Google C# documentation to look into `readonly struct` and other variants. We'll focus on `class` and you can review `struct` separately.

Features of classes:
- They belong to a `namespace` and have different levels of visibility or "scope" (check whether I'm right here):
  - `public` is visible inside and outside of the namespace,
  - `internal` is visible inside the namespace but not externally,
  - `private` is visible only inside the class within which it is defined - this only makes sense for sub-classes (a class within a class).
	- difference between internal and private in practice?
- They can also be:
  - `static`, meaning that the user cannot instantiate an object of that class, but the class does have methods and members. So there's basically one version of the class for your whole
  assembly. (e.g. 'Math' (3 properties : E, pi and tau) /'MathF'(performed on floats) classes)
  - `abstract` are classes that cannot be instantiated, but need other classes to inherit from them.
  - `sealed` are classes you cannot inherit from - this makes them faster to run. Arguably C# should have been designed such that the default for classes is that they are sealed, and then to have an optional "unseal"
  see [this video by Nick Chapsas](https://www.youtube.com/watch?v=d76WWAD99Yo).
- They have members that are either fields and properties:
  - Fields are variables belonging to the class that are declared and do not have `get` and `set` methods. Keep fields only for `private` members or `public read only` (I think - Google it).
  - Properties are variables that do have `get` and `set` (plus `init` - Google it) methods.
  - Both have scopes of `public`, `internal`, `private`, `protected` (visible inside the class and its descendents) and `private protected` (visible inside the class and its descendents within the same namespace).
  - Fields can also have a `readonly` decoration, so they can only be set with an intial value or within the constructor (more on this below). --> gogle
  - Property `set` methods can be `private set` (not quite the same as `init`).
- They have methods:
  - These methods act both on internal and external data (i.e. supplied in parameters to the method).
  - Can be `public`, `internal`, `protected private` and `private`.
  - Can be `static`.
  - Can be `abstract` within an `abstract class` - these methods have no body and need to be implemented by inherited classes.
  - Can be `virtual` meaning that it is expected that an inherited class may want to override the method.
  - Can be `override` meaning that they override an `abstract` or `virtual` method in a parent class.
  - Can be `new` meaning that they override a method in a parent class. Note that if you cast one of these objects to the parent class, the parent's implementation of the method will be used.
  This feels like an "anti pattern", so I try not to use the `new` decorator.
- 
class = has method // struct has value

#### Exercise 5.2.4. -- PLEASE REDO COS I'M LOW KEY LOST
1. Run project `T5-2-4_ClassAndStruct`.
1. Step through the program with the debugger, inspecting what is going on at all stages.
1. Copy this code to a new repo and modify the `Car` class to make it abstract. Then add 2 sealed classes for petrol and electric vehicles:
  - Petrol vehicles can be manual or automatic.
  - EVs are only automatic. --> to do this, remove the transmitter section from Car and copy and paste that into the 
  - For petrol vehicles add properties `MilesPerGallon` and `TankSizeLitres`, both of which are populated from the constructor.
  - For EVs add properties `MilesPerKwh` and `BatteryCapacityKwh`, both of which again are populated from the constructor.
  - Add an abstract method `GetRange()` that returns a double with the range of the vehicle in miles. Implement this in both the petrol and EV classes.
  - Add another abstract method `GetCostPerMile()` that takes a double parameter `costPerUnit` with the cost in £ per unit of energy (litres of petrol or kWh respectively) and returns the cost per mile.
  - Call these and display the results from your top level `Program.cs`.

### 5.2.5. Interfaces
Interfaces allow you to specify a fragment of functionality that different classes implement if they inherit from that interface. An interface lacks its own code.
Classes can then implement a whole range of interfaces. You will use interfaces extensively in the C# Design Patterns course.

#### Exercise 5.2.5.
1. Run project `T5-2-5_Interfaces`.
1. Understand this and be ready for the main coursework where you will encounter this a lot.
1. Look at certain classes that you will use frequently. For instance `List<T>` that's coming up has an interesting interface heirarchy. .NET documentation covers this.

### 5.2.6. Generics
You have seen generics in previous exercises, for instance `List<Vechicle>` is a list that can contain objects of class vehicle. Generics add power to C#, allowing classes and methods to be reused for a wide range
of other classes. Lists for instance can contain any type of item. Exercise 5.2.5 had a list containing any object belong to a class that implements the `IBelonging` interface: this is `List<IBelonging>`.

#### Exercise 5.2.6
1. Run project `T5-2-6_Generics`.
1. Note that this project depends upon, and uses classes from project `T5-2-5_Interfaces`.
  - Look at the references for the project by right clicking it and selecting references from the dropdown menu.
  - Also look at the `CSPROJ`. You add a project reference from the drop down menu, and this reference is then added by VS to the `CSPROJ`.
1. Hover over the `indoorItem` variable in the second loop and inspect the object type.
1. Modify the `BelongingList<T>` to return the count of plants and a list of plants.

## 5.3. Collections and collection performance
We have used arrays (faster) and lists (defined), both of which are of type `ICollection`. We have also seen `IEnumerable`, from which `ICollection` is derived. Google these.

The question is why do we have different collection types? The answer is twofold: performance and utility. Arrays have a defined size and cannot have items added or removed. Lists can add
and remove items and have dynamic size. Arrays are faster to index than lists.

Searching through both arrays and lists for a specific element is slow and you need to do a `foreach` until you find the item. With big data, this is bad. This is where dictionaries come into play.
A dictionary holds both the value of an item, and a key by which to find it. Dictionaries use a hashtable to store the hash value of the keys, and these are super fast to search. The downside is that
dicationaries are otherwise a little slower than arrays and lists for other purposes.

#### Exercise 5.3
1. Run project `T5-3a_CollectionPerformance`.
  - This project builds an `Array<T>`, `List<T>` and `Dictionary<TKey, TValue>`, populated with the same data.
  - Each of these collections then has a both a query run on it to find a specific item, and is indexed directly.
  - In each case the array and list are faster than the dictionary - so what's the point of a dictionary?
  - This is a cheat example though, because the data is sorted.
1. Run project `T5-3b_CollectionPerformance`.
  - This project is similar to the previous one, however it uses the Nuget package morelinq to shuffle the data.
  - Directly indexing the array and list won't work, because we no longer implicityly know the index of the item we want to find.
  - So arrays and lists in this case require a query (with an embedded `foreach`).
  - The dictionary however has its hashtable, and so can still index the items we want from the key value. The dictionary proves its worth in this instance.
  - Doing any data analysis, having a thorough understanding of different collection types and their benefits is key.
  - The example also shows immutable versions of each collection type. Immutability can be very useful, but again be aware of consequences for performance.

## 5.4. LINQ

By now you have seen some examples of LINQ. LINQ is a C# library that brings functional programming to the language. You will have seen that we are able to
select data in a ***declarative*** manner with LINQ as compared to ***prodecural*** data handling with `foreach` loops and so forth.

Review where we have used LINQ so far. One thing you will notice for example is the `=>` lamda notation in the `Where` method calls. A lamda is an
"anonymous method". So far we have considered methods that have names. Take a look at the code for the `Where` method (right click one and go from there)
and you will see that its second parameter is a `Func`; this is a "delegate", which is a fancy way of saying that you supply a method as a parameter.
This method can be a method name in a class, however it would be clumsy to write a new named method for every `.Where` when you use LINQ (my system
Vectis uses thousands of LINQ calls). So instead for simple methods, you can dodge the need for a method name and use this lamda notation instead.
