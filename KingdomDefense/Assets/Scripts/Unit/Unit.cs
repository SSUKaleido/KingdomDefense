using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    /*  유닛의 속성과 진영을 결정짓는 열거형  */
    public enum ElementType {
        KD_Normal, KD_Fire, KD_Ice, MO_Normal, MO_Fire, MO_Ice
    }
    public ElementType elementType;

    /* 메인 카메라와 부속 스크립트 컴포넌트  */
    private Camera mainCamera;
    private UnitMove unitMove;
    private UnitDetect unitDetect;

    private GameObject closestEnemy = null;
    [SerializeField] private const float delay = 0.25f;

    public void Initialize(ElementType elementInput) {
        elementType = elementInput;
    }

    private void Awake() {
        mainCamera = Camera.main;
        unitMove = GetComponent<UnitMove>();
        unitDetect = GetComponent<UnitDetect>();
    }

    private void Start() {
        StartCoroutine(PerformNextBehavior(delay));
    }

    private void Update() {
        if (closestEnemy == null)
            unitMove.MoveUnitToForward(elementType);
        else if (closestEnemy != null)
            unitMove.MoveUnitToEnemy(closestEnemy.transform);
    }

    private IEnumerator PerformNextBehavior(float delay)  {
        while (true)  {
            CheckIsOnScreen();
            closestEnemy = unitDetect.FindClosestEnemy();

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