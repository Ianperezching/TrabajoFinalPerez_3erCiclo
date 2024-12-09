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
    public void ApplyUpgrade(CardUpgrade upgrade)
    {
        health += upgrade.HealthBoost;
        attack += upgrade.AttackBoost;
        defense += upgrade.DefenseBoost;

        Debug.Log($"Mejora aplicada: Salud +{upgrade.HealthBoost}, Ataque +{upgrade.AttackBoost}, Defensa +{upgrade.DefenseBoost}");
    }
}