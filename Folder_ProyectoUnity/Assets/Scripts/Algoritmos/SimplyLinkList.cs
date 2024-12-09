using System.Collections.Generic;
using UnityEngine;

public class SimplyLinkList<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node Head;
    public int Count = 0;

    public void AddNodeAtStart(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
        Count++;
    }

    public void AddNodeAtEnd(T value)
    {
        if (Head == null)
        {
            AddNodeAtStart(value);
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Next = new Node(value);
            Count++;
        }
    }

    public void AddNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            AddNodeAtStart(value);
        }
        else if (position >= Count)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else
        {
            int currentPosition = 0;
            Node tmp = Head;
            while (currentPosition < position - 1)
            {
                tmp = tmp.Next;
                currentPosition++;
            }
            Node newNode = new Node(value)
            {
                Next = tmp.Next
            };
            tmp.Next = newNode;
            Count++;
        }
    }

    public void ModifyAtStart(T value)
    {
        if (Head == null)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else
        {
            Head.Value = value;
        }
    }

    public void ModifyAtEnd(T value)
    {
        if (Head == null)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }
    }

    public void ModifyAtPosition(T value, int position)
    {
        if (position < 0 || position >= Count)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else if (position == 0)
        {
            ModifyAtStart(value);
        }
        else
        {
            Node tmp = Head;
            for (int i = 0; i < position; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }
    }

    public T GetNodeAtStart()
    {
        if (Head == null)
        {
            Debug.Log("La lista está vacía");
            return default;
        }
        return Head.Value;
    }

    public T GetNodeAtEnd()
    {
        if (Head == null)
        {
            Debug.Log("La lista está vacía");
            return default;
        }

        Node tmp = Head;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        return tmp.Value;
    }

    public T GetNodeAtPosition(int position)
    {
        if (position < 0 || position >= Count)
        {
            Debug.Log("No se puede hacer esta operación");
            return default;
        }

        Node tmp = Head;
        for (int i = 0; i < position; i++)
        {
            tmp = tmp.Next;
        }
        return tmp.Value;
    }

    public void RemoveAtStart()
    {
        if (Head == null)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else
        {
            Head = Head.Next;
            Count--;
        }
    }

    public void RemoveAtEnd()
    {
        if (Head == null)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else if (Head.Next == null)
        {
            Head = null;
            Count--;
        }
        else
        {
            Node tmp = Head;
            while (tmp.Next.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Next = null;
            Count--;
        }
    }

    public void RemoveNodeAtPosition(int position)
    {
        if (position < 0 || position >= Count)
        {
            Debug.Log("No se puede hacer esta operación");
        }
        else if (position == 0)
        {
            RemoveAtStart();
        }
        else
        {
            Node tmp = Head;
            for (int i = 0; i < position - 1; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Next = tmp.Next.Next;
            Count--;
        }
    }

    public void PrintAllNodes()
    {
        Node tmp = Head;
        while (tmp != null)
        {
            Debug.Log(tmp.Value);
            tmp = tmp.Next;
        }
    }
}