using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Utility : MonoBehaviour
{
    // Start is called before the first frame update
    private static Utility instance;
    private static GameObject utilityPrefab;
    private AsyncOperation operation;
    //Singleton case to brint them method.
    public void setFraneFPS(int frame)
    {
        Application.targetFrameRate = frame;
    }
    public static Utility getInstance()
    {
        if (instance == null && utilityPrefab == null)
        {
            utilityPrefab = new GameObject();
            utilityPrefab.name = "UtilityTools";
            utilityPrefab.AddComponent<Utility>();
            instance = utilityPrefab.GetComponent<Utility>();
            print("Utility Instantiated");
        }
        return instance;
    }
    public void loadMe(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void createButtonSetup(GameObject original, string panelName, string backButtonName)
    {

        GameObject panelObject = FindGameObjectWithName(GameObject.Find("Canvas"), panelName);
        //print(panelObject);
        Button backButton = FindGameObjectWithName(GameObject.Find("Canvas"), backButtonName).GetComponent<Button>();
        original.GetComponent<Button>().onClick.AddListener(() => panelObject.SetActive(true));
        backButton.onClick.AddListener(() => panelObject.SetActive(false));
        panelObject.SetActive(false);

    }

    ///<summary> Finding transform with specific target name. </summary>
    public GameObject FindGameObjectWithName(GameObject parent, string objectName)
    {
        Transform[] tempParent = parent.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in tempParent)
        {
            if (child.transform.name == objectName)
            {
                return child.gameObject;
            }
        }
        return null;
    }
    ///<summary> Automatically matching with the current user screen.  Low Vector2 number gets the bigger size, higher number gets lower size.</summary>
    public RectTransform screenAutoSizeUI(GameObject parent, string objectName, Vector2 diff, Vector2 changeSize, Vector3 positionDiff)
    {
        RectTransform uiSize;
        uiSize = FindGameObjectWithName(parent, objectName).GetComponent<RectTransform>();
        if (changeSize != Vector2.zero)
        {
            uiSize.sizeDelta = new Vector2((Screen.width / changeSize.x), (Screen.width / changeSize.y));
        }
        if (diff != Vector2.zero)
        {
            uiSize.sizeDelta = new Vector2((Screen.width / diff.x), (Screen.height / diff.y));
        }
        if (positionDiff != Vector3.zero)
        {
            uiSize.anchoredPosition = positionDiff;
        }
        return uiSize;
    }
    ///<summary> slider function for easy access. </summary>
    public Slider setSliderUI(GameObject parent, string objectName, float min, float max, float value, bool isAllowed)
    {
        Slider slider;
        slider = FindGameObjectWithName(parent, objectName).GetComponent<Slider>();
        if (isAllowed)
        {
            slider.minValue = min;
            slider.maxValue = max;
            slider.value = value;
        }
        return slider;
    }
    ///<summary> when the endtime reached the code will be executued after the code. </summary>
    public void manualCanvasFadeUI(CanvasGroup canvas, int nextScene, float endTime, float fadeSpeed, float delaySecond, bool isFadeOut, bool isFadeIn)
    {
        if (isFadeIn)
        {
            canvas.alpha = 0f;
        }
        StartCoroutine(manualCanvasFade(canvas, nextScene, endTime, fadeSpeed, delaySecond, isFadeOut, isFadeIn));
    }

    public void allowScene()
    {
        operation.allowSceneActivation = true;
    }
    private IEnumerator manualCanvasFade(CanvasGroup canvas, int nextScene, float endTime, float fadeSpeed, float delaySecond, bool isFadeOut, bool isFadeIn)
    {
        yield return new WaitForSeconds(endTime);
        while (isFadeOut)
        {
            float fadeAmount = canvas.alpha - (fadeSpeed * Time.deltaTime);
            canvas.alpha = fadeAmount;
            //  print(fadeAmount);
            yield return new WaitForSeconds(delaySecond);
            if (canvas.alpha <= 0)
            {
                isFadeOut = false;
                canvas.gameObject.SetActive(false);
                // move to next Scene.
                StartCoroutine(loadAsync(nextScene));

            }
        }
        while (isFadeIn)
        {
            float fadeAmount = (fadeSpeed * Time.deltaTime);
            canvas.alpha += fadeAmount;
            yield return new WaitForSeconds(delaySecond);
            if (canvas.alpha >= 1)
            {
                isFadeIn = false;
                StartCoroutine(loadAsync(nextScene));
            }
        }

    }
    IEnumerator loadAsync(int index)
    {
        operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            // print(operation.ToString());
            FindGameObjectWithName(GameObject.Find("Canvas"), "CheckLoading").GetComponent<Slider>().value = progress;
            FindGameObjectWithName(GameObject.Find("Canvas"), "LoadText").GetComponent<TextMeshProUGUI>().text = progress * 100f + "%";
            //  print("LogProgress:" + progress);
            yield return null;
        }
    }

    public enum PRESET
    {
        MIDDLE_CENTER,
        BOTTOM_LEFT,
        BOTTOM_RIGHT,
        TOP_LEFT,
        TOP_RIGHT

    }
    public void createPopUpMessage(bool isPopUp, GameObject parent, string objectName, PRESET POS, string title, string paragraph, Vector2 diff, Vector2 changeSize, Vector3 positionDiff)
    {
        //utility.FindGameObjectWithName(canvas, "VersionCheck").GetComponent<Button>()
        GameObject uiObject = FindGameObjectWithName(parent, objectName);
        // current button Button

        // get resource file and isntatinate.
        RectTransform rectTransform;
        GameObject uiObjectPrefab = Resources.Load("messagesUI/PopUpMessage") as GameObject;
        rectTransform = uiObjectPrefab.GetComponent<RectTransform>();
        print(uiObjectPrefab);
        RectTransform spawned = Instantiate(rectTransform, uiObject.transform);
        spawned.transform.name = "message";


        spawned.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title;
        spawned.transform.Find("Paragraph").GetComponent<TextMeshProUGUI>().text = paragraph;
        // screenAutoSizeUI(parent, objectName, diff, changeSize, positionDiff);
        //uiObject.GetComponent<TextMeshProUGUI>().text = textMessage;
        screenAutoSizeUI(parent, spawned.transform.name, diff, changeSize, positionDiff);
        FindGameObjectWithName(parent, "Close").GetComponent<Button>().onClick.AddListener(() => spawned.gameObject.SetActive(false));
        if (!isPopUp)
        {
            uiObject.GetComponent<Button>().onClick.AddListener(() => spawned.gameObject.SetActive(true));

            spawned.gameObject.SetActive(false);
        }
        else
        {
            spawned.gameObject.SetActive(true);
        }


        switch (POS)
        {
            case PRESET.MIDDLE_CENTER:
                {
                    spawned.anchorMax = new Vector2(0.5f, 0.5f);
                    spawned.anchorMin = new Vector2(0.5f, 0.5f);
                    spawned.pivot = new Vector2(0.5f, 0.5f);
                    break;
                }
            case PRESET.BOTTOM_LEFT:
                {
                    spawned.anchorMax = new Vector2(0, 0);
                    spawned.anchorMin = new Vector2(0, 0);
                    spawned.pivot = new Vector2(0, 0);
                    break;
                }
            case PRESET.BOTTOM_RIGHT:
                {
                    spawned.anchorMax = new Vector2(1, 0);
                    spawned.anchorMin = new Vector2(1, 0);
                    spawned.pivot = new Vector2(1, 0);
                    break;
                }
            case PRESET.TOP_RIGHT:
                {
                    spawned.anchorMax = new Vector2(1, 1);
                    spawned.anchorMin = new Vector2(1, 1);
                    spawned.pivot = new Vector2(1, 1);
                    break;
                }
            case PRESET.TOP_LEFT:
                {
                    spawned.anchorMax = new Vector2(0, 1);
                    spawned.anchorMin = new Vector2(0, 1);
                    spawned.pivot = new Vector2(0, 1);
                    break;
                }
            default:
                {
                    Debug.LogError("cant find the position");
                    break;
                }
        }

    }

    public void animationWithUI()
    {

    }
}
