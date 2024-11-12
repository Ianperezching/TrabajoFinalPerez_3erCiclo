using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterStats", menuName = "ScriptableObjects/CharacterStats", order = 1)]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    public int health;
    public int attack;
    public int defense;
    public int speed;
    public int currentHealth;
}