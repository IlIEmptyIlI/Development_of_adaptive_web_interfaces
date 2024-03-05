using Serilog;
using System;

class Program
{
    private static int sharedData = 0;

    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console() // Виводить повідомлення в консоль
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // Записує повідомлення в файл
            .CreateLogger();

        Thread thread1 = new Thread(Method1);
        Thread thread2 = new Thread(Method2);

        thread1.Start();
        thread2.Start();

        Method3();

        Console.ReadLine();
    }

    static void Method1()
    {
        for (int i = 0; i < 5; i++)
        {
            Interlocked.Increment(ref sharedData);
            int square = sharedData * sharedData;
            double logarithm = Math.Log(sharedData);
            Log.Information("[{Timestamp}]: [Thread 1] Shared data: {SharedData}, Square: {Square}, Logarithm: {Logarithm}", DateTime.Now, sharedData, square, logarithm);
            Thread.Sleep(1000);
        }
    }

    static void Method2()
    {
        for (int i = 0; i < 5; i++)
        {
            Interlocked.Decrement(ref sharedData);
            int square = sharedData * sharedData;
            double logarithm = Math.Log(sharedData);
            Log.Information("[{Timestamp}]: [Thread 2] Shared data: {SharedData}, Square: {Square}, Logarithm: {Logarithm}", DateTime.Now, sharedData, square, logarithm);
            Thread.Sleep(1500);
        }
    }

    static async void Method3()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                int square = sharedData * sharedData;
                double logarithm = Math.Log(sharedData);
                Log.Information("[{Timestamp}]: [Async] Shared data: {SharedData}, Square: {Square}, Logarithm: {Logarithm}", DateTime.Now, sharedData, square, logarithm);
                Thread.Sleep(2000);
            }
        });
    }
}