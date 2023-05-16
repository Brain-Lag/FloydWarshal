using System;

class FloydWarshallAlgorithm
{
    static int INF = 9999; // Бесконечность

    static void FloydWarshall(int[,] graph, int vertices, int startVertex, int endVertex)
    {
        int[,] dist = new int[vertices, vertices];
        int[,] next = new int[vertices, vertices];

        // Инициализация матрицы расстояний dist[][] и next[][]
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                dist[i, j] = graph[i, j];
                if (dist[i, j] == INF)
                {
                    next[i, j] = -1;
                }
                else
                {
                    next[i, j] = j;
                }
            }
        }

        // Применение алгоритма Флойда-Уоршалла
        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                        next[i, j] = next[i, k];
                    }
                }
            }
        }

        // Вывод кратчайшего пути между startVertex и endVertex
        Console.Write("Кратчайший путь между вершинами {0} и {1}: ", startVertex, endVertex);
        if (dist[startVertex, endVertex] == INF)
        {
            Console.WriteLine("Нет пути");
        }
        else
        {
            Console.Write(startVertex + " ");
            int intermediateVertex = startVertex;
            while (intermediateVertex != endVertex)
            {
                intermediateVertex = next[intermediateVertex, endVertex];
                Console.Write(intermediateVertex + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Расстояние: " + dist[startVertex, endVertex]);
        }
    }

    static void Main()
    {
        int[,] graph = {
            { 0, 5, INF, 10 },
            { INF, 0, 3, INF },
            { INF, INF, 0, 1 },
            { INF, INF, INF, 0 }
        };
        int vertices = 4;

        int startVertex = 0;
        int endVertex = 3;

        FloydWarshall(graph, vertices, startVertex, endVertex);
    }
}
