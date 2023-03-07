using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
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

    /* 메인 카메라와 부속 스크립트 컴포넌트  */
    private Camera mainCamera;
    private UnitMove unitMove;
    private UnitDetect unitDetect;
    private UnitBattle unitBattle;
    private Animator animator;

    private GameObject closestEnemy = null;
    private bool isAdjoinWithEnemy = false;

    private const float delay = 0.25f;
    private const float detectRange = 1f;

    public void Initialize(ElementType elementInput)
    {
        elementType = elementInput;
        hp = 20;
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        unitMove = GetComponent<UnitMove>();
        unitDetect = GetComponent<UnitDetect>();
        unitBattle = GetComponent<UnitBattle>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(PerformNextBehavior());
    }

    private void Update() {
        if (hp > 0) {
            unitMove.MoveUnit(elementType, closestEnemy, isAdjoinWithEnemy);
        }
        else
            unitBattle.DieUnit(animator);
    }

    private IEnumerator PerformNextBehavior()
    {
        while (true)
        {
            float eachDelay = delay;
            CheckIsOnScreen();

            if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) > detectRange)
                isAdjoinWithEnemy = false;

            if (isAdjoinWithEnemy == false && hp > 0)
            {
                closestEnemy = unitDetect.FindClosestEnemy();
                
                if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) <= detectRange)
                    isAdjoinWithEnemy = true;
            }
            else if (isAdjoinWithEnemy == true && hp > 0)
            {
                isAdjoinWithEnemy = unitBattle.AttackEnemy(closestEnemy);
                eachDelay = unitBattle.AttackAnimation(animator);
            }

            yield return new WaitForSeconds(eachDelay);
        }
    }

    /* 카메라 범위 안에 있는 지 확인하여 나갔으면 제거  */
    private void CheckIsOnScreen()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            Destroy(gameObject);
    }
}