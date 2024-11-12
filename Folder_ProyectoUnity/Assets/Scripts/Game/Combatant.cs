using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Combatant : BaseCombatant
{
    public Slider healthSlider;
    public CharacterStats stats;
    private TurnManager turnManager;
   // private AnimationController animationController;
    //private AudioSource audioSource;

    private void Awake()
    {
        //animationController = GetComponent<AnimationController>();
      //  audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        stats.currentHealth = stats.health;
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        healthSlider.value = (float)stats.currentHealth / stats.health;
    }
    public void SetTurnManager(TurnManager manager)
    {
        turnManager = manager;
    }

    public void TakeDamage(int damage)
    {
       // StartCoroutine(TiemAnimation("RecibeDaño 0", true));
        int damageTaken = Mathf.Max(damage - stats.defense, 0);
        stats.currentHealth -= damageTaken;

        if (stats.currentHealth <= 0)
        {
            UpdateHealthBar();
            Debug.Log(stats.characterName + " has been defeated!");
        }
        else
        {
            UpdateHealthBar();
        }
    }

    public void Attack(BaseCombatant target)
    {
        //StartCoroutine(TiemAnimation("NormalAtack", true));
        EnemyCombatant enemy = (EnemyCombatant)target;
        enemy.TakeDamage(stats.attack);
       // PlayAttackSound();
    }

    public void SpecialAttack(BaseCombatant[] enemies)
    {
       // StartCoroutine(TiemAnimation("SpecialAttack 0", true));
        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyCombatant enemyCombatant = (EnemyCombatant)enemies[i];
            enemyCombatant.TakeDamage(stats.attack);
           // animationController.PlayAnimacion("Dead");
        }//tiempo asintotico 0(n)
    }
    //private IEnumerator TiemAnimation(string Name, bool State)
    //{
    //    //animationController.PlayAnimacion(Name, State);
    //    yield return new WaitForSeconds(2);
    //   // animationController.PlayAnimacion(Name, false);
    //}

    public void Heal(BaseCombatant target)
    {
       // animationController.PlayAnimacion("SpecialAttack 0", true);
        Combatant combatant = (Combatant)target;
        combatant.stats.currentHealth = Mathf.Min(combatant.stats.health, combatant.stats.currentHealth + stats.attack);
        Debug.Log(stats.characterName + " healed " + combatant.stats.characterName);
    }

    public void SpeedBoost(BaseCombatant target)
    {
      //  animationController.PlayAnimacion("SpecialAttack 0", true);
        Combatant combatant = (Combatant)target;
        combatant.stats.speed += stats.attack;
        Debug.Log(stats.characterName + " boosted speed of " + combatant.stats.characterName);
    }
    //private void PlayAttackSound()
    //{
    //    if (audioSource != null && audioSource.clip != null)
    //    {
    //        audioSource.Play();
    //    }
    //}
    public override int GetSpeed()
    {
        return stats.speed;
    }

    public override string GetName()
    {
        return stats.characterName;
    }

    public override void StartTurn(TurnManager turnManager)
    {
        //animationController.PlayAnimacion("Idle", true);
        turnManager.ShowPlayerOptions(this);
    }//tiempo asintotico 0(log n)
}
