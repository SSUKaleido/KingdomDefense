using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    /*  유닛의 속성과 진영을 결정짓는 열거형, 비트마스크 사용  */
    [Flags] public enum ElementType {
        KD_Normal = 1 << 0,
        KD_Fire = 1 << 1,
        KD_Ice = 1 << 2,
        MO_Normal = 1 << 3,
        MO_Fire = 1 << 4,
        MO_Ice = 1 << 5
    }
    /*  유닛의 직업을 결정짓는 열거형  */
    [Flags] public enum JobType {
        Building = 1 << 0,
        Warrior = 1 << 1,
        Achor = 1 << 2
    }

    public ElementType elementType;
    public JobType jobType;
    public int hp;

    /* 메인 카메라와 부속 스크립트 컴포넌트  */
    private Camera mainCamera;
    private UnitMove unitMove;
    private UnitDetect unitDetect;
    private UnitBattle unitBattle;

    private GameObject closestEnemy = null;
    public bool isAdjoinWithEnemy = false;
    private const float delay = 0.25f;

    public void Initialize(ElementType elementInput, JobType jobInput) {
        elementType = elementInput;
        jobType = jobInput;
        
        switch (jobInput) {
            case JobType.Building:
                hp = 40;
                break;
            case JobType.Warrior:
                hp = 20;
                break;
            case JobType.Achor:
                hp = 10;
                break;
            default:
                Debug.LogWarning($"Unknown JobType: {jobInput}");
                break;
        }
    }

    private void Awake() {
        mainCamera = Camera.main;
        unitMove = GetComponent<UnitMove>();
        unitDetect = GetComponent<UnitDetect>();
        unitBattle = GetComponent<UnitBattle>();
    }

    private void Start() {
        StartCoroutine(PerformNextBehavior(delay));
    }

    private void Update() {
        if (closestEnemy == null && isAdjoinWithEnemy == false)
            unitMove.MoveUnitToForward(elementType);
        else if (closestEnemy != null && isAdjoinWithEnemy == false)
            unitMove.MoveUnitToEnemy(closestEnemy.transform);
    }

    private IEnumerator PerformNextBehavior(float delay)  {
        while (true)  {
            CheckIsOnScreen();
            if (isAdjoinWithEnemy == false) {
                closestEnemy = unitDetect.FindClosestEnemy();
            }
            else if (isAdjoinWithEnemy == true)
                Debug.Log("Battle!");

            yield return new WaitForSeconds(delay);
        }
    }

    /* 카메라 범위 안에 있는 지 확인하여 나갔으면 제거  */
    private void CheckIsOnScreen()  {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            Destroy(gameObject);
    }
}