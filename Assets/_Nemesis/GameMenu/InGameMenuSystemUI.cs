using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InGameMenuSystemUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] CanvasGroup menu;
    [SerializeField] CanvasGroup chapters;
    [SerializeField] CanvasGroup fileCheckingSystem;
    private Button touchToStart;

    Utility utility;
    void Start()
    {
        //  controlSizeLoader<Transform>("MakerLogo", 0.1f);
        utility = Utility.getInstance();
        GameObject canvas = GameObject.Find("Canvas");
        menu = utility.FindGameObjectWithName(canvas, "Menu").GetComponent<CanvasGroup>();
        //chapters = utility.FindGameObjectWithName(canvas, "Chapters").GetComponent<CanvasGroup>();
        fileCheckingSystem = utility.FindGameObjectWithName(canvas, "FileCheckSystem").GetComponent<CanvasGroup>();
        touchToStart = utility.FindGameObjectWithName(canvas, "TouchToStart").GetComponent<Button>();
        touchToStart.onClick.AddListener(utility.allowScene);
        //ceecking the size.
        utility.screenAutoSizeUI(canvas, "Options", new Vector2(3, 3), Vector2.zero, new Vector3(-500, 160, 0));
        utility.screenAutoSizeUI(canvas, "GameLogo", Vector2.zero, new Vector2(6, 6), new Vector3(0, -40, 0));
        utility.screenAutoSizeUI(canvas, "MenuGameLogo", Vector2.zero, new Vector2(6, 6), new Vector3(-500, -40, 0));
        //  print(utility.FindGameObjectWithName(canvas, "VersionCheck").GetComponent<Button>());
        utility.createPopUpMessage(false, canvas, "VersionCheck", Utility.PRESET.BOTTOM_LEFT,
         "Build_Version 1.5.1", "Project Nemesis still in development process.",
          new Vector2(3, 3), Vector2.zero, new Vector3(20, 20, 0));
        utility.createPopUpMessage(false, canvas, "MenuCheck", Utility.PRESET.BOTTOM_LEFT,
         "Build_Version 1.5.1", "Project Nemesis still in development process.",
          new Vector2(3, 3), Vector2.zero, new Vector3(20, 20, 0));
        utility.screenAutoSizeUI(canvas, "ChaptersBack", new Vector2(20, 20), Vector2.zero, new Vector3(-20, 20, 0));
        utility.createButtonSetup(utility.FindGameObjectWithName(canvas, "Chapters"), "ChapterPanel", "ChaptersBack");
        utility.FindGameObjectWithName(canvas, "Quit").GetComponent<Button>().onClick.AddListener(() => Application.Quit());
    }

    public void startChapter(int index)
    {
        utility.manualCanvasFadeUI(fileCheckingSystem, index, 0, 1f, 0.001f, false, true);
        utility.FindGameObjectWithName(GameObject.Find("Canvas"), "Menu").gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //MakerLogo
        // manualFade(makerLogo, 0.5f, Time.deltaTime, true, 7);
        //FileCheckSystem
        //Menu
        //Chapters
    }


    // Utitilities

}
