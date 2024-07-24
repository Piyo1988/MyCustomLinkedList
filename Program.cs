using System;

namespace CustomLinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddLast(5);

            Console.WriteLine("List after adding elements:");
            list.PrintList();

            list.RemoveFirst();
            Console.WriteLine("List after removing first element:");
            list.PrintList();

            list.RemoveLast();
            Console.WriteLine("List after removing last element:");
            list.PrintList();

            list.Insert(2, 10);
            Console.WriteLine("List after inserting 10 at position 2:");
            list.PrintList();

            list.Insert(0, 0);
            Console.WriteLine("List after inserting 0 at position 0:");
            list.PrintList();

            list.RemoveAt(2);
            Console.WriteLine("List after removing element at position 3:");
            list.PrintList();
        }
    }

    public class LinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            head = null;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = head;
            head = newNode;
        }

        public void AddLast(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(data);
            }
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
            }
        }

        public void RemoveLast()
        {
            if (head == null) return;

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }

        public void Insert(int position, T data)
        {
            if (position < 0) throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");

            Node<T> newNode = new Node<T>(data);

            if (position == 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            Node<T> current = head;
            for (int i = 0; i < position - 1; i++)
            {
                if (current == null) throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
                current = current.Next;
            }

            if (current == null) throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void RemoveAt(int position)
        {
            if (position < 0) throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");

            if (head == null) throw new InvalidOperationException("Provided list is empty.");

            if (position == 0)
            {
                head = head.Next;
                return;
            }

            Node<T> current = head;
            for (int i = 0; i < position - 1; i++)
            {
                if (current.Next == null) throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
                current = current.Next;
            }

            if (current.Next == null) throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");

            current.Next = current.Next.Next;
        }

        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
