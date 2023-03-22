using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchManager : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] TextMeshProUGUI timeText;
    public Image gemImage;
    public TextMeshProUGUI gemText;
    [SerializeField] Slider fireSlider;
    [SerializeField] Slider iceSlider;
    [SerializeField] Slider kingdomHeartBar;
    [SerializeField] Slider monsterHeartBar;
    [SerializeField] GameObject kingdomCastle;
    [SerializeField] GameObject monsterCastle;

    public int time = 180;
    public int gem = 0;
    public int firePower = 0;
    public int icePower = 0;

    private float size_y_;
    private float size_x_;
    public float bottomBounder
    {
        get
        {
            return size_y_ * -1 + mainCamera.gameObject.transform.position.y;
        }
    }
    public float topBounder
    {
        get
        {
            return size_y_ + mainCamera.gameObject.transform.position.y;
        }
    }
    public float leftBounder
    {
        get
        {
            return size_x_ * -1 + mainCamera.gameObject.transform.position.x;
        }
    }
    public float rightBounder
    {
        get
        {
            return size_x_ + mainCamera.gameObject.transform.position.x;
        }
    }

    private UnitInfo kingdomCastleInfo;
    private UnitInfo monsterCastleInfo;

    public GameObject obj;

    private void Start()
    {
        mainCamera = Camera.main;
        size_y_ = mainCamera.orthographicSize;
        size_x_ = mainCamera.orthographicSize * Screen.width / Screen.height;

        GameStart();
    }

    private void GameStart()
    {
        float middle = (leftBounder + rightBounder) / 2;
        kingdomCastleInfo = GameObject.Find("KingdomCastle").GetComponent<UnitInfo>();
        monsterCastleInfo = GameObject.Find("MonsterCastle").GetComponent<UnitInfo>();

        StartCoroutine(TimeCount());
    }

    private void Update()
    {
        fireSlider.value = firePower;
        iceSlider.value = icePower;

        kingdomHeartBar.value = kingdomCastleInfo.hp;
        monsterHeartBar.value = monsterCastleInfo.hp;
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

    public void FirePowerUP()
    {
        if (icePower > 0)
            icePower--;
        else
            firePower++;
    }

    public void IcePowerUP()
    {
        if (firePower > 0)
            firePower--;
        else
            icePower++;
    }
}