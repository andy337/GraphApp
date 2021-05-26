using System;
using System.Collections.Generic;

namespace GraphAppConsole
{
    class GraphMatrix : Graph
    {
        public int[,] matrix;

        public GraphMatrix(int n) : base(n) 
        {
            matrix = new int[N, N];
        }

        public override void Print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public override void AddEdge(int f_element, int l_element)
        {
            if(matrix[l_element, f_element] != 0)
            {
                throw new Exception("Цей граф не має мiстити кратних дуг");
            }
            matrix[f_element, l_element] = 1;

        }

        public override void RemoveEdge(int f_element, int l_element)
        {
            matrix[f_element, l_element] = 0;
        }

        public override bool CheckEdge(int f_element, int l_element)
        {
            if(matrix[f_element,l_element] == 1)
            {
                return true;
            }
            return false;
        }

        public override bool IsIsolated(int index)
        {
            for(int i = 0; i < N; i++)
            {
                if(matrix[i,index] == 1 || matrix[index, i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        public override int OutDegree(int index)
        {
            int count = 0;
            for(int i = 0; i < N; i++)
            {
                if(matrix[index, i] == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public override int InDegree(int index)
        {
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                if (matrix[i, index] == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public override Graph Converter()
        {
            GraphList graphList = new GraphList(N);

            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if(matrix[i,j] == 1)
                    {
                        graphList.AddEdge(i, j);
                    }
                }
            }
            return graphList;
        }
    }
}
