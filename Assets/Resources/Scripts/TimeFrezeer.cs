using UnityEngine;

public class TimeFreezer
{
    public void FreezeTime()
    {
        Time.timeScale = 0;
    }

    public void UnFreezeTime()
    {
        Time.timeScale = 1;
    }
}
