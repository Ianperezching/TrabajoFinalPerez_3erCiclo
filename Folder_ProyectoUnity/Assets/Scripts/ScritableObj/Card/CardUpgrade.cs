using UnityEngine;


[CreateAssetMenu(fileName = "NewCardUpgrade", menuName = "Upgrades/CardUpgrade")]
public class CardUpgrade : ScriptableObject
{
    public string UpgradeName; 
    public int HealthBoost;  
    public int AttackBoost;   
    public int DefenseBoost;
}
