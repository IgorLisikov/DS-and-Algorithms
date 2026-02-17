using WeightedGraphs;



var graph = new WeightedGraph();
graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddEdge("A", "B", 1);
graph.AddEdge("B", "C", 2);
graph.AddEdge("A", "C", 10);
graph.Print();

//      1
//   A ---- B
//     \    |
//      \   | 2
//    10 \  |
//        \ |
//         \|
//          C

// Dijkstra's shorted path:
var path = graph.ShortestPath("A", "C", out int distance);  // A, B, C
Console.WriteLine(distance);  // 3



// Cycle detection:
graph = new WeightedGraph();
graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddEdge("A", "B", 1);
graph.AddEdge("B", "C", 2);
//      1
//   A ---- B
//          |
//          | 2
//          |
//          |
//          |
//          C
Console.WriteLine(graph.HasCycle());  // false

graph.AddEdge("A", "C", 10);
//      1
//   A ---- B
//     \    |
//      \   | 2
//    10 \  |
//        \ |
//         \|
//          C
Console.WriteLine(graph.HasCycle());  // true



// Prim's algorithm:
graph = new WeightedGraph();
graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddNode("D");
graph.AddEdge("A", "B", 3);
graph.AddEdge("B", "D", 4);
graph.AddEdge("C", "D", 5);
graph.AddEdge("A", "C", 1);
graph.AddEdge("B", "C", 2);

//        3
//    A ---- B
//    |     /|
//    |  2 / |
//   1|   /  |4
//    |  /   |
//    | /    |
//    |/     |
//    C ---- D
//        5
var minimumSpanningTree = graph.MinimumSpanningTree();

minimumSpanningTree.Print();

//    A      B
//    |     /|
//    |  2 / |
//   1|   /  |4
//    |  /   |
//    | /    |
//    |/     |
//    C      D


