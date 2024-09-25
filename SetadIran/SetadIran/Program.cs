// See https://aka.ms/new-console-template for more information
using SetadIran;

Console.WriteLine("Hello, World!");
Thread Thread1 = new Thread(() => Operations.SetadIranCollector()); Thread1.Start();