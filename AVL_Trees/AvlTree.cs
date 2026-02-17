namespace AVL_Trees
{
    public class AvlTree
    {
        // AVL Trees are self-balancing BST

        private AvlNode _root;

        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }

        private AvlNode Insert(AvlNode root, int value)
        {
            if (root == null)
                return new AvlNode(value);

            if (value < root.Value)
                root.LeftChild = Insert(root.LeftChild, value);

            else
                root.RightChild = Insert(root.RightChild, value);

            SetHeight(root);

            return Balance(root);
        }

        private int Height(AvlNode node)
        {
            return node != null ? node.Height : -1;
        }

        private bool IsLeftHeavy(AvlNode node)
        {
            //       (1)  30  (-1)      1 - (-1) = 2      30 is left heavy
            //            /
            //     (0)  20  (-1)        0 - (-1) = 1
            //          /
            //  (-1)  10  (-1)         -1 - (-1) = 0
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(AvlNode node)
        {
            //  (-1)  10  (1)         -1 - 1 = -2        10 is right heavy
            //         \
            //    (-1)  20  (0)       -1 - 0 = -1
            //           \
            //      (-1)  30  (-1)    -1 - (-1) = 0
            return BalanceFactor(node) < -1;
        }
        private int BalanceFactor(AvlNode node)
        {
            // Compare heights of left subtree and right subtree:

            // numbers in braces are heights of child nodes (subtrees)!
            //  (-1)  10  (1)         -1 - 1 = -2
            //         \
            //    (-1)  20  (0)       -1 - 0 = -1
            //           \
            //      (-1)  30  (-1)    -1 - (-1) = 0
            return (node == null) ? 0 : Height(node.LeftChild) - Height(node.RightChild);
        }

        private AvlNode Balance(AvlNode root)
        {
            // ---------- Visualization ----------
            if (IsLeftHeavy(root))
            {
                //       (1)  30  (-1)      1 - (-1) = 2    root > 1        --> root is left heavy; need to check left child to determine rotations
                //            /
                //     (0)  20  (-1)        0 - (-1) = 1
                //          /
                //  (-1)  10  (-1)         -1 - (-1) = 0
                Console.WriteLine($"Root ({root.Value}) is left heavy");

                if (BalanceFactor(root.LeftChild) < 0)
                {
                    //       (1)  30  (-1)      1 - (-1) = 2
                    //            /
                    //     (-1)  10  (0)       -1 - 0 = -1      left child < 0  --> start with extra rotation - rotate left child (10) to the left
                    //            \
                    //       (-1)  20  (-1)    -1 - (-1) = 0
                    Console.WriteLine($"Start with extra rotation: rotate left child ({root.LeftChild}) to the left");
                }
                // in other case - left child > 0:
                //       (1)  30  (-1)      1 - (-1) = 2
                //            /
                //     (0)  20  (-1)        0 - (-1) = 1    left child > 0 --> no extra rotation needed
                //          /
                //  (-1)  10  (-1)         -1 - (-1) = 0

                // always rotate root (30) to the right:
                Console.WriteLine($"Rotate root ({root}) to the right");
            }
            else if (IsRightHeavy(root))
            {
                //  (-1)  10  (1)         -1 - 1 = -2    root < -1        --> root is right heavy; need to check right child to determine rotations
                //         \
                //    (-1)  20  (0)       -1 - 0 = -1
                //           \
                //      (-1)  30  (-1)    -1 - (-1) = 0
                Console.WriteLine($"Root ({root.Value}) is right heavy");

                if (BalanceFactor(root.RightChild) > 0)
                {
                    //  (-1)  10  (1)         -1 - 1 = -2
                    //         \
                    //     (0)  30  (-1)       0 - (-1) = 1    right child > 0  --> start with extra rotation - rotate right child (30) to the right
                    //         /
                    //  (-1)  20  (-1)        -1 - (-1) = 0
                    Console.WriteLine($"Start with extra rotation: rotate right child ({root.RightChild}) to the right");
                }
                // in other case - right child < 0:
                //  (-1)  10  (1)         -1 - 1 = -2
                //         \
                //    (-1)  20  (0)       -1 - 0 = -1    right child < 0 --> no extra rotation needed
                //           \
                //      (-1)  30  (-1)    -1 - (-1) = 0

                // always  rotate root (10) to the left:
                Console.WriteLine($"Rotate root ({root}) to the left");
            }


            // ---------- Implementation ----------
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.LeftChild) < 0)
                {
                    // start with extra rotation - rotate left child to the left:
                    root.LeftChild = RotateLeft(root.LeftChild);
                }

                // always rotate root to the right:
                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.RightChild) > 0)
                {
                    // start with extra rotation - rotate right child to the right:
                    root.RightChild = RotateRight(root.RightChild);
                }

                // always  rotate root to the left:
                return RotateLeft(root);
            }

            return root;
        }

        private AvlNode RotateLeft(AvlNode root)
        {
            //    10  root
            //      \
            //       20  newRoot     =>        20        =>       20
            //      /  \                     /    \             /    \
            //    15    30                  10    30           10    30
            //                                                   \
            //                                                    15


            var newRoot = root.RightChild;
            root.RightChild = newRoot.LeftChild;
            newRoot.LeftChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private AvlNode RotateRight(AvlNode root)
        {
            //         30  root
            //        /    
            //       15  newRoot     =>       15       =>        15
            //      /  \                     /  \               /  \
            //    10    20                 10    30           10    30
            //                                                     /
            //                                                    20


            var newRoot = root.LeftChild;
            root.LeftChild = newRoot.RightChild;
            newRoot.RightChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;

        }

        private void SetHeight(AvlNode node)
        {
            node.Height = Math.Max(Height(node.LeftChild), Height(node.RightChild)) + 1;
        }

    }
    public class AvlNode
    {
        public int Value;
        public AvlNode LeftChild;
        public AvlNode RightChild;
        public int Height;

        public AvlNode(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "Node=" + Value;
        }
    }
}
