using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue
    // Expected Result: Items with highest priority are dequeued first
    // Defect(s) Found:
    // 1. Dequeue loop condition uses index < _queue.Count - 1, missing the last element
    // 2. Dequeue never removes the item from the queue
    // 3. Using >= for priority comparison picks last item instead of first for equal priorities
    // Test Result: After fixing code, all assertions passed. High (10) dequeued first, then Medium (5), then Low (1).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and dequeue
    // Expected Result: FIFO order maintained for same priority items (first in, first out)
    // Defect(s) Found:
    // 1. Using >= in comparison breaks FIFO for equal priorities - picks last instead of first
    // 2. Dequeue never removes the item from the queue
    // Test Result: After fixing code, all assertions passed. Items dequeued in FIFO order: First, Second, Third.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        // Should maintain FIFO order for equal priorities
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    // Additional test cases below

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and same priorities
    // Expected Result: Highest priority items dequeued first, maintaining FIFO for ties
    // Defect(s) Found:
    // 1. Loop condition misses last element
    // 2. Using >= instead of > for tie-breaking
    // 3. Dequeue never removes the item from the queue
    // Test Result: After fixing code, all assertions passed. High1 and High2 (priority 10) dequeued first in FIFO order, then Medium1 and Medium2 (priority 5) in FIFO order, then Low1 (priority 1).
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 10);
        priorityQueue.Enqueue("Medium1", 5);
        priorityQueue.Enqueue("High2", 10);
        priorityQueue.Enqueue("Medium2", 5);

        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Medium1", priorityQueue.Dequeue());
        Assert.AreEqual("Medium2", priorityQueue.Dequeue());
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this test passes as is
    // Test Result: Test passed. InvalidOperationException with correct message was thrown when attempting to dequeue from empty queue.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception: {e.GetType()}: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with negative and zero priorities
    // Expected Result: Negative priorities treated normally (lower priority)
    // Defect(s) Found:
    // 1. Dequeue never removes the item from the queue
    // 2. Loop condition in Dequeue misses last element
    // Test Result: After fixing code, all assertions passed. Highest (10) dequeued first, then Medium (0), then Lowest (-5).
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Lowest", -5);
        priorityQueue.Enqueue("Highest", 10);
        priorityQueue.Enqueue("Medium", 0);

        Assert.AreEqual("Highest", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Lowest", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items then dequeue all items
    // Expected Result: Queue should be empty after removing all items
    // Defect(s) Found:
    // 1. Dequeue never removes the item from the queue (critical bug)
    // Test Result: After fixing code, all assertions passed. All items were successfully removed and queue is empty. Attempting to dequeue again threw InvalidOperationException.
    public void TestPriorityQueue_RemoveAllItems()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        string result = priorityQueue.Dequeue(); // Should remove C (highest priority)
        result = priorityQueue.Dequeue(); // Should remove B
        result = priorityQueue.Dequeue(); // Should remove A

        // Queue should be empty now
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException)
        {
            // Expected - queue is empty
        }
    }
}