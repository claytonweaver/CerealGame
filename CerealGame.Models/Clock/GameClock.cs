namespace CerealGame.Models;

public class GameClock
{
    public DateTime Time { get; set; } = new DateTime(2023, 1, 1);
    public int Speed { get; set; } = 5;
    public bool Paused = true;
}