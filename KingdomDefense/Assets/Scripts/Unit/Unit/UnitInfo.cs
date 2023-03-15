using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitInfo : MonoBehaviour
{
    /*  유닛의 속성과 진영을 결정짓는 열거형, 비트마스크 사용  */
    [Flags] public enum ElementType
    {
        KD_Normal = 1 << 0,
        KD_Fire = 1 << 1,
        KD_Ice = 1 << 2,
        MO_Normal = 1 << 3,
        MO_Fire = 1 << 4,
        MO_Ice = 1 << 5
    }

    public ElementType elementType;
    public int hp;
}
