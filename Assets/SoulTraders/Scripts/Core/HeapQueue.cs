using System;
using System.Collections.Generic;

namespace SoulTraders.Core
{

    /// <summary>
    /// HeapQueue provides a queue collection that is always ordered.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HeapQueue<T> where T : IComparable<T>
    {
        List<T> items;

        public int Count { get { return items.Count; } }

        public bool isEmpty { get { return items.Count == 0; } }

        public T First { get { return items[0]; } }

        public void Clear() => items.Clear();

        public bool Contains(T item) => items.Contains(item);

        public void Remove(T item) => items.Remove(item);

        public T Peek() => items[0];

        public HeapQueue()
        {
            items = new List<T>();
        }

        /// <summary>
        /// Adds an item to the queue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Push(T item)
        {
            // Add item to end of list
            items.Add(item);
            // find correct pos for new item
            SiftDown(0, items.Count - 1);
        }


        /// <summary>
        /// Removes last item from the queue
        /// </summary>
        public T Pop()
        {
            //if there are more than 1 items, returned item will be first in tree.
            //then, add last item to front of tree, shrink the list
            //and find correct index in tree for first item.
            T item;
            var last = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            if (items.Count > 0)
            {
                item = items[0];
                items[0] = last;
                SiftUp();
            }
            else
            {
                item = last;
            }
            return item;
        }

        int Compare(T A, T B) => A.CompareTo(B);

        void SiftDown(int startpos, int pos)
        {
            //preserve the newly added item.
            var newitem = items[pos];
            while (pos > startpos)
            {
                //find parent index in binary tree
                var parentpos = (pos - 1) >> 1;
                var parent = items[parentpos];
                //if new item precedes or equal to parent, pos is new item position.
                if (Compare(parent, newitem) <= 0)
                    break;
                //else move parent into pos, then repeat for grand parent.
                items[pos] = parent;
                pos = parentpos;
            }
            items[pos] = newitem;
        }

        void SiftUp()
        {
            var endpos = items.Count;
            var startpos = 0;
            //preserve the inserted item
            var newitem = items[0];
            var childpos = 1;
            var pos = 0;
            //find child position to insert into binary tree
            while (childpos < endpos)
            {
                //get right branch
                var rightpos = childpos + 1;
                //if right branch should precede left branch, move right branch up the tree
                if (rightpos < endpos && Compare(items[rightpos], items[childpos]) <= 0)
                    childpos = rightpos;
                //move child up the tree
                items[pos] = items[childpos];
                pos = childpos;
                //move down the tree and repeat.
                childpos = 2 * pos + 1;
            }
            //the child position for the new item.
            items[pos] = newitem;
            SiftDown(startpos, pos);
        }


    }
}