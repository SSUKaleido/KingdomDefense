using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    /* 메인 카메라와 부속 스크립트 컴포넌트  */
    private Camera mainCamera;
    private UnitInfo unitInfo;
    private TotemBattle totemBattle;
    private UnitDetect unitDetect;

    private const float delay = 0.25f;
    private const float detectRange = 1f;

    private void Awake()
    {
        mainCamera = Camera.main;
        unitInfo = GetComponent<UnitInfo>();
        totemBattle = GetComponent<TotemBattle>();
    }

    private void Start()
    {
        StartCoroutine(PerformNextBehavior());
    }

    private void Update() {
        if (unitInfo.hp <= 0) {
            totemBattle.DieUnit();
        }
            
    }

    private IEnumerator PerformNextBehavior()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
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