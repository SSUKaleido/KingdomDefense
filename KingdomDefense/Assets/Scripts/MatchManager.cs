using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    /*  소환할 유닛들  */
    public GameObject unitPrefab;

    /*  마우스 위치에 유닛을 소환하기 위해 필요  */
    Vector3 MousePosition;
    Camera mainCam;

    /* 소환할 유닛의 속성과 진영  */
    public Unit.ElementType elementType;
    public Unit.JobType jobType;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        /*  마우스 왼쪽 버튼을 누르면 소환  */
        if (Input.GetMouseButtonDown(0)) {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
            NewUnit.GetComponent<Unit>().Initialize(elementType, jobType);
        }

                        if (Input.GetKeyDown(KeyCode.Q)) {
                            MousePosition = Input.mousePosition;
                            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

                            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
                            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
                            NewUnit.GetComponent<Unit>().Initialize(Unit.ElementType.KD_Normal, jobType);
                        }
                        if (Input.GetKeyDown(KeyCode.W)) {
                            MousePosition = Input.mousePosition;
                            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

                            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
                            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
                            NewUnit.GetComponent<Unit>().Initialize(Unit.ElementType.KD_Fire, jobType);
                        }
                        if (Input.GetKeyDown(KeyCode.E)) {
                            MousePosition = Input.mousePosition;
                            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

                            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
                            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
                            NewUnit.GetComponent<Unit>().Initialize(Unit.ElementType.KD_Ice, jobType);
                        }
                        if (Input.GetKeyDown(KeyCode.R)) {
                            MousePosition = Input.mousePosition;
                            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

                            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
                            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
                            NewUnit.GetComponent<Unit>().Initialize(Unit.ElementType.MO_Normal, jobType);
                        }
                        if (Input.GetKeyDown(KeyCode.T)) {
                            MousePosition = Input.mousePosition;
                            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

                            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
                            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
                            NewUnit.GetComponent<Unit>().Initialize(Unit.ElementType.MO_Fire, jobType);
                        }
                        if (Input.GetKeyDown(KeyCode.Y)) {
                            MousePosition = Input.mousePosition;
                            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

                            /*  Instantiate() 메서드로 소환한 후 Initalize() 메서드를 호출해주어야 함  */
                            GameObject NewUnit = Instantiate(unitPrefab, new Vector3(MousePosition.x, MousePosition.y, 1), Quaternion.identity);
                            NewUnit.GetComponent<Unit>().Initialize(Unit.ElementType.MO_Ice, jobType);
                        }
    }
}