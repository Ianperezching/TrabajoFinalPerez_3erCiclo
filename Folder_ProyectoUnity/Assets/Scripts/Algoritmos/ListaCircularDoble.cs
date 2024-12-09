using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
 public class ListaCircularDoble<T>
  {
      class Node
      {
          public T Value { get; set; }
          public Node Next { get; set; }
          public Node Previous { get; set; }

          public Node(T value)
          {
              Value = value;
              Next = null;
              Previous = null;
          }
      }
      private Node Head { get; set; }
      public int Count { get; set; }

      public void InsertAtStart(T value)
      {
          Node newNode = new Node(value);
          if (Head == null)
          {
              Head = newNode;
              newNode.Next = Head;
              newNode.Previous = Head;
          }
          else
          {
              Node lastNode = SearchLastNode();
              newNode.Next = Head;
              newNode.Previous = lastNode;
              lastNode.Next = newNode;
              Head.Previous = newNode;
          }
          Head = newNode;
          ++Count;
      }
      public void InsertAtEnd(T value)
      {
          if (Head == null)
          {
              InsertAtStart(value);
          }
          else
          {
              Node newNode = new Node(value);
              Node lastNode = SearchLastNode();
              newNode.Next = Head;
              newNode.Previous = lastNode;
              lastNode.Next = newNode;
              Head.Previous = newNode;
              ++Count;
          }
      }
      public void InsertAtPosition(T value, int position)
      {
          if (position == 0)
          {
              InsertAtStart(value);
          }
          else if (position == Count - 1)
          {
              InsertAtEnd(value);
          }
          else if (position >= Count)
          {
              throw new IndexOutOfRangeException("Índice fuera de rango");
          }
          else
          {
              Node newNode = new Node(value);
              Node currentNode = Head;
              for (int i = 0; i < position; i++)
              {
                  currentNode = currentNode.Next;
              }
              Node previousNode = currentNode.Previous;
              previousNode.Next = newNode;
              newNode.Previous = previousNode;
              newNode.Next = currentNode;
              currentNode.Previous = newNode;

              ++Count;
          }
      }
      public void ModifyAtStart(T value)
      {
          if (Head == null)
          {
              throw new NullReferenceException("No se puede hacer eso");
          }
          Head.Value = value;
      }
      public void ModifyAtEnd(T value)
      {
          if (Head == null)
          {
              throw new NullReferenceException("No se puede hacer eso");
          }
          Node lastNode = SearchLastNode();
          lastNode.Value = value;
      }
      public void ModifyAtPosition(T value, int position)
      {
          if (position < 0 || position >= Count)
          {
              throw new NullReferenceException("No se puede hacer eso");
          }
          Node currentNode = Head;
          for (int i = 0; i < position; i++)
          {
              currentNode = currentNode.Next;
          }
          currentNode.Value = value;
      }
      public T GetAtStart()
      {
          if (Head == null)
          {
              throw new NullReferenceException("La lista esta vacia");
          }
          return Head.Value;
      }
      public T GetAtEnd()
      {
          if (Head == null)
          {
              throw new NullReferenceException("No se puede hacer eso");
          }
          Node lastNode = SearchLastNode();
          return lastNode.Value;
      }
      public T GetAtPosition(int position)
      {
          if (position < 0 || position >= Count)
          {
              throw new NullReferenceException("No se puede hacer eso");
          }
          Node currentNode = Head;
          for (int i = 0; i < position; i++)
          {
              currentNode = currentNode.Next;
          }
          return currentNode.Value;
      }
      public void DeleteAtStart()
      {
          if (Head == null)
          {
              throw new InvalidOperationException("La lista está vacía");
          }
          else if (Head.Next == Head)
          {
              Head = null;
              Count = 0;
          }
          else
          {
              Node lastNode = Head.Previous;
              Node newHead = Head.Next;
              newHead.Previous = lastNode;
              lastNode.Next = newHead;
              Head = newHead;
              --Count;
          }
      }
      public void DeleteAtEnd()
      {
          if (Head == null)
          {
              throw new NullReferenceException("Nop");
          }
          if (Count == 1)
          {
              Head = null;
          }
          else
          {
              Node lastNode = SearchLastNode();
              Node newLastNode = lastNode.Previous;
              newLastNode.Next = Head;
              Head.Previous = newLastNode;
          }
          --Count;
      }
      public void DeleteAtPosition(int position)
      {
          if (position < 0 || position >= Count)
          {
              throw new NullReferenceException("No");
          }
          else if (position == 0)
          {
              DeleteAtStart();
          }
          else if (position == Count - 1)
          {
              DeleteAtEnd();
          }
          else
          {
              Node currentNode = Head;
              for (int i = 0; i < position; i++)
              {
                  currentNode = currentNode.Next;
              }
              Node previousNode = currentNode.Previous;
              Node nextNode = currentNode.Next;
              previousNode.Next = nextNode;
              nextNode.Previous = previousNode;
              --Count;
          }
      }
      private Node SearchLastNode()
      {
          if (Head == null)
          {
              return null;
          }
          Node currentNode = Head;
          while (currentNode.Next != Head)
          {
              currentNode = currentNode.Next;
          }
          return currentNode;
      }
      public void PrintAllNode()
      {
          if (Head == null)
          {
              Console.WriteLine("nop");
              return;
          }
          Node tmp = Head;
          do
          {
              Console.Write(tmp.Value + " - ");
              tmp = tmp.Next;
          } while (tmp != Head);
          Console.WriteLine();
      }
  }
