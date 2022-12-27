using CerealGame.Bff;
using GameOrch = CerealGame.GameOrchestrator.GameOrchestrator;

namespace CerealGame.EventService;

public class TimeEventService
{
    private readonly GameOrch _gameOrchestrator;
    private readonly UserInterfaceService _uiService;

    public TimeEventService(GameOrch gameOrchestrator, UserInterfaceService uiService)
    {
        _gameOrchestrator = gameOrchestrator;
        _uiService = uiService;
    }

    public void Emit(int inGameHours)
    {
        _uiService.UpdateClock(inGameHours);

        for (int i = 0; i < inGameHours + 1; i++)
        {
            _gameOrchestrator.ConsumeTimeEvent();
        }
    }
}