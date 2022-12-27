using CerealGame.Models;

namespace CerealGame.UI;

public class UserInterface
{
    public GameClock UiClock { get; set; } = new GameClock();

    public void UpdateClock(int hours)
    {
        UiClock.Time = UiClock.Time.AddHours(hours);
        LogUiClock();
    }

    public void LogUiClock()
    {
        Console.WriteLine(
            $"UI Clock:" +
            $"\nYear: {UiClock.Time.Year}" +
            $"\nMonth: {UiClock.Time.Month}" +
            $"\nDay: {UiClock.Time.Day}" +
            $"\nHour: {UiClock.Time.Hour}"
        );
    }
}