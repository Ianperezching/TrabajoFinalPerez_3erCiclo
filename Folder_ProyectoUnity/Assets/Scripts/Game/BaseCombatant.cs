using UnityEngine;

public class BaseCombatant : MonoBehaviour
{
    private int delay = 0;

    public virtual int GetSpeed()
    {
        return 0;
    }

    public virtual string GetName()
    {
        return string.Empty;
    }

    public virtual void StartTurn(TurnManager turnManager)
    {

    }

    public virtual bool IsAlive()
    {
        return true;
    }

    public void AddDelay(int time)
    {
        delay += time;
    }

    public int GetSpeedWithDelay()
    {
        return GetSpeed() + delay;
    }
}
