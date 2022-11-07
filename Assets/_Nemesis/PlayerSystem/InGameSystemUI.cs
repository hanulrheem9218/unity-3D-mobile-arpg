using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameSystemUI : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform miniMap;
    private RectTransform killLogs;
    private RectTransform playerProfile;
    [SerializeField] private Slider batteryStatus;
    [SerializeField] private TextMeshProUGUI textTime;

    void Start()
    {
        miniMap = transform.GetChild(2).GetComponent<RectTransform>();
        killLogs = transform.GetChild(3).GetComponent<RectTransform>();
        playerProfile = transform.GetChild(4).GetComponent<RectTransform>();
        batteryStatus = transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Slider>();
        batteryStatus.minValue = 0;
        batteryStatus.maxValue = 1;
        batteryStatus.value = SystemInfo.batteryLevel;
        textTime = transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        if (miniMap && killLogs && playerProfile)
        {
            miniMap.sizeDelta = new Vector2((Screen.width / 3), (Screen.height / 2));
            killLogs.sizeDelta = new Vector2((Screen.width / 3), (Screen.height / 2));
            playerProfile.sizeDelta = new Vector2((Screen.width / 3), (Screen.height / 2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        batteryStatus.value = SystemInfo.batteryLevel;
        textTime.text = System.DateTime.UtcNow.ToLocalTime().ToString();
    }
}
