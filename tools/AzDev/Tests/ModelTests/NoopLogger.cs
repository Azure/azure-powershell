using AzDev.Services;

namespace AzDev.Tests;

public class NoopLogger : ILogger
{
    public void Debug(string message)
    {
    }

    public void Information(string message)
    {
    }

    public void Verbose(string message)
    {
    }

    public void Warning(string message)
    {
    }
}
