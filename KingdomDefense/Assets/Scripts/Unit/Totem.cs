using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    /* 메인 카메라와 부속 스크립트 컴포넌트  */
    private Camera mainCamera;
    private UnitInfo unitInfo;
    private TotemBattle totemBattle;
    private Animator animator;
    private UnitDetect unitDetect;
    private GameObject closestEnemy = null;
    private bool isAdjoinWithEnemy = false;

    private const float delay = 0.25f;
    private const float detectRange = 1f;

    private void Awake()
    {
        mainCamera = Camera.main;
        unitInfo = GetComponent<UnitInfo>();
        totemBattle = GetComponent<TotemBattle>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(PerformNextBehavior());
    }

    private void Update() {
        if (unitInfo.hp <= 0) {
            totemBattle.DieUnit(animator);
        }
            
    }

    private IEnumerator PerformNextBehavior()
    {
        while (true)
        {
            float eachDelay = delay;
            CheckIsOnScreen();

            /*  지금 추적하고 있는 가장 가까운 적이 멀어졌다면 인접 여부 false로  */
            if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) > detectRange)
                isAdjoinWithEnemy = false;

            /*  인접하고 있는 적이 없다면 가장 가까운 적을 찾음  */
            if (isAdjoinWithEnemy == false && unitInfo.hp > 0)
            {
                closestEnemy = unitDetect.FindClosestEnemy();
                
                /*  그 가장 가까운 적과 인접했는 지 확인하고 인접 여부 true로  */
                if (closestEnemy != null && Vector2.Distance(transform.position, closestEnemy.transform.position) <= detectRange)
                    isAdjoinWithEnemy = true;
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