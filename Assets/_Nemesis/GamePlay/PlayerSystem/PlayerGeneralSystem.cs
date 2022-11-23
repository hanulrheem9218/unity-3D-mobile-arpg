using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralSystem : MonoBehaviour
{
    private MovementJoystick _movementJoyStick;
    private Animator playerAnimator;
    private float inputX;
    private float inputZ;
    // Start is called before the first frame update
    void Start()
    {
        _movementJoyStick = FindObjectOfType<MovementJoystick>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = _movementJoyStick.inputVertical();
        inputZ = _movementJoyStick.inputHorizontal();
        if ((inputX != 0 || inputZ != 0))
        {
            playerAnimator.SetBool("isWalk", true);
            playerAnimator.SetBool("isRun", true);
        }
        else
        {
            playerAnimator.SetBool("isWalk", false);
            playerAnimator.SetBool("isRun", false);
        }
    }
}
