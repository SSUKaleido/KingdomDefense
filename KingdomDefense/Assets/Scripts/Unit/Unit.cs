using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum ElementType {
        KD_Normal, KD_Fire, KD_Ice, MO_Normal, MO_Fire, MO_Ice  }

    ElementType elementType;
    Camera mainCam;

    UnitMove unitMove;


    public void Initialize(ElementType elementInput) {
        elementType = elementInput;
    }

    void Start() {
        unitMove = GetComponent<UnitMove>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        unitMove.Move(elementType);
        isOnScreen();
    }


    void isOnScreen() {
        Vector3 screenPoint = mainCam.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            Destroy(gameObject);
    }
}