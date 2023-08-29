using MoreLinq; //RANDOMLY SHUFFLES DATA
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

// See https://aka.ms/new-console-template for more information

const int count = 1_000_000;
const int searchIndex = 551_467;



List<Pair> baseList = new();

for (int i = 0; i < count; i++)
{
    baseList.Add(new() { Index = i, Text = i.ToString() });
}

baseList = baseList.Shuffle().ToList(); //.Shuffle() slows down the list and array methods

string value;




Pair[] array = baseList.ToArray();

var sw = Stopwatch.StartNew();

value = array.Where(x => x.Index == searchIndex).Select(x => x.Text).FirstOrDefault();

Console.WriteLine($"Array item {value} searched in {sw.ElapsedTicks:N0} ticks");
Console.WriteLine();
Console.WriteLine();





ImmutableArray<Pair> iArray = baseList.ToImmutableArray();

sw.Restart();

value = iArray.Where(x => x.Index == searchIndex).Select(x => x.Text).FirstOrDefault();

Console.WriteLine($"Immutable Array item {value} searched in {sw.ElapsedTicks:N0} ticks");
Console.WriteLine();
Console.WriteLine();





List<Pair> list = baseList.ToList();

value = list.Where(x => x.Index == searchIndex).Select(x => x.Text).FirstOrDefault();

Console.WriteLine($"List item {value} searched in {sw.ElapsedTicks:N0} ticks");
Console.WriteLine();
Console.WriteLine();






ImmutableList<Pair> iList = baseList.ToImmutableList();

value = iList.Where(x => x.Index == searchIndex).Select(x => x.Text).FirstOrDefault();

Console.WriteLine($"Immutable List item {value} searched in {sw.ElapsedTicks:N0} ticks");
Console.WriteLine();
Console.WriteLine();






Dictionary<int, string> dict = baseList.ToDictionary(x => x.Index, x => x.Text);

sw.Restart();

value = dict.Where(x => x.Key == searchIndex).Select(x => x.Value).FirstOrDefault();

Console.WriteLine($"Dictionary item {value} searched in {sw.ElapsedTicks:N0} ticks");

sw.Restart();

value = dict[searchIndex]; //only time dictionary is fast and worth it: finding the index of a value in an unsorted list

Console.WriteLine($"Dictionary item {value} indexed in {sw.ElapsedTicks:N0} ticks");
Console.WriteLine();
Console.WriteLine();






ImmutableDictionary<int, string> iDict = baseList.ToImmutableDictionary(x => x.Index, x => x.Text);

sw.Restart();

value = iDict.Where(x => x.Key == searchIndex).Select(x => x.Value).FirstOrDefault();

Console.WriteLine($"Immutable Dictionary item {value} searched in {sw.ElapsedTicks:N0} ticks");

sw.Restart();

value = iDict[searchIndex];

Console.WriteLine($"Immutable Dictionary item {value} indexed in {sw.ElapsedTicks:N0} ticks");
Console.WriteLine();
Console.WriteLine();






Console.ReadKey();


public struct Pair
{
    public int Index;
    public string Text;
}