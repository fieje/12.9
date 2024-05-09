using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

public class Node
{
    public int Data;
    public Node Left, Right;

    public Node(int item)
    {
        Data = item;
        Left = Right = null;
    }
}

public class BinaryTree
{
    public Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(int data)
    {
        root = InsertRecursive(root, data);
    }

    private Node InsertRecursive(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }

        if (data < root.Data)
        {
            root.Left = InsertRecursive(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRecursive(root.Right, data);
        }

        return root;
    }

    private Node FindMin(Node node)
    {
        Node current = node;

        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    public int FindLastMin()
    {
        Node lastMin = FindMin(root);
        return lastMin.Data;
    }
}

namespace UnitTestProject1
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestFindLastMin()
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(8);

            int lastMin = tree.FindLastMin();

            Assert.AreEqual(2, lastMin);
        }
    }
}
