using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public int speed = 2;

    public void Move(Unit.ElementType elementType) {
        float velocity = speed * Time.deltaTime;
        if (elementType >= Unit.ElementType.MO_Normal && elementType <= Unit.ElementType.MO_Ice)
            velocity *= -1;
        
        transform.Translate(new Vector3(0, velocity, 0));
    }
}
