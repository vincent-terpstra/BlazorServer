using System.Diagnostics;

namespace BlazorServerDemo.Utilities;

public class StopwatchLogger : IDisposable
{
    private readonly Stopwatch _stopwatch;
    private readonly LogLevel _loglevel;
    private readonly ILogger _logger;
    private readonly string _message;
    private readonly object?[] _args;

    public StopwatchLogger(ILogger logger, LogLevel loglevel, string message)
    {
        _logger = logger;
        _message = message;
        _loglevel = loglevel;
        _stopwatch = Stopwatch.StartNew();
    }
    
    public StopwatchLogger(ILogger logger, LogLevel loglevel, string message, object?[] args)
    {
        _logger = logger;
        _message = message;
        _loglevel = loglevel;
        _args = args;
        _stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        _logger.Log(_loglevel, $"{_message} took {_stopwatch.ElapsedMilliseconds}ms", _args);
    }
}