using System;
using System.Threading;

public class Worker
{
    public void DoWork(string workerName)
    {
        Console.WriteLine($"{workerName} started.");

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{workerName}: Step {i}");

            Thread.Sleep(500);
        }

        Console.WriteLine($"{workerName} finished.");
    }
}