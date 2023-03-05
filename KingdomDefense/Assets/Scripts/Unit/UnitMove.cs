using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    [SerializeField] private int speed = 2;

    public void MoveUnitToForward(Unit.ElementType elementType) {
        float velocity = speed * Time.deltaTime;
        if (elementType >= Unit.ElementType.MO_Normal)
            velocity *= -1;

        transform.Translate(new Vector3(0, velocity, 0));
    }

    public void MoveUnitToEnemy(Transform EnemyTransform) {
        Vector3 direction = EnemyTransform.position - transform.position;
        float velocity = speed * Time.deltaTime;

        transform.Translate(direction.normalized * velocity);
    }
}