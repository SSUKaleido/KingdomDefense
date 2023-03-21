using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public int time = 0;
    public int elementTempurature = 0;

    public GameObject obj;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 mPosition = Input.mousePosition; //마우스의 스크린 좌표를 입력받는다.
            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); //입력 받은 마우스의 좌표값을 월드좌표로 변환
            Instantiate(obj, target, Quaternion.identity); //변환한 위치에 원하는 오브젝트를 생성
        }
    }
}