using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBattle : MonoBehaviour
{
    [SerializeField] int dotDamage = 0;

    private UnitInfo unitInfo;

    private void Awake()
    {
        unitInfo = GetComponent<UnitInfo>();
    }


    public void SelfDamage()
    {
        unitInfo.hp -= dotDamage;
    }

    public void DieUnit()
    {
        Destroy(gameObject);
    }
}