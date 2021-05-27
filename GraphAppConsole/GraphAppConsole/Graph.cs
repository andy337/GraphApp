using System;

namespace GraphAppConsole
{
    abstract class Graph
    {
        public int N { get; }

        public Graph(int n)
        {
            N = n;
        }

        public abstract void Print(); 

        public abstract void AddEdge(int f_element, int l_element); // Додати дугу

        public abstract void RemoveEdge(int f_element, int l_element); // Видалити дугу

        public abstract bool CheckEdge(int f_element, int l_element); // Перевірка існування дуги
        
        public bool IsIsolated(int v) // Ізольвона вершина
        {
            if(InDegree(v) == 0 && OutDegree(v) == 0)
            {
                return true;
            }
            return false;
        } 

        public abstract int OutDegree(int v); // Напівстепінь дуги(виходу)

        public abstract int InDegree(int v); // Напівстепінь дуги(входу)

        public abstract Graph Converter(); // Конвертер

    }
}
