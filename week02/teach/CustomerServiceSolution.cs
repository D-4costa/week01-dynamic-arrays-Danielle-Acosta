/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerServiceSolution
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var service = new CustomerServiceSolution(10);
        // Console.WriteLine(service);

        // Test Cases

        // Test 1
        // Scenario: Add one customer and then serve that customer.
        // Expected Result: The same customer that was added should be displayed.
        Console.WriteLine("Test 1");

        var service = new CustomerServiceSolution(4);

        service.AddNewCustomer();
        service.ServeCustomer();

        // Defect(s) Found:
        // The customer needed to be saved before removing it from the queue.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them in order.
        // Expected Result: Customers should be served in the same order they were added.
        Console.WriteLine("Test 2");

        service = new CustomerServiceSolution(4);

        service.AddNewCustomer();
        service.AddNewCustomer();

        Console.WriteLine($"Before serving customers: {service}");

        service.ServeCustomer();
        service.ServeCustomer();

        Console.WriteLine($"After serving customers: {service}");

        // Defect(s) Found:
        // No additional defects were found.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try to serve a customer when the queue is empty.
        // Expected Result: A message should appear saying there are no customers in the queue.
        Console.WriteLine("Test 3");

        service = new CustomerServiceSolution(4);

        service.ServeCustomer();

        // Defect(s) Found:
        // The queue needed a check before trying to serve customers.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add more customers than the queue limit allows.
        // Expected Result: The extra customer should not be added.
        Console.WriteLine("Test 4");

        service = new CustomerServiceSolution(4);

        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();

        Console.WriteLine($"Service Queue: {service}");

        // Defect(s) Found:
        // The max size comparison needed to use >= instead of >.

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a queue using an invalid max size.
        // Expected Result: The default max size should become 10.
        Console.WriteLine("Test 5");

        service = new CustomerServiceSolution(0);

        Console.WriteLine($"Size should be 10: {service}");

        // Defect(s) Found:
        // No additional defects were found.

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerServiceSolution(int maxSize)
    {
        if (maxSize <= 0)
        {
            _maxSize = 10;
        }
        else
        {
            _maxSize = maxSize;
        }
    }

    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    private void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();

        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();

        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);

        _queue.Add(customer);
    }

    private void ServeCustomer()
    {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No Customers in the queue");
        }
        else
        {
            var customer = _queue[0];

            _queue.RemoveAt(0);

            Console.WriteLine(customer);
        }
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
