using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject[] spawnUnits;
    public GameObject spawnUnitImage;

    private GameObject unitImage;
    private Vector2 mousePosition;
    private Camera mainCamera;
    [SerializeField] GameObject matchManager;

    private const int leftBounder = -13;
    private const int rightBounder = -5;
    private const int upBounder = -1;
    private const int downBounder = -4;


    void Start()
    {
        mainCamera = Camera.main;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);

        unitImage = Instantiate(spawnUnitImage, new Vector3(mousePosition.x, mousePosition.y, 1), Quaternion.identity);
        unitImage.SetActive(false);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);

        if (mousePosition.x >= leftBounder && mousePosition.x <= rightBounder)
        {
            if (unitImage.activeSelf == false)
                unitImage.SetActive(true);

            if (mousePosition.y > upBounder)
                mousePosition.y = upBounder;
            if (mousePosition.y < downBounder)
                mousePosition.y = downBounder;
            
            unitImage.transform.position = mousePosition;
        }
        else
        {
            if (unitImage.activeSelf)
                unitImage.SetActive(false);
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (matchManager == null)
            matchManager = GameObject.Find("MatchManager");

        if (unitImage.activeSelf) {
            GameObject newUnit = Instantiate(spawnUnits[Random.Range(0, spawnUnits.Length)], new Vector3(mousePosition.x, mousePosition.y, 1), Quaternion.identity);
            UnitInfo newUnitInfo = newUnit.GetComponent<UnitInfo>();

            if (matchManager != null && matchManager.GetComponent<MatchManager>().gem >= newUnitInfo.cost)
            {
                MatchManager matchManagerScript = matchManager.GetComponent<MatchManager>();

                matchManagerScript.gem -= newUnitInfo.cost;
                matchManagerScript.gemImage.fillAmount = matchManagerScript.gem / 10f;
                matchManagerScript.gemText.text = matchManagerScript.gem.ToString();

                if ((int)newUnitInfo.elementType == 0b10 && matchManagerScript.firePower < 10)
                    matchManagerScript.FirePowerUP();
                if ((int)newUnitInfo.elementType == 0b100 && matchManagerScript.icePower < 10)
                    matchManagerScript.IcePowerUP();
            }
            else
                Destroy(newUnit);
        }
        
        Destroy(unitImage);
    }
}