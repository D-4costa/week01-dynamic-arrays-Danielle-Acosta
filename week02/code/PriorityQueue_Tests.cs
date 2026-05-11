using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities.
    // Expected Result: The item with the highest priority should be removed first.
    // Defect(s) Found: The loop was not checking the full queue, so some higher priority items were skipped.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Homework", 1);
        priorityQueue.Enqueue("Quiz", 5);
        priorityQueue.Enqueue("Final Project", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Final Project", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The first item added with that priority should be removed first.
    // Defect(s) Found: The queue was not correctly following FIFO order when priorities matched.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Anna", 8);
        priorityQueue.Enqueue("Mia", 8);
        priorityQueue.Enqueue("Lily", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Anna", result);
    }

    [TestMethod]
    // Scenario: Remove several items one after another.
    // Expected Result: Items should be removed in priority order until the queue is empty.
    // Defect(s) Found: Removed items were staying inside the queue after dequeue was called.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 4);
        priorityQueue.Enqueue("High", 7);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the correct message.
    // Defect(s) Found: No additional defects were found after fixing the queue behavior.
    public void TestPriorityQueue_4()
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
    }
}
