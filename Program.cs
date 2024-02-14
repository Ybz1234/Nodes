using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> head = new Node<int>(10);
            Node<int> node2 = new Node<int>(20);
            Node<int> node3 = new Node<int>(30);

            head.SetNext(node2);
            node2.SetNext(node3);

            Console.WriteLine(head);
            Console.WriteLine("Sum = " + SumNodes(head));
            Console.WriteLine("Max value = " + MaxValueNode(head));

            Addition(head, 5);
            AddLast(head, 8);
            Console.WriteLine(head);

            Node<int> nullHead = null;
            AddLast2(ref nullHead, 2);
            Console.WriteLine(nullHead);

            AddSecondLast(ref head, 9875);
            Console.WriteLine(head);

            Console.WriteLine($"Nodes counter from program: {NumberOfNodes(head)}");
            Console.WriteLine($"Nodes counter from Node<T>: {head.NumberOfNodes()}");
        }
        static void AddSecondLast<T>(ref Node<T> head, T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null || !head.HasNext())
            {
                node.SetNext(head);
                head = node;
            }
            else
            {
                Node<T> secondLastNode = head;
                while (secondLastNode.GetNext().HasNext())
                {
                    secondLastNode = secondLastNode.GetNext();
                }
                node.SetNext(secondLastNode.GetNext());
                secondLastNode.SetNext(node);
            }
        }
        static int NumberOfNodes<T>(Node<T> head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.GetNext();
            }
            return count;
        }
        static void AddLast<T>(Node<T> head, T value)
        {
            Node<T> newNode = new Node<T>(value);
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            head.SetNext(newNode);
        }
        static void AddLast2<T>(ref Node<T> head, T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> lastNode = head;
                while (lastNode.HasNext())
                {
                    lastNode = lastNode.GetNext();
                }
                lastNode.SetNext(newNode);
            }
        }
        static int SumNodes(Node<int> head)
        {
            return head == null ? 0 : head.GetValue() + SumNodes(head.GetNext());
        }
        static int MaxValueNode(Node<int> head)
        {
            int max = 0;
            Node<int> node = head;
            while (node != null)
            {
                if (node.GetValue() > max) max = node.GetValue();
                node = node.GetNext();
            }
            return max;
        }
        static void Addition(Node<int> head, int value)
        {
            Node<int> node = head;
            while (node != null)
            {
                node.SetValue(node.GetValue() + value);
                node = node.GetNext();
            }
            Console.WriteLine(head.ToString());
        }
    }
}
