using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitDetect : MonoBehaviour
{
    [SerializeField] float DetectionRadius = 2f;

    UnitInfo unitInfo;

    private void Awake() {
        unitInfo = GetComponent<UnitInfo>();
    }

    public GameObject FindClosestEnemy()
    {
        Collider2D[] allNearbyUnits = Physics2D.OverlapCircleAll(transform.position, DetectionRadius, 1 << gameObject.layer);
        // null 값이 아닌 collider2D만 선택해서 배열 생성
        Collider2D[] nearbyUnits = allNearbyUnits.Where(collider => collider != null).ToArray();
        
        Collider2D closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D nearbyUnit in nearbyUnits)
        {
            float distance = Vector2.Distance(transform.position, nearbyUnit.transform.position);
            UnitInfo.ElementType selfElementType = unitInfo.elementType;
            UnitInfo.ElementType nearbyUnitElementType = nearbyUnit.gameObject.GetComponent<UnitInfo>().elementType;

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

    public static bool isEnemy(UnitInfo.ElementType firstType, UnitInfo.ElementType secondType) {
        if (firstType > secondType) {
            UnitInfo.ElementType temp = firstType;
            firstType = secondType;
            secondType = temp;
        }

        bool isDiffCame = (((int)firstType & 0b111000) == 0) && (((int)secondType & 0b111) == 0);
        bool isDiffElement = ((int)firstType == 0b1) || ((int)firstType != ((int)secondType >> 3));

        return isDiffCame && isDiffElement;
    }
}