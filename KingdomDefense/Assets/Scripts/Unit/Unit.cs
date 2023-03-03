using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum ElementType {
        KD_Normal, KD_Fire, KD_Ice, MO_Normal, MO_Fire, MO_Ice  }

    public int speed = 2;
    ElementType elementType;

    public void Initialize(ElementType elementInput) {
        elementType = elementInput;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
    }
}