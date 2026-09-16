using System;
using System.Threading;
using System.Threading.Tasks;

Worker worker = new Worker();

Console.WriteLine("================================");
Console.WriteLine("       C# THREAD DEMO");
Console.WriteLine("================================");

Console.WriteLine("\n1. Basic Thread");
Thread thread1 = new Thread(() => worker.DoWork("Thread 1"));

Console.WriteLine("Starting Thread 1...");
thread1.Start();

thread1.Join();

Console.WriteLine("Thread 1 completed.");

Console.WriteLine("\n2. Two Threads Running");

Thread thread2 = new Thread(() => worker.DoWork("Thread 2"));
Thread thread3 = new Thread(() => worker.DoWork("Thread 3"));

thread2.Start();
thread3.Start();

thread2.Join();
thread3.Join();

Console.WriteLine("Both threads completed.");

Console.WriteLine("\n3. IsAlive Example");

Thread thread4 = new Thread(() => worker.DoWork("Thread 4"));

Console.WriteLine($"Before Start: {thread4.IsAlive}");

thread4.Start();

Console.WriteLine($"After Start: {thread4.IsAlive}");

thread4.Join();

Console.WriteLine($"After Completion: {thread4.IsAlive}");

Console.WriteLine("\n4. ThreadPool Example");

ThreadPool.QueueUserWorkItem(state =>
{
    worker.DoWork("ThreadPool Worker");
});

Thread.Sleep(3000);

Console.WriteLine("\n5. Background Thread Example");

Thread backgroundThread = new Thread(() =>
{
    worker.DoWork("Background Thread");
});

backgroundThread.IsBackground = true;

backgroundThread.Start();

Thread.Sleep(1000);

Console.WriteLine("\n6. Task Example");

Task task1 = Task.Run(() =>
{
    worker.DoWork("Task 1");
});

Task task2 = Task.Run(() =>
{
    worker.DoWork("Task 2");
});

Task.WaitAll(task1, task2);

Console.WriteLine("\n================================");
Console.WriteLine("All demonstrations completed.");
Console.WriteLine("================================");