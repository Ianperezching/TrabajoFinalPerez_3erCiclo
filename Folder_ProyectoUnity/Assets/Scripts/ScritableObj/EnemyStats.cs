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
}
