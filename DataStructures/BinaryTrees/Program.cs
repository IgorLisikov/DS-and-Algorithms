using BinaryTrees;


// Create BST tree that looks like this:
//                 7
//               /   \
//             4       9
//            / \     / \
//           1   6   8   10

var tree = new Tree();
tree.Insert(7);
tree.Insert(4);
tree.Insert(9);
tree.Insert(1);
tree.Insert(6);
tree.Insert(8);
tree.Insert(10);


//1.Depth First Traversal:
tree.DepthFirstTraversal();

//2.Height of tree:
Console.WriteLine(tree.Height());  // 2

//3.Find minimum value:
Console.WriteLine(tree.MinValue());  // 1

//4.Equality of 2 trees:
var tree2 = new Tree();
tree2.Insert(7);
tree2.Insert(4);
tree2.Insert(9);
tree2.Insert(1);
tree2.Insert(6);
tree2.Insert(8);
tree2.Insert(10);
Console.WriteLine(tree.Equals(tree2));  // true


//5.Check if Tree is a Binary Search Tree:
Console.WriteLine(tree.IsBST());        // true


//6.Nodes at K distance from the root:
var res = tree.NodesAtDistance(0);
Console.WriteLine();


//7.Level order traversal(Breadth First):
tree.LevelOrderTraversal();
Console.WriteLine();


//8.Nodes count:
Console.WriteLine(tree.NodesCount());   // 7


//9.Leaves count:
Console.WriteLine(tree.LeavesCount());  // 4


//10.Max value:
Console.WriteLine(tree.MaxValue());     // 10


//11.Contains:
Console.WriteLine(tree.Contains(10));   // true


//12.Siblings:
Console.WriteLine(tree.Siblings(1, 6));  // true


//13.Get ancestors:
var res1 = tree.GetAncestors(6);
Console.WriteLine();


// 14.Is balanced:
Console.WriteLine(tree.IsBalanced());   // true


// 15. Is perfect:
Console.WriteLine(tree.IsPerfect());   // true
