using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    /* 메인 카메라와 부속 스크립트 컴포넌트  */
    private Camera mainCamera;
    private UnitInfo unitInfo;
    private UnitMove unitMove;
    private UnitDetect unitDetect;
    private WarriorBattle warriorBattle;
    private Animator animator;

    private float size_y_;
    private float size_x_;
    public float BottomBounder
    {
        get
        {
            return size_y_ * -1 + mainCamera.gameObject.transform.position.y;
        }
    }

    public float TopBounder
    {
        get
        {
            return size_y_ + mainCamera.gameObject.transform.position.y;
        }
    }

    private GameObject closestEnemy = null;
    private bool isAdjoinWithEnemy = false;

    private const float delay = 0.25f;
    private const float detectRange = 1f;

    private void Awake()
    {
        mainCamera = Camera.main;
        unitInfo = GetComponent<UnitInfo>();
        unitMove = GetComponent<UnitMove>();
        unitDetect = GetComponent<UnitDetect>();
        warriorBattle = GetComponent<WarriorBattle>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        size_y_ = mainCamera.orthographicSize;
        size_x_ = mainCamera.orthographicSize * Screen.width / Screen.height;

        StartCoroutine(PerformNextBehavior());
    }

    private void Update() {
        if (unitInfo.hp > 0) {
            unitMove.MoveUnit(unitInfo.elementType, closestEnemy, isAdjoinWithEnemy);
        }
        else
            warriorBattle.DieUnit(animator);
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

                /*  그 끝에 거의 다다랐으면 적의 캠프 찾아서 공격  */
                if (closestEnemy != null && closestEnemy.name == "MonsterCastle" && transform.position.y >= TopBounder - 5 - detectRange)
                    isAdjoinWithEnemy = true;
                else if (closestEnemy != null && closestEnemy.name == "KingdomCastle" && transform.position.y <= BottomBounder + 5 + detectRange)
                    isAdjoinWithEnemy = true;
            }

            /*  가장 가까운 적과 인접했다면 공격 실행  */
            if (isAdjoinWithEnemy == true && unitInfo.hp > 0)
            {
                isAdjoinWithEnemy = warriorBattle.AttackEnemy(closestEnemy);
                eachDelay = warriorBattle.AttackAnimation(animator);
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
