using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public Combatant[] playerCombatants;
    public EnemyCombatant[] enemyCombatants;
    public CombatantUI[] combatantUIs;
    public MyPriorityQueue<BaseCombatant> priorityQueue = new MyPriorityQueue<BaseCombatant>();
    public FloorManager floorManager;

    private void Start()
    {
        for (int i = 0; i < playerCombatants.Length; i++)
        {
            Combatant playerCombatant = playerCombatants[i];
            playerCombatant.SetTurnManager(this);
            priorityQueue.PriorityEnqueue(playerCombatant, playerCombatant.GetSpeed());
            combatantUIs[i].Initialize(this, playerCombatant);
        }
        for (int i = 0; i < enemyCombatants.Length; i++)
        {
            EnemyCombatant enemyCombatant = enemyCombatants[i];
            enemyCombatant.SetTurnManager(this);
            priorityQueue.PriorityEnqueue(enemyCombatant, enemyCombatant.GetSpeed());
        }

        StartTurn();
    }

    private void StartTurn()
    {
        BaseCombatant currentCombatant = priorityQueue.PriorityDequeue();
        Debug.Log("It's " + currentCombatant.GetName() + "'s turn!");
        currentCombatant.StartTurn(this);
    }

    public void ShowPlayerOptions(Combatant player)
    {
        HideAllUI();
        for (int i = 0; i < playerCombatants.Length; i++)
        {
            if (playerCombatants[i] == player)
            {
                if (i < combatantUIs.Length)
                {
                    combatantUIs[i].Show();
                }
                break;
            }
        }
    }

    public void ExecuteEnemyTurn(EnemyCombatant enemy)
    {
        int targetIndex = Random.Range(0, playerCombatants.Length);
        Combatant target = playerCombatants[targetIndex];
        enemy.Attack(target);
        EndTurn(enemy);
    }

    public void EndTurn(BaseCombatant combatant)
    {
        if (AnyPlayerDead())
        {
            SceneManager.LoadScene("Derrota");
            return;
        }

        if (CheckVictory())
        {
            floorManager.AdvanceToNextFloor(); 
            return;
        }

        if (CheckDefeat())
        {
            SceneManager.LoadScene("Derrota");
            return;
        }

        combatant.AddDelay(1000);
        priorityQueue.PriorityEnqueue(combatant, combatant.GetSpeedWithDelay());
        StartTurn();
    }

    private bool CheckVictory()
    {
        for (int i = 0; i < enemyCombatants.Length; i++)
        {
            if (enemyCombatants[i].stats.currentHealth > 0)
            {
                return false;
            }
        }
        return true;
    }

    private bool CheckDefeat()
    {
        for (int i = 0; i < playerCombatants.Length; i++)
        {
            if (playerCombatants[i].stats.currentHealth > 0)
            {
                return false;
            }
        }
        return true;
    }

    private bool AnyPlayerDead()
    {
        for (int i = 0; i < playerCombatants.Length; i++)
        {
            if (playerCombatants[i].stats.currentHealth <= 0)
            {
                return true;
            }
        }
        return false;
    }

    private void HideAllUI()
    {
        for (int i = 0; i < combatantUIs.Length; i++)
        {
            combatantUIs[i].Hide();
        }
    }
}
