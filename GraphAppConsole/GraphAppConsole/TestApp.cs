using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAppConsole
{
    class TestApp
    {
        public Graph graph;

        public void Start()
        {
            Console.Write("Введiть кiлькiсть вершин: ");
            int n = int.Parse(Console.ReadLine());
            graph = new GraphMatrix(n);
            try
            {
                while (true)
                {
                    Menu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public void Menu()
        {
            Console.WriteLine("1. Додати дугу \n" +
                "2. Видалити дугу \n" +
                "3. Пепевiрка на iзольованiсть \n" +
                "4. Перевiрка iснування дуги \n" +
                "5. Напiвстепiнь входу вершини \n" +
                "6. Напiвстепiнь виходу вершини \n" +
                "7. Представити граф у вигляді списку \n" +
                "8. Представити граф у вигляді матриці \n");

            int f_element, l_element;
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    Console.Write("Ввеiть першу вершину: ");
                    f_element = int.Parse(Console.ReadLine());
                    Console.Write("Ввеiть другу вершину: ");
                    l_element = int.Parse(Console.ReadLine());
                    graph.AddEdge(f_element, l_element);
                    Console.WriteLine("Додали дугу");
                    break;

                case 2:
                    Console.Write("Ввеiть першу вершину: ");
                    f_element = int.Parse(Console.ReadLine());
                    Console.Write("Ввеiть другу вершину: ");
                    l_element = int.Parse(Console.ReadLine());
                    graph.RemoveEdge(f_element, l_element);
                    Console.WriteLine("Удали дугу");
                    break;

                case 3:
                    Console.Write("Введiть вершину: ");
                    int v = int.Parse(Console.ReadLine());
                    Console.WriteLine(graph.IsIsolated(v));
                    break;

                case 4:
                    Console.Write("Ввеiть першу вершину: ");
                    f_element = int.Parse(Console.ReadLine());
                    Console.Write("Ввеiть другу вершину: ");
                    l_element = int.Parse(Console.ReadLine());
                    Console.WriteLine(graph.CheckEdge(f_element, l_element));
                    break;

                case 5:
                    Console.Write("Введiть вершину: ");
                    v = int.Parse(Console.ReadLine());
                    int count = graph.InDegree(v);
                    Console.WriteLine("Напiвстепiнь входу {0}-вершини = {1}", v, count);
                    break;

                case 6:
                    Console.Write("Введiть вершину: ");
                    v = int.Parse(Console.ReadLine());
                    count = graph.OutDegree(v);
                    Console.WriteLine("Напiвстепiнь виходу {0}-вершини = {1}", v, count);
                    break;

                case 7:
                    if(graph is GraphMatrix)
                    graph = graph.Converter();
                    graph.Print();
                    break;

                case 8:
                    if(graph is GraphList)
                    graph = graph.Converter();
                    graph.Print();
                    break;
            }
        }
    }
}
