namespace QueazyIT.Core.Quizzes.ValueObjects.Timer.Exceptions;

internal class InvalidTimerDurationException : Exception
{
    private TimeSpan InvalidDuration { get; }
    private TimeSpan MaxDuration { get; }

    public InvalidTimerDurationException(TimeSpan invalidDuration, TimeSpan maxDuration) 
        : base($"Invalid timer duration: '{invalidDuration}'. Maximum allowed duration is '{maxDuration}'.")
    {
        InvalidDuration = invalidDuration;
        MaxDuration = maxDuration;
    }
}