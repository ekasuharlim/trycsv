using helloworld;
using System;

public class Logger : ILogger
{
    public void WriteLogInfo(string message)
    {

        System.Console.WriteLine(message);
    }
}