/*
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте програму в которой реализуйте коллекцию MyList<T>. Реализуйте в простейшем
приближении возможность использования ее экземпляра аналогично экземпляру класса
List<T>.
Для данной задачи создайте обобщенный интерфейс IMyList<T>, интерфейс должен
содержать следующие методы и свойства:
1) Метод void Add(T a); - для добавления элемента в коллекцию;
2) T this[int index] { get; } свойство – для получения элемента массива из
коллекции по индексу;
3) int Count { get; } свойство которое возвращает количество элементов массива;
4) Метод void Clear(); - удаляет из коллекции все элементы;
5) Метод bool Contains(T item); - определяет содержится ли элемент в коллекции.
Далее создайте обобщенный класс MyList<T> (экземпляр которой и будет использоватся
аналогично экземпляру List<T>.), в котором реализуйте интерфейс IMyList<T> также в теле
класса создайте закрытий массив элементов типа Т - private T[] array и конструктор
класса public MyList() в котором инициализируйте массив элементов.
Далее в методе Main создайте экземпляр коллекции MyList<T> и циклом добавьте в него 20
элементов, после чего в цикле переберите все его элементы и выведите их значение на консоль.

Создайте расширяющий метод: public static T[] GetArray<T>(this MyList<T> list)
Примените расширяющий метод к экземпляру типа MyList<T>, разработанному в домашнем
задании 2 для данного урока. Выведите на экран значения элементов массива, который вернул
расширяющий метод GetArray()
*/
using System.Collections;

MyList<int> list = new MyList<int>();

for (int i = 0; i < 20; i++)
{
    Random random = new Random();
    list.Add(random.Next(1,10));
}
foreach (var item in list)
{
    Console.Write(item + " ");
}
int a = 7;
int b = 3;
Console.WriteLine();

Console.WriteLine($"Содержит указанный элемент ({a}): " + list.Contains(a));
Console.WriteLine($"Элемент по указанному индексу ({b}): " + list[b]);
Console.WriteLine("Размерность коллекции - " + list.Count);

#region Применение расширяющего метода
var newArray = list.GetArray();
foreach (var item in newArray)
{
    Console.Write(item + " ");
}
#endregion

list.Clear();
Console.WriteLine();
Console.WriteLine("Все элементы коллекции удалены, размерность коллекции - " + list.Count);

interface IMyList<T>
{
    void Add(T a);
    T this[int index] { get; }
    int Count { get; }
    void Clear();
    bool Contains(T item);
}

class MyList<T> : IMyList<T>
{
    public T this[int index] => array.ElementAt(index);
    public int Count => array.Length;
    public void Add(T a)
    {
        if (array == null)
        {
            array = new T[1] { a };
        }
        else
        {
            T[] tempArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[array.Length] = a;
            array = tempArray;
        }
    }
    public void Clear()
    {
        array = new T[0];
    }
    public bool Contains(T item)
    {
        if (array.Contains(item))
        {
            return true;
        }
        return false;
    }

    private T[] array;
    public MyList()
    {
        array = new T[0];
    }
    public IEnumerator GetEnumerator()
    {
        foreach (var item in array)
        {
            yield return item;
        }
    }  
}
static class GetArrayExtension
{
    public static T[] GetArray<T>(this MyList<T> list)
    {
        T[] array = new T[0];
        foreach (T item in list)
        {
            T[] NewArray = new T[array.Length + 1];
            array.CopyTo(NewArray, 0);
            NewArray[array.Length] = item;
            array = NewArray;
        }
        return array;
    }
}