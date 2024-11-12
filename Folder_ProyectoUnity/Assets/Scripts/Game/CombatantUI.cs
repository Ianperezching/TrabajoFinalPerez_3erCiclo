using UnityEngine;
using UnityEngine.UI;

public class CombatantUI : MonoBehaviour
{
    private TurnManager turnManager;
    private Combatant combatant;
    public Slider healthSlider;

    public void Initialize(TurnManager manager, Combatant combatant)
    {
        this.turnManager = manager;
        this.combatant = combatant;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void NormalAttack()
    {
        EnemyCombatant[] enemies = turnManager.enemyCombatants;
        if (enemies.Length > 0)
        {
            combatant.Attack(enemies[0]);
        }
        turnManager.EndTurn(combatant);
    }

    public void SpecialAttack()
    {
        BaseCombatant[] enemies = new BaseCombatant[turnManager.enemyCombatants.Length];
        for (int i = 0; i < turnManager.enemyCombatants.Length; i++)
        {
            enemies[i] = turnManager.enemyCombatants[i];
        }
        combatant.SpecialAttack(enemies);
        turnManager.EndTurn(combatant);
    }

    public void Heal()
    {
        Combatant[] allies = turnManager.playerCombatants;
        for (int i = 0; i < allies.Length; i++)
        {
            combatant.Heal(allies[i]);
            allies[i].UpdateHealthBar();
        }
        turnManager.EndTurn(combatant);
    }//tiempo asintotico O(N)

    public void SpeedBoost()
    {
        Combatant[] allies = turnManager.playerCombatants;
        if (allies.Length > 0)
        {
            combatant.SpeedBoost(allies[0]);
        }
        turnManager.EndTurn(combatant);
    }
}
