using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPriorityQueue<T>
{
    private class Node
    {
        public T Value { get; set; }
        public int Priority { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T value, int priority)
        {
            Value = value;
            Priority = priority;
            Next = null;
            Previous = null;
        }
    }

    private Node Head { get; set; }
    private Node Tail { get; set; }
    private int length = 0;

    public void PriorityEnqueue(T value, int priority)
    {
        Node newNode = new Node(value, priority);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            length++;
        }
        else
        {
            Node current = Head;
            while (current != null && current.Priority <= priority)
            {
                current = current.Next;
            }

            if (current == null)
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
            else if (current.Previous == null)
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
            else
            {
                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous.Next = newNode;
                current.Previous = newNode;
            }

            length++;
        }
    }

    public T PriorityDequeue()
    {
        if (Head == null)
        {
            throw new System.NullReferenceException("Empty queue");
        }

        Node dequeued = Head;
        Head = Head.Next;
        if (Head != null)
        {
            Head.Previous = null;
        }
        else
        {
            Tail = null;
        }
        length--;
        return dequeued.Value;
    }
}