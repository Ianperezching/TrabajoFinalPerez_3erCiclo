using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text CardNameText; // Asigna un objeto de texto para mostrar el nombre de la carta
    public Text HealthBoostText;
    public Text AttackBoostText;
    public Text DefenseBoostText;

    public void Setup(CardUpgrade card, int index)
    {
        if (card == null) return;

        // Configurar los textos con los datos del ScriptableObject
        CardNameText.text = card.UpgradeName;
        HealthBoostText.text = $"Health: +{card.HealthBoost}";
        AttackBoostText.text = $"Attack: +{card.AttackBoost}";
        DefenseBoostText.text = $"Defense: +{card.DefenseBoost}";
    }
}
