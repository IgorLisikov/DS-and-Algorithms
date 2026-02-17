using Graphs;



var graph = new Graph();
graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddNode("D");

graph.AddEdge("A", "B");
graph.AddEdge("B", "D");
graph.AddEdge("D", "C");
graph.AddEdge("A", "C");
graph.AddEdge("B", "C");
graph.Print();           // A is connected with [B, C]
                         // B is connected with [D, C]
                         // D is connected with [C]

graph.RemoveEdge("B", "C");
graph.Print();           // A is connected with [B, C]
                         // B is connected with [D]
                         // D is connected with [C]

//   A -->  B
//   |    /   \
//   |   /     \
//   ↓  ↙       ↘
//   C  <------  D

graph.DepthFirst("A");             // A B D C
graph.DepthFirstIterative("A");    // A C B D

graph.BreadthFirstIterative("A");  // A B C D



//*******************************************************//

Console.WriteLine();
Console.WriteLine("TopologicalSort:");

var graph1 = new Graph();
graph1.AddNode("A");
graph1.AddNode("B");
graph1.AddNode("C");
graph1.AddNode("D");

graph1.AddEdge("A", "B");
graph1.AddEdge("A", "C");
graph1.AddEdge("B", "D");
graph1.AddEdge("C", "D");

//   A  ---->  B
//    \         \
//     \         \
//      ↘         ↘
//       C  ---->  D

var list = graph1.TopologicalSort();
Console.WriteLine();
foreach (var label in list)
{
    Console.WriteLine(label);      // A C B D
}


//*******************************************************//

Console.WriteLine();
Console.WriteLine("Cycle Detection:");

var graph2 = new Graph();
graph2.AddNode("A");
graph2.AddNode("B");
graph2.AddNode("C");
graph2.AddNode("D");

graph2.AddEdge("A", "B");
graph2.AddEdge("A", "C");
graph2.AddEdge("B", "C");
graph2.AddEdge("D", "C");

//   A ---> B
//   ↑ \    |
//   |  \   |
//   |   \  |
//   |    \ |
//   |     ↘↓
//   D      C
Console.WriteLine(graph2.HasCycle());  // false

graph2.RemoveEdge("A", "C");
graph2.AddEdge("C", "A");

//   A ---> B
//   ↑ ↖    |
//   |  \   |
//   |   \  |
//   |    \ ↓
//   D     C
Console.WriteLine(graph2.HasCycle());  // true


