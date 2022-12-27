using System.Diagnostics;
using CerealGame.Models;
using TimeService = CerealGame.EventService.TimeEventService;

namespace CerealGame.ClockService;

public class ClockService
{
    private readonly TimeService _eventService;

    public ClockService(TimeService eventService)
    {
        _eventService = eventService;
    }

    public GameClock GameClock { get; set; } = new GameClock();

    public void Loop()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"\nPassing time, input any value to the console to quit.\n");

        while (!GameClock.Paused)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                Pause((int)Math.Round((double)stopwatch.ElapsedMilliseconds / 100));
            }
        }
    }

    public void Pause(int elapsedSeconds)
    {
        GameClock.Paused = true;

        Console.WriteLine($"\nPaused game clock\n");
        Console.WriteLine($"\nElapsed in-game hours: {elapsedSeconds}\n");


        GameClock.Time = GameClock.Time.AddHours((elapsedSeconds));

        LogClock();

        EmitTick(elapsedSeconds);
    }

    public void Start()
    {
        GameClock.Paused = false;

        Console.WriteLine("Starting clock");
        LogClock();

        Loop();
    }

    private void EmitTick(int elapsedSeconds)
    {
        elapsedSeconds *= GameClock.Speed;
        _eventService.Emit(elapsedSeconds);
    }

    public void LogClock()
    {
        Console.WriteLine(
            $"\n\nGame Clock:" +
            $"\nYear: {GameClock.Time.Year}" +
            $"\nMonth: {GameClock.Time.Month}" +
            $"\nDay: {GameClock.Time.Day}" +
            $"\nHour: {GameClock.Time.Hour}\n"
        );
    }
}