using QueazyIT.Core.Quizzes.ValueObjects.Timer.Exceptions;

namespace QueazyIT.Core.Quizzes.ValueObjects.Timer;

internal class Timer : ValueObject
{
    public TimeSpan Value { get; }
    private static readonly TimeSpan MaxDuration = TimeSpan.FromHours(24);

    internal Timer(TimeSpan value)
    {
        if (value > MaxDuration)
            throw new InvalidTimerDurationException(value, MaxDuration);
        
        Value = value;
    }

    public static implicit operator Timer(TimeSpan value) => new(value);
    public static implicit operator TimeSpan(Timer timer) => timer.Value;

    public static Timer FromHours(double hours) => new(TimeSpan.FromHours(hours));
    public static Timer FromMinutes(double minutes) => new(TimeSpan.FromMinutes(minutes));
    public static Timer FromSeconds(double seconds) => new(TimeSpan.FromSeconds(seconds));

    public override string ToString() => Value.ToString();
}