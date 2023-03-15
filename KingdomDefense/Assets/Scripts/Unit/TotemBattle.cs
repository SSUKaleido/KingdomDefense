using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBattle : MonoBehaviour
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

    public void DieUnit(Animator animator)
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);
    }
}