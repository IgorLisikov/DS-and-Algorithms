using System.Text;

namespace Graphs
{
    public class Graph
    {
        // Graphs are used to represent connected objects.
        private Dictionary<string, Node> _nodes = new ();
        private Dictionary<Node, List<Node>> _adjacencyList = new ();

        public void AddNode(string label)
        {
            var node = new Node(label);
            _nodes.TryAdd(label, node);
            _adjacencyList.TryAdd(node, new List<Node>());
        }

        public void AddEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new IndexOutOfRangeException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new IndexOutOfRangeException();

            _adjacencyList[fromNode].Add(toNode);
        }

        public void Remove(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;
            
            foreach (var kvp in _adjacencyList)
            {
                var targets = kvp.Value;
                targets.Remove(node);
            }
            _adjacencyList.Remove(node);
            _nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                return;

            if (!_nodes.TryGetValue(to, out Node toNode))
                return;

            _adjacencyList[fromNode].Remove(toNode);
        }

        public void DepthFirst(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            DepthFirst(node, new HashSet<Node>());
        }

        private void DepthFirst(Node node, HashSet<Node> visited)
        {
            Console.WriteLine(node);
            visited.Add(node);

            _adjacencyList.TryGetValue(node, out List<Node> neighbors);
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                    DepthFirst(neighbor, visited);
            }
        }

        public void DepthFirstIterative(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            var visited = new HashSet<Node>();

            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                Console.WriteLine(current);
                visited.Add(current);

                _adjacencyList.TryGetValue(current, out List<Node> neighbors);
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }
        }

        public void BreadthFirstIterative(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            var visited = new HashSet<Node>();

            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                Console.WriteLine(current);
                visited.Add(current);

                _adjacencyList.TryGetValue(current, out List<Node> neighbors);
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }
        }

        public List<string> TopologicalSort()
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();

            foreach (var node in _nodes.Values)
            {
                TopologicalSort(node, visited, stack);
            }

            var res = new List<string>();
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                res.Add(current.Label);
            }

            return res;
        }

        private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
        {
            if (visited.Contains(node))
                return;

            visited.Add(node);

            _adjacencyList.TryGetValue(node, out List<Node> neighbors);
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                    TopologicalSort(neighbor, visited, stack);
            }

            stack.Push(node);
        }

        public bool HasCycle()
        {
            var all = new HashSet<Node>(_nodes.Values);
            var visiting = new HashSet<Node>();
            var visited = new HashSet<Node>();
            
            while (all.Count > 0)
            {
                var current = all.First();

                if (HasCycle(current, all, visiting, visited))
                    return true;
            }

            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node);

            _adjacencyList.TryGetValue(node, out List<Node> neighbors);
            foreach (var neighbor in neighbors)
            {
                if (visited.Contains(neighbor))
                    continue;

                if (visiting.Contains(neighbor))
                    return true;

                if (HasCycle(neighbor, all, visiting, visited))
                    return true;
            }

            visiting.Remove(node);
            visited.Add(node);
            return false;
        }

        public void Print()
        {
            foreach (var kvp in _adjacencyList)
            {
                var source = kvp.Key;
                var targets = kvp.Value;
                if (targets.Count > 0)
                {
                    Console.WriteLine($"{source.Label} is connected with {GetTargetsString(targets)}");
                }
            }
        }

        private string GetTargetsString(List<Node> nodes)
        {
            var sb = new StringBuilder();

            sb.Append('[');
            foreach (var node in nodes)
            {
                sb.Append(node.Label);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');

            return sb.ToString();
        }
    }


    public class Node
    {
        public string Label;

        public Node(string label)
        {
            Label = label;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}
