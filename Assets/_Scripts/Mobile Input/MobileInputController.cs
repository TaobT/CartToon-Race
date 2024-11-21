using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileInputController : MonoBehaviour
{
    [SerializeField] private MobileInputButton aceleratorBtn;
    [SerializeField] private MobileInputButton brakeBtn;
    [SerializeField] private MobileInputButton leftBtn;
    [SerializeField] private MobileInputButton rightBtn;

    private void Awake()
    {
        aceleratorBtn.OnPointerDown += AcceleratorPressed;
        aceleratorBtn.OnPointerUp += AcceleratorReleased;

        brakeBtn.OnPointerDown += BrakePressed;
        brakeBtn.OnPointerUp += BrakeReleased;

        rightBtn.OnPointerDown += LeftPressed;
        rightBtn.OnPointerUp += LeftReleased;

        rightBtn.OnPointerDown += RightPressed;
        rightBtn.OnPointerUp += RightReleased;
    }

    private void AcceleratorPressed()
    {
        InputManager.Mobile_OnInputAccelerator(true);
    }

    private void AcceleratorReleased()
    {
        InputManager.Mobile_OnInputAccelerator(false);
    }

    

    private void BrakePressed()
    {
        InputManager.Mobile_OnInputDrift(true);
    }

    private void BrakeReleased() 
    {
        InputManager.Mobile_OnInputDrift(false);
    }


    //TODO: Añadir reversa


    private void LeftPressed()
    {
        InputManager.Mobile_OnInputSteering(-1);
    }

    private void LeftReleased()
    {
        InputManager.Mobile_OnInputSteering(0);
    }


    private void RightPressed()
    {
        InputManager.Mobile_OnInputSteering(1);
    }

    private void RightReleased()
    {
        InputManager.Mobile_OnInputSteering(0);
    }
}
