using System;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> List = new LinkedList<int>();
            Console.WriteLine("1 - Добавление элемента");
            Console.WriteLine("2 - Удаление элемента");
            Console.WriteLine("3 - Поиск элемента");
            Console.WriteLine("4 - Размер листа");
            Console.WriteLine("5 - Проверка пустой ли лист?");
            Console.WriteLine("6 - Bыход");
            bool k = true;
            int l;
            while (k)
            {
                Console.WriteLine("Выберите действие: ");
                l = Convert.ToInt32(Console.ReadLine());
                switch (l)
                {
                    case 1:
                        Console.WriteLine("Какое число вы хотите добавить? ");
                        l = Convert.ToInt32(Console.ReadLine());
                        List.AddItem_sort(l);
                        List.Print();
                        break;
                    case 2:
                        Console.WriteLine("Какое число вы хотите удалить");
                        l = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(List.DeleteItem(l)); 
                        List.Print();
                        break;
                    case 3:
                        Console.WriteLine("Найти элемент: ");
                        l = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(List.Search(l));
                        break;
                    case 4:
                        Console.WriteLine("Размер листа: ");
                        Console.WriteLine(List.Sizeof());
                        break;
                    case 5:
                        Console.WriteLine("Пустой ли лист? : ");
                        Console.WriteLine(List.isEmpty());
                        break;
                    case 6:
                        k = false;
                        break;
                }
            }
        }
    }
}
