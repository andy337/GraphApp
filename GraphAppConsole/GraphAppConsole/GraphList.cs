using System;
using System.Collections.Generic;

namespace GraphAppConsole
{
    class GraphList : Graph
    {
        public Dictionary<int, List<int>> graphList;

        public GraphList(int n) : base(n)
        {
            graphList = new Dictionary<int, List<int>>(n);
        }

        public override void Print()
        {
            for(int i = 0; i < N; i++) 
            {

                if (!graphList.ContainsKey(i))
                    graphList[i] = new List<int>();

                    Console.Write(i + " -> ");
                    for (int j = 0; j < graphList[i].Count; j++)
                    {
                        Console.Write(graphList[i][j] + ", ");
                    }
                    Console.WriteLine();
            }
        }

        public override void AddEdge(int key, int l_element)
        {
            if (!graphList.ContainsKey(key))
            {
                graphList[key] = new List<int>();
            }
            graphList[key].Add(l_element);
        }

        public override void RemoveEdge(int key, int l_element)
        {
            graphList[key].Remove(l_element);
        }

        public override bool CheckEdge(int key, int l_element)
        {
            if (graphList[key].Contains(l_element))
                return true;
            return false;
        }   

        public override int OutDegree(int key)
        {
            return graphList[key].Count;
        }

        public override int InDegree(int v)
        {
            int count = 0;
            for(int i = 0; i < graphList[i].Count; i++)
            {
                if (graphList[i].Contains(v))
                {
                    count++;
                }
            }
            return count;
        }

        public override Graph Converter()
        {
            GraphMatrix graphMatrix = new GraphMatrix(N);

            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < graphList[i].Count; j++)
                {
                    graphMatrix.AddEdge(i, graphList[i][j]);
                }
            }

            return graphMatrix;
        }
    }
}
