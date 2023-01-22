using System.Runtime.CompilerServices;

namespace BlazorServerDemo.Utilities;

public static class UtilityExtensionMethods
{
    public static StopwatchLogger StartStopwatch<T>(this ILogger<T> logger, string message, params object?[] args)
    {
        return new StopwatchLogger(logger, LogLevel.Information, message, args );
    }

    public static StopwatchLogger BeginStopwatch<T>(this ILogger<T> logger, [CallerMemberName] string memberName = "")
    {
        return new StopwatchLogger(logger, LogLevel.Information, memberName);
    }
}