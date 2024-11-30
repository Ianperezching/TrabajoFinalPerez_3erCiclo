using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyCombatant : BaseCombatant
{
    public Slider healthSlider;
    public EnemyStats stats;
    private TurnManager turnManager;

   // private AnimationController animationController;

    private void Awake()
    {
       // animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        stats.currentHealth = stats.health;
        UpdateHealthBar();
    }

    public void SetTurnManager(TurnManager manager)
    {
        turnManager = manager;
    }

    public void TakeDamage(int damage)
    {
        int damageTaken = Mathf.Max(damage - stats.defense, 0);
        stats.currentHealth -= damageTaken;

        Debug.Log(damage + " recibe daño " + stats.enemyName);
        if (stats.currentHealth <= 0)
        {
            stats.currentHealth = 0;
            UpdateHealthBar();
            Debug.Log(stats.enemyName + " has been defeated!");

            
            transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(this.gameObject); 
            });
        }
        else
        {
            UpdateHealthBar();
        }
        Debug.Log(stats.currentHealth);
    }

    public void Attack(BaseCombatant target)
    {
       // StartCoroutine(TiemAnimation("NormalAtack", true));
        Combatant combatant = (Combatant)target;
        combatant.TakeDamage(stats.attack);
    }
    //tiempo asintotico 0(1)

    //private IEnumerator TiemAnimation(string Name, bool State)
    //{
    //   // animationController.PlayAnimacion(Name, State);
    //    yield return new WaitForSeconds(2);
    //   // animationController.PlayAnimacion(Name, false);
    //}

    public void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)stats.currentHealth / stats.health;
        }
    }

    public override int GetSpeed()
    {
        return stats.speed;
    }

    public override string GetName()
    {
        return stats.enemyName;
    }

    public override void StartTurn(TurnManager turnManager)
    {
        //animationController.PlayAnimacion("Idle", true);
        turnManager.ExecuteEnemyTurn(this);
    }
}
