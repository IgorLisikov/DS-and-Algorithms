using System.Text;

namespace WeightedGraphs
{
    public class WeightedGraph
    {
        private Dictionary<string, Node> _nodes = new();

        public void AddNode(string label)
        {
            _nodes.TryAdd(label, new Node(label));
        }

        public void AddEdge(string from, string to, int weight)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new IndexOutOfRangeException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new IndexOutOfRangeException();

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public List<string> ShortestPath(string from, string to, out int distance)  // Dijkstra's shorted path
        {
            // Suppose it is needed to find shortest path from A to E in some graph.
            // On each iteration the table below is populated with shortest distance from A to current Node.
            // Also, need to keep track of previous nodes, to be able to build the path.

            // Node  Distance  Previous
            //  A       0
            //  B      Max
            //  C      Max
            //  D      Max
            //  E      Max

            if (!_nodes.TryGetValue(from, out Node fromNode) || !_nodes.TryGetValue(to, out Node toNode))
                throw new IndexOutOfRangeException();

            distance = 0;
            var distances = new Dictionary<Node, int>();
            foreach (var entry in _nodes.Values)
            {
                distances.Add(entry, int.MaxValue);
            }
            distances[fromNode] = 0;

            var previousNodes = new Dictionary<Node, Node>();
            var queue = new PriorityQueue<Node, int>();
            var visited = new HashSet<Node>();

            queue.Enqueue(fromNode, 0);

            // 1 - while not visited nodes exist
            // 2 - take the node that is closest to the start
            // 3 - update distances of it's neighbors (distances from start to neighbor)
            // 4 - everytime neighbor's distance gets updated - update neighbor's previous
            while (queue.Count > 0)   // (1)
            {
                var current = queue.Dequeue();  // (2)
                visited.Add(current);

                int fromStartToCurrent = distances[current];
                foreach (var edge in current.GetEdges())
                {
                    var neighbor = edge.To;
                    if (visited.Contains(neighbor))
                        continue;

                    int fromStartToNeighbor = fromStartToCurrent + edge.Weight;
                    if (fromStartToNeighbor < distances[neighbor])  // (3)
                    {
                        distances[neighbor] = fromStartToNeighbor;
                        previousNodes[neighbor] = current;  // (4)
                    }
                    queue.Enqueue(neighbor, fromStartToNeighbor);
                }
            }

            distance =  distances[toNode];

            return BuildPath(previousNodes, toNode);
        }

        private List<string> BuildPath(Dictionary<Node, Node> previousNodes, Node toNode)
        {
            var stack = new Stack<Node>();
            stack.Push(toNode);
            previousNodes.TryGetValue(toNode, out Node previous);
            while (previous != null)
            {
                stack.Push(previous);
                previousNodes.TryGetValue(previous, out previous);
            }
            var path = new List<string>();
            while (stack.Count > 0)
            {
                path.Add(stack.Pop().Label);
            }

            return path;
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();

            foreach (var node in _nodes.Values)
            {
                if (!visited.Contains(node))
                {
                    if (HasCycle(node, null, visited))
                        return true;
                }
            }

            return false;
        }

        private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
        {
            visited.Add(node);

            foreach (var edge in node.GetEdges())
            {
                var neighbor = edge.To;
                if (neighbor == parent)
                    continue;

                if (visited.Contains(neighbor) ||
                    HasCycle(neighbor, node, visited))
                    return true;
            }

            return false;
        }

        public WeightedGraph MinimumSpanningTree()  // Prim's algorithm
        {
            // Spanning tree is a tree converted from a graph by removing unnecessary edges from that graph
            var res = new WeightedGraph();
            if (_nodes.Count == 0)
                return res;

            var queueEdges = new PriorityQueue<Edge, int>();

            // Select any node in a grpah:
            var node = _nodes.Values.First();
            foreach (var edge in node.GetEdges())
            {
                queueEdges.Enqueue(edge, edge.Weight);
            }

            res.AddNode(node.Label);

            // Extend the result by adding the smallest connected edge:
            while (res._nodes.Count < _nodes.Count)  // until all nodes of a graph are added to result
            {
                var smallestEdge = queueEdges.Dequeue();
                var nextNode = smallestEdge.To;
                if (res._nodes.ContainsKey(nextNode.Label))  // if already visited
                    continue;

                res.AddNode(nextNode.Label);
                res.AddEdge(smallestEdge.From.Label, nextNode.Label, smallestEdge.Weight);

                foreach (var edge in nextNode.GetEdges())
                {
                    if (!res._nodes.ContainsKey(edge.To.Label))
                    {
                        queueEdges.Enqueue(edge, edge.Weight);
                    }
                }
            }

            return res;
        }


        public void Print()
        {
            foreach (var node in _nodes.Values)
            {
                var edges = node.GetEdges();
                if (edges.Count > 0)
                {
                    Console.WriteLine($"{node.Label} is connected with {GetEdgesString(edges)}");
                }
            }
        }

        private string GetEdgesString(List<Edge> edges)
        {
            var sb = new StringBuilder();

            sb.Append('[');
            foreach (var edge in edges)
            {
                sb.Append(edge.ToString());
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');

            return sb.ToString();
        }
    }


    public class Node
    {
        private List<Edge> _edges = new List<Edge>();

        public string Label;

        public Node(string label)
        {
            Label = label;
        }

        public void AddEdge(Node target, int weight)
        {
            _edges.Add(new Edge(this, target, weight));
        }

        public List<Edge> GetEdges()
        {
            return _edges;
        }

        public override string ToString()
        {
            return Label;
        }
    }

    public class Edge
    {
        public Node From;
        public Node To;
        public int Weight;

        public Edge(Node from, Node to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{From}->{To}";
        }
    }
}
