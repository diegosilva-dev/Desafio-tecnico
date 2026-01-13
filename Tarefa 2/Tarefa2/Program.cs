using System;
using System.Collections.Generic;
using System.Linq;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;
  public Node(int value)
    {
        Value = value;
    }
}

public class CustomTree
{
    public Node Root;
  public CustomTree(int[] array)
    {
        Build(array);
    }
  private void Build(int[] array)
    {
        // 1) Encontrar a raiz (maior valor)
        int maxValue = array.Max();
        int rootIndex = Array.IndexOf(array, maxValue);
        Root = new Node(maxValue);
      // 2) Elementos à esquerda e à direita da raiz (na ordem original)
        var leftSide = array.Take(rootIndex).ToList();
        var rightSide = array.Skip(rootIndex + 1).ToList();
      // 3) Ordenar lados em ordem decrescente
        leftSide = leftSide.OrderByDescending(x => x).ToList();
        rightSide = rightSide.OrderByDescending(x => x).ToList();
      // 4) Construir galhos encadeando nós como filho esquerdo sempre que possível
        Root.Left = BuildBranch(leftSide);
        Root.Right = BuildBranch(rightSide);
    }
  private Node BuildBranch(List<int> values)
    {
        if (values == null || values.Count == 0)
            return null;
      Node first = new Node(values[0]);
        Node current = first;
      for (int i = 1; i < values.Count; i++)
        {
            var newNode = new Node(values[i]);
            current.Left = newNode;  // sempre desce pelo lado esquerdo
            current = newNode;
        }
      return first;
    }
  // Impressão simples da árvore
    public void Print(Node node, string indent = "", bool isLeft = true)
    {
        if (node == null)
            return;
      Console.WriteLine(indent + (isLeft ? "L-- " : "R-- ") + node.Value);
        indent += "   ";
        Print(node.Left, indent, true);
        Print(node.Right, indent, false);
    }
}

public class Program
{
  public static void Main()
  {
    int[] cenario1 = { 3, 2, 1, 6, 0, 5 };
    int[] cenario2 = { 7, 5, 13, 9, 1, 6, 4 };
    Console.WriteLine("Cenário 1:");
    var tree1 = new CustomTree(cenario1);
    tree1.Print(tree1.Root);
    Console.WriteLine("\nCenário 2:");
    var tree2 = new CustomTree(cenario2);
    tree2.Print(tree2.Root);

    Console.ReadKey();
  }
  
}