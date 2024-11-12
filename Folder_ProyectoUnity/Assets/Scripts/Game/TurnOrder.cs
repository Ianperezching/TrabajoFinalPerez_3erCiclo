using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class TurnOrder : MonoBehaviour
{
    public BaseCombatant Combatant { get; private set; }
    public int TurnTime { get; private set; }

    public TurnOrder(BaseCombatant combatant, int initialTime)
    {
        Combatant = combatant;
        TurnTime = initialTime;
    }

    public void AddTime(int time)
    {
        TurnTime += time;
    }
}
