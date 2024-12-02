using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class TurnManager : MonoBehaviour
{
    public Combatant[] playerCombatants;
    public EnemyCombatant[] enemyCombatants;
    public CombatantUI[] combatantUIs;
    public MyPriorityQueue<BaseCombatant> priorityQueue = new MyPriorityQueue<BaseCombatant>();
    public FloorManager floorManager;
    public string floor;

    public CinemachineVirtualCamera[] playerCameras;
    public CinemachineVirtualCamera enemyCamera;    
    public GameObject[] players;                    
    public GameObject[] enemies;

    private int currentTurnIndex = 0;              
    private bool isPlayerTurn = true;


    private void Start()
    {

        UpdateCameraFocus();

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
    public void NextTurn()
    {
        if (isPlayerTurn)
        {
            
            currentTurnIndex++;
            if (currentTurnIndex >= players.Length)
            {
                currentTurnIndex = 0;
                isPlayerTurn = false; 
            }
        }
        else
        {
           
            isPlayerTurn = true;
        }

        UpdateCameraFocus(); 
    }

    private void StartTurn()
    {
        BaseCombatant currentCombatant = priorityQueue.PriorityDequeue();
        Debug.Log("It's " + currentCombatant.GetName() + "'s turn!");
        currentCombatant.StartTurn(this);
    }
    private void UpdateCameraFocus()
    {
        if (isPlayerTurn)
        {
            for (int i = 0; i < playerCameras.Length; i++)
            {
                if (i == currentTurnIndex)
                {
                    playerCameras[i].Priority = 10; 
                }
                else
                {
                    playerCameras[i].Priority = 0; 
                }
            }

           
            if (enemyCamera != null)
            {
                enemyCamera.Priority = 0;
            }
        }
        else
        {
        
            if (enemyCamera != null)
            {
                enemyCamera.Priority = 10;
            }

    
            for (int i = 0; i < playerCameras.Length; i++)
            {
                playerCameras[i].Priority = 0;
            }
        }
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
                    NextTurn();
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
        NextTurn();
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
            SceneManager.LoadScene(floor);
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
