using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBattle : MonoBehaviour
{
    private UnitInfo unitInfo;

    private void Awake()
    {
        unitInfo = GetComponent<UnitInfo>();
    }


    public void SelfDamage()
    {
        if (gameObject.name != "KingdomCastle" || gameObject.name != "MonsterKingdom")
            unitInfo.hp -= 1;
    }

    public void DieUnit()
    {
        Destroy(gameObject);
    }
}