using Microsoft.VisualStudio.TestTools.UnitTesting;


/// <summary>
/// A helper class for the tests that is not part of the solution.
/// </summary>
internal class PriorityItem<T>
{
    internal T Value { get; }
    internal int Priority { get; }

    internal PriorityItem(T value, int priority)
    {
        Value = value;
        Priority = priority;
    }
}

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    /// <summary>
    /// Scenario: Attempting to dequeue from a priority queue that has no items.
    /// Expected Result: The operation should fail and throw an InvalidOperationException.
    /// Defect(s) Found: None. This test passes with the original code.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(System.InvalidOperationException))]
    public void Dequeue_FromEmptyQueue_ThrowsException()
    {
        var pq = new PriorityQueue<string>();
        pq.Dequeue();
    }

    /// <summary>
    /// Scenario: Dequeuing from a queue with multiple items, each having a unique priority.
    /// Expected Result: The item with the numerically highest priority value is returned.
    /// Defect(s) Found: None. The basic logic of finding the highest priority works correctly.
    /// </summary>
    [TestMethod]
    public void Dequeue_ReturnsHighestPriority()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
    }

    /// <summary>
    /// Scenario: Dequeuing from a queue where multiple items share the same highest priority.
    /// Expected Result: The item that was enqueued first among the tied items should be returned, following the FIFO (First-In, First-Out) rule.
    /// Defect(s) Found: The original code fails this test. It uses a `>=` comparison, which causes it to select the *last* item added with the highest priority (LIFO), violating the requirement.
    /// </summary>
    [TestMethod]
    public void Dequeue_WithTie_ReturnsFirstIn()
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("A (High)", 10);
        pq.Enqueue("B (Low)", 1);
        pq.Enqueue("C (High)", 10); // Same priority as A

        // "A (High)" was enqueued first, so it should be dequeued first.
        Assert.AreEqual("A (High)", pq.Dequeue());
        // "C (High)" should be the next one to be dequeued.
        Assert.AreEqual("C (High)", pq.Dequeue());
    }
    
    /// <summary>
    /// Scenario: A series of enqueue and dequeue operations involving multiple items and priority ties to test the combined logic over several steps.
    /// Expected Result: Items are consistently dequeued first by highest priority, and then by their FIFO order for any ties. The final queue should be empty.
    /// Defect(s) Found: The original code fails this test for the same reason as the `Dequeue_WithTie_ReturnsFirstIn` test. It dequeues items with the same priority in the wrong (LIFO) order.
    /// </summary>
    [TestMethod]
    public void Dequeue_ComplexScenario_CorrectOrder() {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 10);

        Assert.AreEqual(4, pq.Count);

        // Dequeue order should be B, D, A, C
        Assert.AreEqual("B", pq.Dequeue()); // First item with priority 10
        Assert.AreEqual("D", pq.Dequeue()); // Second item with priority 10
        Assert.AreEqual("A", pq.Dequeue()); // First item with priority 5
        Assert.AreEqual("C", pq.Dequeue()); // Second item with priority 5

        Assert.AreEqual(0, pq.Count);
    }


    /*[TestMethod]
    
     public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    } */

    // Add more test cases as needed below.
}