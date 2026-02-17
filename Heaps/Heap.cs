namespace Heaps
{
    public class Heap
    {
        // Heap is a complete BST (every level is filled with nodes from left to right, except potentially the last level)
        // Unlike BST, in heap every node is greater than or equal to it's children (if it is max heap). So the max value is always in the root.
        // Heap can be used to implement priority queue.

        private int[] _items = new int[10];
        private int _size;

        public void Insert(int value)
        {
            // Insert into the leaf and bubble it up until it is in the right place
            if(_size == _items.Length)
                throw new ArgumentOutOfRangeException();

            _items[_size++] = value;

            BubbleUp();
        }

        public int Remove()
        {
            // Remove from the root, make the last leaf to be the root and bubble it down until it is in the right place
            if (_size == 0)
                throw new ArgumentOutOfRangeException();

            int root = _items[0];
            _items[0] = _items[--_size];
            BubbleDown();

            return root;
        }

        private void Swap(int first, int second)
        {
            int temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }

        private void BubbleUp()
        {
            // take the last leaf and bubble it up:
            int index = _size - 1;
            int parentIndex = (index - 1) / 2;
            while (index > 0 && _items[index] > _items[parentIndex])
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void BubbleDown()
        {
            // take the root and bubble it down:
            int index = 0;
            // until all children are smaller, continue swapping with largest child
            while (index <= _size && !IsValidParent(index))
            {
                int childIndex = IndexOfLargestChild(index);

                Swap(index, childIndex);
                index = childIndex;
            }
        }

        private bool IsValidParent(int index)
        {
            // It is valid if it has no left child (in that case right child can't exist either)
            if (!HasLeftChild(index))
                return true;

            // if left child exists - it should be smaller
            bool leftIsSmaller = _items[index] >= _items[LeftChildIndex(index)];
            if (!HasRightChild(index))
                return leftIsSmaller;

            // if right child exists - it should be also smaller
            bool rightIsSmaller = _items[index] >= _items[RightChildIndex(index)];
            return leftIsSmaller && rightIsSmaller;
        }

        private int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }
        private int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private int IndexOfLargestChild(int index)
        {
            if(!HasLeftChild(index))
                throw new IndexOutOfRangeException();

            int leftChildIndex = LeftChildIndex(index);
            if(!HasRightChild(index))
                return leftChildIndex;

            int rightChildIndex = RightChildIndex(index);
            if(_items[leftChildIndex] >= _items[rightChildIndex])
            {
                return leftChildIndex;
            }
            else
            {
                return rightChildIndex;
            }
        }

        private bool HasLeftChild(int index)
        {
            int childIndexLeft = 2 * index + 1;
            return childIndexLeft < _size;
        }
        private bool HasRightChild(int index)
        {
            int childIndexLeft = 2 * index + 2;
            return childIndexLeft < _size;
        }
    }
}
