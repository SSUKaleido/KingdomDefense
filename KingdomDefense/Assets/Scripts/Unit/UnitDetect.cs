using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDetect : MonoBehaviour
{
    public GameObject Detect() {
        Collider2D[] nearbyUnits = Physics2D.OverlapCircleAll(transform.position, 2f, 1 << gameObject.layer);
        Collider2D closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D nearbyUnit in nearbyUnits) {
            float distance = Vector2.Distance(transform.position, nearbyUnit.transform.position);
            Unit.ElementType selfElementType = gameObject.GetComponent<Unit>().elementType;
            Unit.ElementType nearUnitElementType = nearbyUnit.gameObject.GetComponent<Unit>().elementType;

            if (distance < closestDistance && isEnemy(selfElementType, nearUnitElementType)) {
                closestDistance = distance;
                closestEnemy = nearbyUnit;
            }
        }

        return closestEnemy.gameObject;
    }

    bool isEnemy(Unit.ElementType firstType, Unit.ElementType secondType) {
        bool isFirstKD = firstType < Unit.ElementType.KD_Ice;
        bool isSecondKD = secondType < Unit.ElementType.KD_Ice;
        return isFirstKD ^ isSecondKD;
    }
}