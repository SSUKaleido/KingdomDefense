using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitDetect : MonoBehaviour
{
    [SerializeField] float DetectionRadius = 2f;
    Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public GameObject FindClosestEnemy()
    {
        Collider2D[] allNearbyUnits = Physics2D.OverlapCircleAll(transform.position, DetectionRadius, 1 << gameObject.layer);
        // null 값이 아닌 collider2D만 선택해서 배열 생성
        Collider2D[] nearbyUnits = allNearbyUnits.Where(collider => collider != null).ToArray();

        Unit.ElementType selfElementType = unit.elementType;
        
        Collider2D closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D nearbyUnit in nearbyUnits)
        {
            float distance = Vector2.Distance(transform.position, nearbyUnit.transform.position);
            Unit.ElementType nearbyUnitElementType = nearbyUnit.gameObject.GetComponent<Unit>().elementType;

            if (distance < closestDistance && isEnemy(selfElementType, nearbyUnitElementType))
            {
                closestDistance = distance;
                closestEnemy = nearbyUnit;
            }
        }

        if (closestEnemy != null)
            return closestEnemy.gameObject;

        return null;
    }

    private bool isEnemy(Unit.ElementType firstType, Unit.ElementType secondType)
    {
        bool isFirstKD = firstType <= Unit.ElementType.KD_Ice;
        bool isSecondKD = secondType <= Unit.ElementType.KD_Ice;
        return isFirstKD ^ isSecondKD;
    }
}