using AVL_Trees;



// Create AVL tree that looks like this:
//                 7
//               /   \
//             4       9
//            / \     / \
//           1   6   8   10

var tree = new AvlTree();
tree.Insert(7);
tree.Insert(4);
tree.Insert(9);
tree.Insert(1);
tree.Insert(6);
tree.Insert(8);
tree.Insert(10);

tree.Insert(20);
tree.Insert(30);


//Test rotations #1:
tree = new AvlTree();
tree.Insert(10);
tree.Insert(20);
tree.Insert(30);

//Test rotations #2:
tree = new AvlTree();
tree.Insert(10);
tree.Insert(30);
tree.Insert(20);
