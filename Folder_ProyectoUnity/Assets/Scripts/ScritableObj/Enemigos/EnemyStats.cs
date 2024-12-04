using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int currentHealth;

    public EnemyScalingData scalingData;

    
    public void ScaleStats(int floor)
    {
        if (scalingData != null)
        {
            currentHealth = scalingData.GetScaledValue(scalingData.healthCurve, health, floor);
            attack = scalingData.GetScaledValue(scalingData.attackCurve, attack, floor);
            defense = scalingData.GetScaledValue(scalingData.defenseCurve, defense, floor);
            speed = scalingData.GetScaledValue(scalingData.speedCurve, speed, floor);
        }
        else
        {
            currentHealth = health; 
        }
    }
}

