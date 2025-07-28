using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetTracker
{
    public class OurList<T> : ICollection<T>, IEnumerable<T>
    {
        
        private class Node
        {
            public T Data { get; set; }
            
            public Node Next { get; set; } 
            public Node(T d = default(T), Node node = null)
            {
                Data = d;
                Next = node;
            }
        }
        private Node first;
        public OurList()     // shown in class
        {
            first = null;
        }

        /// <summary>
        /// Make a list empty (e.g. clear the contents)
        /// </summary>
        public void Clear()     // shown in class
        {
            first = null;
        }

        /// <summary>
        /// Since first is private, the user of class needs a way to tell if the list is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()     // shown in class
        {
            return first == null;
        }

        /// <summary>
        /// Adds an item to the front of the list
        /// </summary>
        /// <param name="value"></param>
        public void AddFront(T value)     // shown in class
        {
            first = new Node(value, first);
        }

        /// <summary>
        /// Removes the first item from the list if it exists
        /// </summary>
        public void RemoveFirst()     // shown in class
        {
            if (first != null)
                first = first.Next;
        }

        /// <summary>
        /// Returns the number of items in a list
        /// </summary>
        /// <remarks> Show how to hop down a list </remarks>
        public int Count
        {
            get 
            {
                int count = 0;
                Node pTmp = first;  // point to first node
                while (pTmp != null)    // keep hopping down the list until pTmp has fallen off the end
                {
                    count++;
                    pTmp = pTmp.Next;   // a single hop
                }
                return count;
            }
        }
        /// <summary>
        /// Adds an item to the end of the list
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)     // shown in class
        {
            if (first == null)
                AddFront(value);
            else
            {
                Node mTmp = first;  // point to first node
                while (mTmp.Next != null)   // hop to last node
                    mTmp = mTmp.Next;

                mTmp.Next = new Node(value, null);
            }
        }

        /// <summary>
        /// Remove the last item from a list if it exists
        /// </summary>
        public void RemoveLast()     // shown in class
        {
            if (first == null)
                return;
            else if (first.Next == null)  // can't stop at previous node
                RemoveFirst();
            else
            {
                Node pTmp = first;
                while (pTmp.Next.Next != null)  // stop at 2nd to last node
                        pTmp = pTmp.Next;

                pTmp.Next = null;
            }
        }

        /// <summary>
        /// If index equals the number of items in the IList, then value is appended to the end. 
        /// </summary>
        /// <param name="index">Zero-based</param>
        /// <param name="value"></param>     
        public void InsertAt(int index, T value)
        {
            if (index >= 0 && index <= Count)
            {
                if (index == 0)
                    AddFront(value);
                else if (index == Count)
                    AddLast(value);
                else
                {
                    Node pTmp = first;
                    for (int i = 0; i < index - 1; i++) // Hop to node in front of the index position
                        pTmp = pTmp.Next;

                    // Make node in front point to new node and new node point to next node
                    // In other words, slip a new node between node in front and node previously at 
                    // the index position
                    pTmp.Next = new Node(value, pTmp.Next); 
                }
            }
            else
                throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Remove the item at the index position. 
        /// </summary>
        /// <param name="index"> Zero based </param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                if (index == 0)
                    RemoveFirst();
                else if (index == (Count - 1))
                    RemoveLast();
                else
                {
                    Node pTmp = first;
                    for (int i = 0; i < index - 1; i++)  // Stop at node in front of node to be remove
                        pTmp = pTmp.Next;
                    pTmp.Next = pTmp.Next.Next; // Make node in front skip over node to remove
                }
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Adds an item to end
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            AddLast(value);
        }

        /// <summary>
        /// Determines if item is in the list
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if item is found on list; otherwise returns false</returns>
        public bool Contains(T value)
        {
            Node pTmp = first;
            while (pTmp != null)
            {
                if (pTmp.Data.Equals(value))
                    return true;
                pTmp = pTmp.Next;
            }
            return false;
        }
        
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes first occurence of item on the list
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if item successfully remove; otherwise returns false</returns>
        public bool Remove(T value)
        {
            if (IsEmpty() == true)
                return false;

            if (first.Data.Equals(value))
            {
                RemoveFirst();
                return true;
            }
            else
            {
                Node pTmp = first;

                while (pTmp.Next != null)
                {
                    if (pTmp.Next.Data.Equals(value)) // finds node in front of value
                    {
                        pTmp.Next = pTmp.Next.Next; // makes node in front skip over the node with value
                        return true;
                    }
                    pTmp = pTmp.Next;
                }
            }
            return false; // only gets here if value was not in the list
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
             Node pTmp = first;
            while (pTmp != null)
            {
                yield return pTmp.Data;
                pTmp = pTmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns a string with every item. Each item's ToString() method is used.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsEmpty() == true)
                return string.Empty;
            StringBuilder returnString = new StringBuilder();
            foreach (T item in this)
            {
                if (returnString.Length > 0)
                    returnString.Append(":");
                returnString.Append(item);
            }
            return returnString.ToString();
        }
        
        public void MyReversal()
        {
            if (first == null)
            {
                return;
            }

            Node current = first;
            Node prev = null;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            first = prev;
        }

        public int minDistance(T value)
        {
            if (first == null)
            {
                throw new Exception("List is empty");
            }

            Node ptmp = first;
            int dist = 0;
            int minDist = -1;
            bool found = false;
            
            while (ptmp != null)
            {
                if (ptmp.Data.Equals(value))
                {
                    if (found)
                    {
                        if (minDist == -1 || dist < minDist)
                        {
                            minDist = dist;
                        }

                        dist = 0;
                    }
                    else
                    {
                        found = true;
                        dist = 0;
                    }
                }
                else if(found)
                {
                    dist++;
                }
                ptmp = ptmp.Next;
            }
            return minDist;
        }

        public List<T> ToList()
        {
            List<T> result = new List<T>();
            Node current = first;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }
            return result;
        }
        public void LoadFromList(List<T> items)
        {
            first = null;
            for (int i = items.Count - 1; i >= 0; i--)
            {
                AddFront(items[i]);
            }
        }
    }
}

