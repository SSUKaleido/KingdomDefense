using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public GameObject unitPrefab;

    Vector3 MousePosition;
    Camera mainCam;
    public Unit.ElementType elementType;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
            NewUnit.GetComponent<Unit>().Initialize(elementType);
        }
    }
}