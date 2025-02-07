﻿// See https://aka.ms/new-console-template for more information
using AsyncFibonacci.Console;

Console.WriteLine("Async Performance Tester");

ExecuteComparison(5);
ExecuteComparison(10);
ExecuteComparison(15);
ExecuteComparison(20);
ExecuteComparison(25);
ExecuteComparison(30);
ExecuteComparison(35);
ExecuteComparison(40);

async void ExecuteComparison(int fibonacciNumber)
{
    Console.WriteLine($"Calculating the {fibonacciNumber}\n");
    var watch1 = System.Diagnostics.Stopwatch.StartNew();
    var value1 = Fibonacci.GetFibonacciNumber(fibonacciNumber); 
    watch1.Stop();
    var elapsedMs1 = watch1.ElapsedMilliseconds;
    Console.WriteLine($"Sync took {elapsedMs1} ms");

    var watch2 = System.Diagnostics.Stopwatch.StartNew();
    var value2 = await FibonacciAsync.GetFibonacciNumberAsync(fibonacciNumber);
    watch2.Stop();
    var elapsedMs2 = watch2.ElapsedMilliseconds;
    Console.WriteLine($"Async took {elapsedMs2} ms");

    var watch3 = System.Diagnostics.Stopwatch.StartNew();
    var value3 = await FibonacciAwait.GetFibonacciNumberAwait(fibonacciNumber);
    watch3.Stop();
    var elapsedMs3 = watch3.ElapsedMilliseconds;
    Console.WriteLine($"Await took {elapsedMs3} ms");

    if (fibonacciNumber <= 15)
    {
        var watch4 = System.Diagnostics.Stopwatch.StartNew();
        var value4 = FibonacciThread.GetFibonacciNumberThread(fibonacciNumber);
        watch4.Stop();
        var elapsedMs4 = watch4.ElapsedMilliseconds;
        Console.WriteLine($"Threading took {elapsedMs4} ms");
    }
    else
    {
        Console.WriteLine("Skipped threading because it's so slow to run.");
    }

    Console.WriteLine("\n");
}