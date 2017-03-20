using System;
using FluentAssertions;
using NUnit.Framework;

public static class Ext
{
    public static void Add(this NodeMinHeap heap, int i)
    {
        heap.Add(new Node(i) { Dist = i});
    }

    public static void Delete(this NodeMinHeap heap, int i)
    {
        heap.Delete(new Node(i));
    }
}

[TestFixture]
internal class NodeMinHeap_Tests
{
    protected NodeMinHeap CreateHeap()
    {
        return new NodeMinHeap();
    }

    [Test]
    public void Test_ManyElements()
    {
        var heap = CreateHeap();
        for (int i = 1000; i >= 0; i--)
        {
            heap.Add(i);
            heap.GetMin().Dist.Should().Be(i);
        }
        for (int i = 0; i <=1000; i++)
        {
            heap.GetMin().Dist.Should().Be(i);
            Console.Out.WriteLine($"Deleting element {i}");
            heap.Delete(i);
        }
    }

    [Test]
    public void Test()
    {
        var heap = CreateHeap();

        heap.Add(5);
        heap.GetMin().Dist.Should().Be(5);

        heap.Add(10);
        heap.GetMin().Dist.Should().Be(5);

        heap.Delete(5);
        heap.GetMin().Dist.Should().Be(10);

        heap.Add(5);
        heap.GetMin().Dist.Should().Be(5);

        heap.Add(4);
        heap.Add(6);
        heap.Add(2);
        heap.GetMin().Dist.Should().Be(2);
    }

    [Test]
    public void Test_DeleteAll()
    {
        var heap = CreateHeap();

        heap.Add(5);
        heap.Add(10);
        heap.GetMin().Dist.Should().Be(5);

        heap.Delete(5);
        heap.Delete(10);

        heap.Add(5);
        heap.Add(10);
        heap.GetMin().Dist.Should().Be(5);
    }

    [Test]
    public void Test_NegativeNumbers()
    {
        var heap = CreateHeap();

        heap.Add(5);
        heap.Add(10);
        heap.Add(-10);
        heap.GetMin().Dist.Should().Be(-10);

        heap.Add(6);
        heap.Add(11);
        heap.GetMin().Dist.Should().Be(-10);
    }

    [Test]
    public void Test_DecreaseKey1()
    {
        var heap = CreateHeap();

        heap.Add(5);
        heap.Add(10);
        heap.GetMin().Dist.Should().Be(5);

        heap.DecreaseKey(new Node(10){Dist = 4});
        heap.GetMin().Dist.Should().Be(4);
        heap.GetMin().Id.Should().Be(10);

        heap.Add(6);
        heap.Add(7);
        heap.GetMin().Dist.Should().Be(4);

        heap.DecreaseKey(new Node(5) {Dist = 1});
        heap.GetMin().Dist.Should().Be(1);
        heap.GetMin().Id.Should().Be(5);

        heap.Delete(5);
        heap.GetMin().Dist.Should().Be(4);
        heap.GetMin().Id.Should().Be(10);
    }
}