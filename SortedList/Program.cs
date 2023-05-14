/*
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте программу в которой используя класс SortedList, создайте небольшую коллекцию и
выведите на экран значения пар «ключ- значение» сначала в алфавитном порядке, а затем в
обратном.
*/

SortedList<int, string> sortedList = new SortedList<int, string>
{
    { 1, "one" },
    { 2, "two" },
    { 3, "three" },
    { 4, "four" },
    { 5, "five" }
};

var ascendingList = sortedList.OrderBy(x => x.Value).ToList();

Console.WriteLine("Вывод элементов в алфавитном порядке:");
foreach (var item in ascendingList)
{
    Console.WriteLine(item.Key + ": " + item.Value);
}

var descendingList = sortedList.OrderByDescending(x => x.Value).ToList();

Console.WriteLine("Вывод элементов в обратном порядке:");
foreach (var item in descendingList)
{
    Console.WriteLine(item.Key + ": " + item.Value);
}