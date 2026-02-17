namespace Tries
{
    public class Trie
    {
        // Trie is not binary tree - each node can have several children
        // Trie can be used to implement autocompletion

        private Node _root = new Node(' ');


        public void Insert(string word)
        {
            var current = _root;
            foreach (var c in word.ToCharArray())
            {
                if (!current.HasChild(c))
                    current.AddChild(c);

                current = current.GetChild(c);
            }

            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var current = _root;
            foreach (var c in word.ToCharArray())
            {
                if (!current.HasChild(c))
                    return false;

                current = current.GetChild(c);
            }

            if (current.IsEndOfWord)
            {
                return true;
            }

            return false;
        }

        public void Traverse()
        {
            Traverse(_root);
        }

        private void Traverse(Node node)  // Depth First
        {
            Console.WriteLine(node.Value);  // pre-order traversal (start from root)
            foreach (var child in node.GetChildren())
            {
                Traverse(child);
            }

            //Console.WriteLine(node.Value);  // post-order traversal (start from leaves)
        }

        public void Remove(string word)
        {
            if (string.IsNullOrEmpty(word))
                return;

            Remove(_root, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.IsEndOfWord = false;
                return;
            }

            var child = root.GetChild(word[index]);
            if (child == null)
                return;

            Remove(child, word, index + 1);

            if (!child.HasChildren() && !child.IsEndOfWord)
            {
                root.RemoveChild(word[index]);
            }
        }

        public List<string> AutoComplete(string word)
        {
            var results = new List<string>();

            var root = FindLastNodeOf(word);

            AutoComplete(root, word, results);
            return results;
        }

        private void AutoComplete(Node root, string currentWord, List<string> results)
        {
            if (root == null)
                return;

            if (root.IsEndOfWord)
                results.Add(currentWord);

            foreach (var child in root.GetChildren())
            {
                AutoComplete(child, currentWord + child.Value, results);
            }
        }

        private Node FindLastNodeOf(string prefix)
        {
            if (prefix == null)
                return null;

            var current = _root;
            foreach (var c in prefix.ToCharArray())
            {
                if (!current.HasChild(c))
                    return null;

                current = current.GetChild(c);
            }

            return current;
        }
    }


    public class Node
    {
        public char Value;
        public Dictionary<char, Node> Children = new ();
        public bool IsEndOfWord;

        public Node(char value)
        {
            Value = value;
        }


        public Node GetChild(char c)
        {
            Children.TryGetValue(c, out Node node);
            return node;
        }

        public bool HasChild(char c)
        {
            return Children.ContainsKey(c);
        }

        public void AddChild(char c)
        {
            Children.Add(c, new Node(c));
        }

        public Node[] GetChildren()
        {
            return Children.Values.ToArray();
        }

        public bool HasChildren()
        {
            return Children.Count() > 0;
        }

        public void RemoveChild(char ch)
        {
            Children.Remove(ch);
        }

        public override string ToString()
        {
            return "Value=" + Value;
        }
    }
}
