using System;

namespace SalesImport
{
    public interface ILogger
    {
        void WriteLogInfo(string message);
        void WriteLogError(string message);
    }
}