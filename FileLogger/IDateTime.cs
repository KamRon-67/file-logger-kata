using System;

namespace FileLogger
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}