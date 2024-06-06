using System;
using System.Collections.Generic;

namespace proyectofp.DataStructures
{
    public class LinkedListNode<T>
    {
        public T Value;
        public LinkedListNode<T> Next;

        public LinkedListNode(T value)
        {
            Value = value;
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;

        public void AddLast(T value)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(value);
            }
            else
            {
                LinkedListNode<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new LinkedListNode<T>(value);
            }
        }

        public T Find(T value)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return default(T);
        }

        public void Delete(T value)
        {
            if (head == null)
                return;

            if (head.Value.Equals(value))
            {
                head = head.Next;
                return;
            }

            LinkedListNode<T> current = head;
            while (current.Next != null)
            {
                if (current.Next.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        public void Update(T oldValue, T newValue)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.Equals(oldValue))
                {
                    current.Value = newValue;
                    return;
                }
                current = current.Next;
            }
            throw new KeyNotFoundException("Value not found");
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            LinkedListNode<T> current = head;
            while (current != null)
            {
                list.Add(current.Value);
                current = current.Next;
            }
            return list;
        }
    }
}
