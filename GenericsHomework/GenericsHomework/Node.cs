using System;

namespace GenericsHomework
{
    public class Node<T>
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
    }
}
