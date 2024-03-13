
### DFS와 BFS

그래프는 다양한 알고리즘에 활용됩니다. 그래프 탐색은 그래프 내의 정점을 특정 순서로 방문하는 작업입니다. 대표적인 그래프 탐색 알고리즘으로는 깊이 우선 탐색(Depth-First Search, DFS)과 너비 우선 탐색(Breadth-First Search, BFS)이 있습니다.

DFS는 현재 정점에서 연결된 정점을 하나씩 방문하며, 더 이상 방문할 정점이 없을 때까지 계속해서 탐색을 진행합니다. 이 과정에서 스택(Stack) 자료구조를 사용합니다.

BFS는 현재 정점과 인접한 모든 정점을 큐(Queue)에 넣고, 큐에서 하나씩 꺼내어 방문하는 방식으로 탐색을 진행합니다. 이 과정에서 큐 자료구조를 사용합니다.

그래프를 활용한 탐색 알고리즘은 경로 찾기, 최단 경로 찾기, 연결성 확인 등 다양한 문제에 활용됩니다.
![[Pasted image 20240122212506.png]]

DFS

![[Pasted image 20240122212514.png]]

BFS

- 예시 : 맵 탐색 (BFS) 안정적인 퍼포먼스
    
    ```csharp
    class Program
        {
            static void Main(string[] args)
            {
                int[,] adj = new int[6, 6]
                {
                    { 0, 1, 0, 1, 0, 0},
                    { 1, 0, 1, 1, 0, 0},
                    { 0, 1, 0, 0, 0, 0},
                    { 1, 1, 0, 0, 1, 0},
                    { 0, 0, 0, 1, 0, 1},
                    { 0, 0, 0, 0, 1, 0},
                };
    
                BFS bfs = new BFS();
                bfs.Initurlize(adj);
                var resault = bfs.Search(0);
    
                foreach (var dic in resault)
                {
                    foreach (var value in dic.Value)
                        Console.WriteLine($"{dic.Key} - {value}");
                }
            }
        }
        public class BFS
        {
            int[,] _graph;
            public void Initurlize(int[,] graph)
            {
                _graph = graph;
            }
    
            public Dictionary<string, int[]> Search(int start)
            {
                if (_graph == null)
                    return null;
    
                int num = _graph.GetLength(0);//정점 총수
    
                Queue<int> queue = new Queue<int>();
                bool[] found = new bool[num];//경유 유무
                List<int> sequence = new List<int>();//경유 순서
                int[] parent = new int[num];//정점의 부모
                int[] distance = new int[num];//start정점과 각 정점사이거리
    
                queue.Enqueue(start);
                found[start] = true;
                parent[start] = start;
                distance[start] = 0;
    
                while (queue.Count > 0)
                {
                    int now = queue.Dequeue();
                    sequence.Add(now);
    
                    for (int next = 0; next < num; next++)
                    {
                        if (_graph[now, next] == 0)
                            continue;
    
                        if (found[next])
                            continue;
    
                        queue.Enqueue(next);
                        found[next] = true;
                        parent[next] = now;
                        distance[next] = distance[now] + 1;
                    }
                }
    
                Dictionary<string, int[]> answer = new Dictionary<string, int[]>()
                {
                    {"sequence",sequence.ToArray() },
                    {"parent",parent },
                    {"distance",distance },
                };
    
                return answer;
            }
        }
    ```
    
- 예시 : 도착 가능 여부 확인 (DFS) Worst Case 위험
    
    ```csharp
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
                { 0, 1, 0, 1, 0, 0},
                { 1, 0, 1, 1, 0, 0},
                { 0, 1, 0, 0, 0, 0},
                { 1, 1, 0, 0, 1, 0},
                { 0, 0, 0, 1, 0, 1},
                { 0, 0, 0, 0, 1, 0},
        };
        bool[] visited = new bool[6];
    
        //1) now부터 방문
        //2) now와 연결된 정점들을 하나씩 확인해서 [아직 미방문 상태라면]방문
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true; //1) now부터 방문
    
            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)//연결된 정점이라면 스킵
                    continue;
                if (visited[next])//이미 방문한 곳이라면 스킵
                    continue;
    
                DFS(next);
            }
        }
    }
    ```
    