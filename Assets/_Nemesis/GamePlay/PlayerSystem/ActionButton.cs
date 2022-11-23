using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionButton : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform touchField;
    private RectTransform defaultAction;
    private RectTransform actionOne;
    private RectTransform actionTwo;
    private RectTransform actionThr;
    private RectTransform interaction;
    private RectTransform consumable;
    private float currentScreenX;
    private float currentScreenY;
    private bool isScreenChanged;
    [SerializeField] private int xPosDiff;
    void Start()
    {
        touchField = GetComponent<RectTransform>();
        defaultAction = transform.GetChild(0).GetComponent<RectTransform>();
        actionOne = transform.GetChild(1).GetComponent<RectTransform>();
        actionTwo = transform.GetChild(2).GetComponent<RectTransform>();
        actionThr = transform.GetChild(3).GetComponent<RectTransform>();
        interaction = transform.GetChild(4).GetComponent<RectTransform>();
        consumable = transform.GetChild(5).GetComponent<RectTransform>();
        currentScreenX = (Screen.width / 2);
        currentScreenY = (Screen.height / 2);
        if (touchField && defaultAction && actionOne && actionTwo && actionThr)
        {
            touchField.sizeDelta = new Vector2(currentScreenX, currentScreenY);

            defaultAction.sizeDelta = new Vector2(currentScreenX / 8, currentScreenX / 8); //size
            defaultAction.anchoredPosition = new Vector3((currentScreenX / 14), -(currentScreenY / 16), 0); //position

            actionOne.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            actionOne.anchoredPosition = new Vector3(-(currentScreenX / 10), -(currentScreenY / 12), 0);

            actionTwo.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            actionTwo.anchoredPosition = new Vector3(-(currentScreenX / 24), (currentScreenY / 5), 0);

            actionThr.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            actionThr.anchoredPosition = new Vector3((currentScreenX / 10), (currentScreenY / 4), 0);

            interaction.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            interaction.anchoredPosition = new Vector3((currentScreenX / 4), (currentScreenY / 5), 0);

            consumable.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            consumable.anchoredPosition = new Vector3(-(currentScreenX / 4), -(currentScreenY / 3), 0);
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // delete this u dont need it.
        if ((currentScreenY <= Screen.height || currentScreenX <= Screen.width) && !isScreenChanged)
        {
            // currentScreenX = (Screen.width / 2);
            // currentScreenY = (Screen.height / 2);
            // touchField.sizeDelta = new Vector2(currentScreenX, currentScreenY);

            // defaultAction.sizeDelta = new Vector2(currentScreenX / 8, currentScreenX / 8);
            // defaultAction.anchoredPosition = new Vector3((currentScreenX / 14), -(currentScreenY / 16), 0);

            // actionOne.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            // actionOne.anchoredPosition = new Vector3(-(currentScreenX / 10), -(currentScreenY / 12), 0);

            // actionTwo.sizeDelta = new Vector2(currentScreenX / 10, currentScreenX / 10);
            // actionTwo.anchoredPosition = new Vector3(-(currentScreenX / 8), -(currentScreenY / 12), 0);
            isScreenChanged = true;
        }

    }
    void Update()
    {

    }
}
