using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class InGameMenuLoading : MonoBehaviour
{
    [SerializeField] CanvasGroup makerLogo;
    [SerializeField] CanvasGroup fileCheckSystem;
    //  [SerializeField] CanvasGroup menu;
    //  [SerializeField] CanvasGroup chapters;

    [SerializeField] bool isFade;
    [SerializeField] bool isSceneLoading;
    [SerializeField] Button touchToStart;
    Utility utility;
    private RectTransform loadingBar;

    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        utility = Utility.getInstance();
        utility.setFraneFPS(60);
        utility.screenAutoSizeUI(canvas, "GameLogo", Vector2.zero, new Vector2(6, 6), new Vector3(0, -40, 0));
        utility.screenAutoSizeUI(canvas, "CheckLoading", new Vector2(2, 80), Vector2.zero, Vector3.zero);
        utility.screenAutoSizeUI(canvas, "VersionCheck", Vector2.zero, new Vector2(40, 40), new Vector3(30, 30, 0));
        makerLogo = utility.FindGameObjectWithName(canvas, "MakerLogo").GetComponent<CanvasGroup>();
        utility.screenAutoSizeUI(canvas, "CompanyLogo", Vector2.zero, new Vector2(3, 3), Vector3.zero);

        fileCheckSystem = utility.FindGameObjectWithName(canvas, "FileCheckSystem").GetComponent<CanvasGroup>();
        touchToStart = utility.FindGameObjectWithName(canvas, "TouchToStart").GetComponent<Button>();
        touchToStart.onClick.AddListener(utility.allowScene);
        //Animation Stage.
        utility.manualCanvasFadeUI(makerLogo, 1, 7, 1f, 0.001f, true, false);
        //other UIS

        // checking with the code.
        print(utility.FindGameObjectWithName(canvas, "VersionCheck").GetComponent<Button>());
        utility.createPopUpMessage(false, canvas, "VersionCheck", Utility.PRESET.BOTTOM_LEFT,
         "Build_Version 1.5.1", "Project Nemesis still in development process.",
          new Vector2(3, 3), Vector2.zero, new Vector3(20, 20, 0));

        utility.createPopUpMessage(true, canvas, "FileCheckSystem", Utility.PRESET.MIDDLE_CENTER,
        "WARNING THIS IS ALPHA VERSION ", "This game dose not save any files, please be aware that this game is still in the development progress.",
         new Vector2(3, 3), Vector2.zero, Vector3.zero);
        // test evnironment 
        fadeWithAnimation(supgee());
    }

    private bool supgee()
    {
        print("hello");
        return true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Fading function by code

    // not a clean area.
    private bool fadeWithAnimation(bool sup)
    {
        return sup;
    }



}
