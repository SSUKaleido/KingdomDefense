using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    [SerializeField] private int speed = 2;

    public void MoveUnit(UnitInfo.ElementType elementType, GameObject closestEnemy, bool isAdjoinWithEnemy)
    {
        if (closestEnemy == null && isAdjoinWithEnemy == false)
        {
            MoveUnitToForward(elementType);
        }
        else if (closestEnemy != null && isAdjoinWithEnemy == false)
        {
            MoveUnitToEnemy(closestEnemy.transform);
        }
        else if (isAdjoinWithEnemy == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
        }
    }

    private void MoveUnitToForward(UnitInfo.ElementType elementType) {
        float velocity = speed * Time.deltaTime;
        if (elementType >= UnitInfo.ElementType.MO_Normal)
            velocity *= -1;

        transform.Translate(new Vector3(0, velocity, 0));
    }

    private void MoveUnitToEnemy(Transform EnemyTransform) {
        Vector3 direction = EnemyTransform.position - transform.position;
        float velocity = speed * Time.deltaTime;

        transform.Translate(direction.normalized * velocity);
    }
}