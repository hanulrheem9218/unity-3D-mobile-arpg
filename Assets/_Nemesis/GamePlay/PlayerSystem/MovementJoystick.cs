using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MovementJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform touchField;
    private float currentScreenX;
    private float currentScreenY;
    private Image imgJoystickBg;
    private Image imgJoyStick;
    private Vector2 posInput;
    private Vector2 touchAreaInput;
    private RectTransform touchContainer;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject test;
    private float inputX;
    private float inputZ;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 playerRotation;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 8f;
        // rotationSpeed = 0.08f;
        imgJoystickBg = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        touchContainer = transform.GetChild(0).GetComponent<RectTransform>();
        imgJoyStick = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        touchField = GetComponent<RectTransform>();
        currentScreenX = (Screen.width / 2.5f);
        currentScreenY = (Screen.height / 2.5f);
        playerObject = GameObject.FindWithTag("Player").gameObject;
        //test = GameObject.Find("PlayerContainer").transform.Find("Cube").gameObject;
        if (touchField && imgJoystickBg)
        {
            //imgJoystickBg.rectTransform.anchoredPosition = new Vector3(-(currentScreenX / 8), -(currentScreenY / 10), 0);
            touchContainer.anchoredPosition = new Vector2((currentScreenX / 7), (currentScreenY / 6));
            imgJoystickBg.rectTransform.sizeDelta = new Vector2((currentScreenX / 4), (currentScreenX / 4));
            imgJoyStick.rectTransform.sizeDelta = new Vector2((currentScreenX / 8), (currentScreenX / 8));
            touchField.sizeDelta = new Vector2(currentScreenX, currentScreenY);


        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoystickBg.rectTransform, eventData.position, eventData.enterEventCamera, out posInput))
        {
            posInput.x = posInput.x / (imgJoystickBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (imgJoystickBg.rectTransform.sizeDelta.y);

            //movment ?
            //playerObject.transform.Rotate(Vector3.up, imgJoyStick.rectTransform.anchoredPosition.y)
            // Debug.Log(posInput.x.ToString() + "/" + posInput.y);
            // nomralize
            if (posInput.magnitude > 1.0f) // if its less becomes 0 or 1
            {
                posInput = posInput.normalized;
            }
            //  playerObject.transform.position += transform.forward * 10 * Time.deltaTime;
            imgJoyStick.rectTransform.anchoredPosition = new Vector2(posInput.x * (imgJoystickBg.rectTransform.sizeDelta.x - 100 / 1), posInput.y * (imgJoystickBg.rectTransform.sizeDelta.y - 100 / 1));
        }


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(touchField, eventData.position, eventData.enterEventCamera, out touchAreaInput))
        {
            // Debug.Log("Area Input: " + touchAreaInput.x.ToString() + "/" + touchAreaInput.y.ToString());
            touchContainer.anchoredPosition = new Vector3(touchAreaInput.x - 200, touchAreaInput.y - 200, 0);
        }
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        touchContainer.anchoredPosition = new Vector2((currentScreenX / 7), (currentScreenY / 6));
        imgJoyStick.rectTransform.anchoredPosition = Vector2.zero;
    }


    public float inputHorizontal()
    {
        if (posInput.x != 0)
        {
            return posInput.x;
        }
        return Input.GetAxis("Horizontal");
    }
    public float inputVertical()
    {
        if (posInput.y != 0)
        {
            return posInput.y;
        }
        return Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if (currentScreenY <= Screen.height || currentScreenX <= Screen.width)
        // {

        //     currentScreenX = (Screen.width / 2);
        //     currentScreenY = (Screen.height / 2);
        //     imgJoystickBg.rectTransform.anchoredPosition = new Vector3(-(currentScreenX / 8), -(currentScreenY / 10), 0);
        //     imgJoystickBg.rectTransform.sizeDelta = new Vector2((currentScreenX / 4), (currentScreenX / 4));
        //     imgJoyStick.rectTransform.sizeDelta = new Vector2((currentScreenX / 8), (currentScreenX / 8));
        //     touchField.sizeDelta = new Vector2(currentScreenX, currentScreenY);
        // }
    }
    void Update()
    {
        inputX = inputHorizontal();
        inputZ = inputVertical();
        // Debug.Log("Horizontal" + inputX + "Vertical" + inputVertical());
        if (inputX != 0 || inputZ != 0)
        {
            playerRotation = new Vector3(inputX * Time.deltaTime, 0, inputZ * Time.deltaTime);
            playerObject.transform.rotation = Quaternion.LookRotation(playerRotation);
            playerObject.transform.position += playerObject.transform.forward * Time.deltaTime * movementSpeed;
        }
        // playerObject.transform.Translate(inputX * Time.deltaTime * movementSpeed, 0, inputZ * Time.deltaTime * movementSpeed);

    }
}
