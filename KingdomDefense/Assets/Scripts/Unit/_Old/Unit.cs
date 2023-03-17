using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    /*
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
    
    private Camera mainCamera;
    private UnitMove unitMove;
    private UnitDetect unitDetect;
    private UnitBattle unitBattle;
    private Animator animator;

    private GameObject closestEnemy = null;
    private bool isAdjoinWithEnemy = false;

    private const float delay = 0.25f;
    private const float detectRange = 1f;

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

    private void CheckIsOnScreen()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            Destroy(gameObject);
    }
    */
}