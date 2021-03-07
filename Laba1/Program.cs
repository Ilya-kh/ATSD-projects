using System;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> List = new LinkedList<int>();
            int k = Convert.ToInt32(Console.ReadLine());
            int l;
            for (int i = 0; i < k; i++)
            {
                l = Convert.ToInt32(Console.ReadLine());
                List.AddItem(l);
            }
            Console.WriteLine("Вывод Листа: ");
            List.Print();
            Console.WriteLine("Удалить елемент: ");
            l = Convert.ToInt32(Console.ReadLine());
            List.DeleteItem(l);
            Console.WriteLine("Вывод Листа: ");
            List.Print();
            Console.WriteLine("Размер Листа: " + List.Sizeof());
            Console.WriteLine("Поиск елемента в Листе: ");
            l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(List.Search(l));
            Console.WriteLine("Пустой ли Лист? : " + List.isEmpty());
        }
    }
}
