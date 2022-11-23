using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGamePlaySystemUI : MonoBehaviour
{
    // Start is called before the first frame update
    Utility utility;
    private RectTransform miniMap;
    private RectTransform playerMap;
    private RectTransform batteryInfo;
    private RectTransform batteryDisplay;
    private RectTransform quests;
    private RectTransform killLogs;
    private RectTransform playerProfile;
    private RectTransform dateTime;
    [SerializeField] private Slider batterySlider;
    [SerializeField] private TextMeshProUGUI textTime;
    private RectTransform playerBg;
    private RectTransform playerXP;
    void Start()
    {
        utility = Utility.getInstance();
        utility.setFraneFPS(60);
        GameObject canvas = GameObject.Find("Canvas");
        //MiniMap
        miniMap = utility.FindGameObjectWithName(canvas, "MiniMap").GetComponent<RectTransform>();
        playerMap = utility.FindGameObjectWithName(canvas, "PlayerMap").GetComponent<RectTransform>();
        batteryInfo = utility.FindGameObjectWithName(canvas, "BatteryStatus").GetComponent<RectTransform>();
        batterySlider = utility.FindGameObjectWithName(canvas, "Slider").GetComponent<Slider>();
        quests = utility.FindGameObjectWithName(canvas, "Quests").GetComponent<RectTransform>();
        utility.setSliderUI(canvas, "Slider", 0, 1, SystemInfo.batteryLevel, true);
        textTime = transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        //KilLogs
        killLogs = utility.FindGameObjectWithName(canvas, "KillLogs").GetComponent<RectTransform>();
        //PlayerPfrofile

        //Setting

        playerBg = utility.FindGameObjectWithName(canvas, "PlayerBg").GetComponent<RectTransform>();
        playerXP = utility.FindGameObjectWithName(canvas, "PlayerXP").GetComponent<RectTransform>();
        //MiniMap 
        utility.screenAutoSizeUI(canvas, "MiniMap", new Vector2(3, 2), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "PlayerMap", Vector2.zero, new Vector2(8, 8), new Vector3(20, -20, 0));
        utility.screenAutoSizeUI(canvas, "Quests", Vector2.zero, new Vector2(6, 8), new Vector3(-20, -20, 0));
        utility.screenAutoSizeUI(canvas, "BatteryStatus", new Vector2(8, 30), Vector2.zero, new Vector3(20, -(playerMap.sizeDelta.y + 30), 0));
        utility.screenAutoSizeUI(canvas, "Slider", new Vector2(16, 30), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "DateTime", new Vector2(16, 30), Vector2.zero, Vector3.zero);
        //KillLogs
        utility.screenAutoSizeUI(canvas, "KillLogs", new Vector2(3, 2), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "DeathLists", Vector2.zero, new Vector2(4, 10), new Vector3(20, -20, 0));
        utility.screenAutoSizeUI(canvas, "GameMenu", new Vector2(20, 5), Vector2.zero, new Vector3(-20, -20, 0));
        //PlayerProfile
        utility.screenAutoSizeUI(canvas, "PlayerProfile", new Vector2(3, 2), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "ProfileInfo", new Vector2(3, 8), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "PlayerBg", Vector2.zero, new Vector2(8 * 2, 8 * 2), Vector3.zero);
        utility.screenAutoSizeUI(canvas, "PlayerItems", new Vector2(16, 26), Vector2.zero, new Vector3(playerBg.sizeDelta.x + 10, (playerXP.sizeDelta.y * 2), 0));
        utility.screenAutoSizeUI(canvas, "PlayerXP", new Vector2(4, 48), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "PlayerHealth", new Vector2(4, 48), Vector2.zero, new Vector3(0, playerXP.sizeDelta.y, 0));

        //Settings

        //Inventory 
        // 
        utility.screenAutoSizeUI(canvas, "GeneralOptions", new Vector2(5f, 1), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "SettingContents", new Vector2(5, 6), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "OptionPanels", new Vector2(1.5f, 1), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "Inventory", new Vector2(2.5f, 1), Vector2.zero, Vector3.zero);
        utility.FindGameObjectWithName(canvas, "InventoryItems").GetComponent<GridLayoutGroup>().cellSize = new Vector2((Screen.width / 25f), (Screen.width / 25f));
        utility.screenAutoSizeUI(canvas, "InventoryItems", new Vector2(2.5f, 2.5f), Vector2.zero, new Vector3(0, 150f, 0));
        utility.screenAutoSizeUI(canvas, "Fragments", new Vector2(2.5f, 4), Vector2.zero, new Vector3(0, -40f, 0));
        utility.FindGameObjectWithName(canvas, "MainMenu").GetComponent<Button>().onClick.AddListener(() => utility.loadMe(1));
        utility.createButtonSetup(utility.FindGameObjectWithName(canvas, "SystemInven"), "Inventory", "InventoryBack");
        utility.createButtonSetup(utility.FindGameObjectWithName(canvas, "SystemMenu"), "Setting", "SettingsBack");

        utility.createPopUpMessage(true, canvas, "Canvas", Utility.PRESET.MIDDLE_CENTER,
       "Hello Player! welcome to the project Nemesis", "Collect Few boxes to gain item ability, you are welcome to use the controllers and action buttons.",
        new Vector2(3, 3), Vector2.zero, Vector3.zero);

    }

    void LateUpdate()
    {
        utility.setSliderUI(GameObject.Find("Canvas"), "Slider", 0, 1, SystemInfo.batteryLevel, false);
        textTime.text = System.DateTime.UtcNow.ToLocalTime().ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
