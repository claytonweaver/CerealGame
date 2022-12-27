using CerealGame.UI;

namespace CerealGame.Bff;

public class UserInterfaceService
{
    private readonly UserInterface _userInterface;

    public UserInterfaceService(UserInterface userInterface)
    {
        _userInterface = userInterface;
    }

    public void UpdateClock(int inGameHours)
    {
        _userInterface.UpdateClock(inGameHours);
    }
}