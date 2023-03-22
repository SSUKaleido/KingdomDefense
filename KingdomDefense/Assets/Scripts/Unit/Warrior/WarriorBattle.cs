using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBattle : MonoBehaviour
{
    [SerializeField] float attackDamage = 2;
    MatchManager matchManagerScript;

    private void Awake()
    {
        matchManagerScript = GameObject.Find("MatchManager").GetComponent<MatchManager>();
    }

    public bool AttackEnemy(GameObject enemy)
    {
        if (enemy != null ) {
            UnitInfo enemyUnit = enemy.GetComponent<UnitInfo>();

            float totalDamage = attackDamage;
            if (gameObject.layer == LayerMask.NameToLayer("FireUnit"))
                totalDamage += (0.2f * matchManagerScript.firePower);
            else if (gameObject.layer == LayerMask.NameToLayer("IceUnit"))
                totalDamage += (0.2f * matchManagerScript.icePower);

            enemyUnit.hp -= totalDamage;
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
