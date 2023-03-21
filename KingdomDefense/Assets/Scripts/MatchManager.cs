using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchManager : MonoBehaviour
{
    public static MatchManager instance = null;

    public TextMeshProUGUI timeText;
    public Image gemImage;
    public TextMeshProUGUI gemText;

    public int time = 180;
    public int gem = 0;
    public int elementTempurature = 0;

    public GameObject obj;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(TimeCount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 mPosition = Input.mousePosition; //마우스의 스크린 좌표를 입력받는다.
            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition); //입력 받은 마우스의 좌표값을 월드좌표로 변환
            Instantiate(obj, target, Quaternion.identity); //변환한 위치에 원하는 오브젝트를 생성
        }
    }

    private IEnumerator TimeCount()
    {
        while (true)
        {
            if (++gem > 10)
                gem = 10;
            gemImage.fillAmount = (float)gem / 10f;
            gemText.text = gem.ToString();

            timeText.text = --time / 60 + ":" + time % 60;
            yield return new WaitForSeconds(1f);
        }
    }
}