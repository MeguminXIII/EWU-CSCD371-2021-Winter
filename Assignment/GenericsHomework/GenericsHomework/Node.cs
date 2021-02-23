using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<T>
    {
        private T? _Data;
        private Node<T>? _Next;

        public T Data { get => _Data!; private set => _Data = value ?? throw new ArgumentNullException(nameof(value)); }
        
        public Node<T> Next
        {
            get => _Next!; set
            {
                value._Next = this;
                _Next = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public Node(T tvalue)
        {
            Data = tvalue;
            Next = this;
        }

        public override string ToString()
        {
            if (Data is null) throw new ArgumentNullException(nameof(Data));
           
            return Data.ToString()! ?? "Null";
        }

        public void Insert(T value)
        {
            Node<T> newNode = new(value);
            this.Next = newNode;
        }

        public void Clear()
        {
            this.Next = this;
            // The Garbage Collector should be able to tell that the other nodes are unreachable, so it should collect them 
              
        }

        private int Size()
        {
            Node<T> currentNode = this.Next;
            int count = 1;
            while(currentNode != this)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this;

            yield return currentNode.Data;
            foreach(T item in this)
            {
                yield return currentNode.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<T> ChildItems(int maximum)
        {
            if (maximum > this.Size() || maximum < 0)
                throw new ArgumentOutOfRangeException(nameof(maximum));

            Node<T> currentNode = this;
            int i;
            for (i = 0; i < maximum; i++, currentNode = currentNode.Next)
                yield return currentNode.Data;
        }
    }
}
