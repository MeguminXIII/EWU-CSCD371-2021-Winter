using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericsHomework
{
    public class Node<T> : IEnumerable<T>
    {
        private Node<T> _Next;
        private T? _Data;

        public T Data { get => _Data!; private set => _Data = value ?? throw new ArgumentNullException(nameof(value)); }
        
        public Node<T> Next
        {
            get { return _Next; }
            private set
            {
                value._Next = this._Next;
                _Next = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public Node(T tvalue)
        {
            _Next = this;
            Data = tvalue;
        }

        public override string ToString()
        {
            if (Data is null) throw new ArgumentNullException(nameof(Data));
           
            return Data.ToString()! ?? "Null";
        }

        public Node<T> Insert(T value)
        {
            Node<T> newNode = new(value);
            this.Next = newNode;
            return newNode;
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
            while (currentNode != this)
               currentNode = currentNode.Next;
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
            for (int i = 0; i < maximum; currentNode = currentNode.Next, i++)
                yield return currentNode.Data;
                
        }
    }
}
