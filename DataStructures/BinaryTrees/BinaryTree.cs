namespace BinaryTrees
{
    public class Tree
    {
        // A tree is a graph without cycles
        // In binary tree a node can have up to two children
        // The height of a node = number of edges from that node to it's furthest child leaf
        // The height of a leaf = 0
        // The height of a tree = the height of it's root (which is the longest path to a leaf)
        // The depth of a node = number of edges from that node to the root
        // The depth of a root is 0

        // In Binary Search Tree all left children are smaller than the node and all right children are greater than the node

        private Node _root;

        public void Insert(int value)
        {
            var node = new Node(value);

            if (_root == null)
            {
                _root = node;
                return;
            }

            var current = _root;
            while (true)
            {
                if (value < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                        break;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                        break;
                    }
                    current = current.RightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var current = _root;
            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftChild;
                else if (value > current.Value)
                    current = current.RightChild;
                else
                    return true;
            }
            return false;
        }


        // 1. Depth First Traversal (3 types):
        public void DepthFirstTraversal()
        {
            DFT_PreOrder(_root);   // root left right
            DFT_InOrder(_root);    // left root right
            DFT_PostOrder(_root);  // left right root
        }

        private void DFT_PreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root);
            DFT_PreOrder(root.LeftChild);
            DFT_PreOrder(root.RightChild);
        }

        private void DFT_InOrder(Node root)
        {
            if (root == null)
                return;

            DFT_InOrder(root.LeftChild);
            Console.WriteLine(root);
            DFT_InOrder(root.RightChild);
        }

        private void DFT_PostOrder(Node root)
        {
            if (root == null)
                return;

            DFT_PostOrder(root.LeftChild);
            DFT_PostOrder(root.RightChild);
            Console.WriteLine(root);
        }


        // 2. Height of tree:
        public int Height()
        {
            return Height(_root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return - 1;
            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }


        // 3. Find minimum value:
        public int MinValue()
        {
            return MinValue(_root);
        }

        private int MinValue(Node root)
        {
            if (root.LeftChild == null && root.RightChild == null)
                return root.Value;

            int minLeft = MinValue(root.LeftChild);
            int minRight = MinValue(root.RightChild);
            var min = Math.Min(minLeft, minRight);
            return Math.Min(min, root.Value);

        }


        // 4. Equality of 2 trees:
        public bool Equals (Tree other)
        {
            if (other == null)
                return false;

            return Equals(_root, other._root);
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if(first != null && second != null)
            {
                return first.Value == second.Value &&
                       Equals(first.LeftChild, second.LeftChild) &&
                       Equals(first.RightChild, second.RightChild);
            }

            return false;
        }


        // 5. Check if Tree is a Binary Search Tree:
        public bool IsBST()
        {
            return IsBST(_root);
        }

        private bool IsBST(Node root, int min = int.MinValue, int max = int.MaxValue)
        {
            if (root == null)
                return true;

            if (root.Value < min || root.Value > max)
                return false;

            return IsBST(root.LeftChild, min, root.Value - 1) &&
                   IsBST(root.RightChild, root.Value + 1, max);
        }


        // 6. Nodes at K distance from the root:
        public List<Node> NodesAtDistance(int k)
        {
            var list = new List<Node>();
            NodesAtDistance(_root, k, list);
            return list;
        }

        private void NodesAtDistance(Node root, int k, List<Node> list)
        {
            if (root == null)
                return;

            if (k == 0)
            {
                list.Add(root);
            }

            k--;
            NodesAtDistance(root.LeftChild, k, list);
            NodesAtDistance(root.RightChild, k, list);
        }


        // 7. Level order traversal (Breadth First):
        public void LevelOrderTraversal()
        {
            int height = Height();
            for (int i = 0; i <= height; i++)
            {
                var list = NodesAtDistance(i);
                foreach (var node in list)
                {
                    Console.WriteLine(node);
                }
            }
        }


        // 8. Nodes count:
        public int NodesCount()
        {
            return NodesCount(_root);
        }

        private int NodesCount(Node root)
        {
            if (root == null)
                return 0;

            if (root.LeftChild == null && root.RightChild == null)
                return 1;

            return 1 + NodesCount(root.LeftChild) + NodesCount(root.RightChild);
        }


        // 9. Leaves count:
        public int LeavesCount()
        {
            return LeavesCount(_root);
        }

        private int LeavesCount(Node root)
        {
            if (root == null)
                return 0;

            if (root.LeftChild == null && root.RightChild == null)
                return 1;

            return LeavesCount(root.LeftChild) + LeavesCount(root.RightChild);
        }


        // 10. Max value:
        public int MaxValue()
        {
            return MaxValue(_root);
        }

        private int MaxValue(Node root)
        {
            if (root.RightChild == null)
                return root.Value;

            return MaxValue(root.RightChild);
        }


        // 11. Contains:
        public bool Contains(int val)
        {
            return Contains(_root, val);
        }

        private bool Contains(Node root, int val)
        {
            if (root == null)
                return false;

            if (root.Value == val)
                return true;

            return Contains(root.LeftChild, val) || Contains(root.RightChild, val);
        }


        // 12. Siblings:
        public bool Siblings(int val1, int val2)
        {
            return Siblings(_root, val1, val2);
        }

        private bool Siblings(Node root, int val1, int val2)
        {
            if (root.LeftChild == null || root.RightChild == null)
                return false;

            if (root.LeftChild.Value == val1 && root.RightChild.Value == val2 ||
                root.LeftChild.Value == val2 && root.RightChild.Value == val1)
            {
                return true;
            }

            return Siblings(root.LeftChild, val1, val2) || Siblings(root.RightChild, val1, val2);
        }


        // 13. Get ancestors:
        public List<int> GetAncestors(int val)
        {
            var list = new List<int>();
            GetAncestors(_root, val, list);
            return list;
        }

        private bool GetAncestors(Node root, int val, List<int> list)
        {
            if (root == null)
                return false;

            if (root.Value == val)
                return true;

            if(GetAncestors(root.LeftChild, val, list) || GetAncestors(root.RightChild, val, list))
            {
                list.Add(root.Value);
                return true;
            }

            return false;
        }


        // 14. Is balanced:
        public bool IsBalanced()
        {
            return IsBalanced(_root);
        }

        private bool IsBalanced(Node root)
        {
            if (root == null)
                return true;

            int balanceFactor = Height(root.LeftChild) - Height(root.RightChild);

            return Math.Abs(balanceFactor) <= 1 &&
                   IsBalanced(root.LeftChild) &&
                   IsBalanced(root.RightChild);
        }


        // 15. Is perfect:
        public bool IsPerfect()
        {
            return NodesCount() == (Math.Pow(2, Height() + 1) - 1);
        }
    }

    public class Node
    {
        public int Value;
        public Node LeftChild;
        public Node RightChild;

        public Node(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "Node=" + Value;
        }
    }
}
