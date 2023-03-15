using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchorBattle : MonoBehaviour
{
    [SerializeField] int attackDamage = 2;

    public bool AttackEnemy(GameObject enemy)
    {
        if (enemy != null ) {
            UnitInfo enemyUnit = enemy.GetComponent<UnitInfo>();
            enemyUnit.hp -= attackDamage;
            return (enemyUnit.hp > 0);
        }
        return false;
    }

    public float AttackAnimation(Animator animator)
    {
        animator.SetTrigger("Attack");
        return animator.GetCurrentAnimatorClipInfo(0).Length;
    }

    public void DieUnit(Animator animator)
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);
    }
}