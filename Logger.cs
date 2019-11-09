using helloworld;
using System;

public class Logger : ILogger
{
    public void WriteLogError(string message)
    {
        System.Console.WriteLine(string.Format("ERROR : {0}",message));
    }

    public void WriteLogInfo(string message)
    {
        System.Console.WriteLine(message);
    }


}