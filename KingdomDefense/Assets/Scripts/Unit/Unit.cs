using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum ElementType {
        KD_Normal, KD_Fire, KD_Ice, MO_Normal, MO_Fire, MO_Ice
    }

    public ElementType elementType;
    public bool isDead = false;

    private Camera mainCamera;
    private UnitMove unitMove;
    private UnitDetect unitDetect;
    private GameObject closestEnemy = null;

    [SerializeField] private float delay = 0.25f;

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
        unitMove.MoveUnit(elementType);
    }

    private IEnumerator PerformNextBehavior(float delay)  {
        while (true)  {
            CheckIsOnScreen();
            closestEnemy = unitDetect.FindClosestEnemy();

            yield return new WaitForSeconds(delay);
        }
    }

    private void CheckIsOnScreen()  {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            Destroy(gameObject);
    }
}