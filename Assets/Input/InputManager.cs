using UnityEngine.Events;
using UnityEngine.InputSystem;

public static class InputManager 
{
    private static bool isInitialized = false;

    private static PlayerControllers playerControllers;

    private static float steeringDirection;
    public static float SteeringDirection { get => steeringDirection; }

    public static event UnityAction OnAcceleratorPerformed;
    public static event UnityAction OnAcceleratorCanceled;

    public static event UnityAction OnReversePerformed;
    public static event UnityAction OnReverseCanceled;

    public static event UnityAction OnDriftPerformed;
    public static event UnityAction OnDriftCanceled;

    public static void Initialize()
    {
        if(isInitialized) return;
        playerControllers = new PlayerControllers();
        playerControllers.Keyboard.Enable();

        playerControllers.Keyboard.Accelerator.performed += OnInputAccelerator;
        playerControllers.Keyboard.Accelerator.canceled += OnInputAccelerator;

        playerControllers.Keyboard.Reverse.performed += OnInputReverse;
        playerControllers.Keyboard.Reverse.canceled += OnInputReverse;

        playerControllers.Keyboard.Drift.performed += OnInputDrift;
        playerControllers.Keyboard.Drift.canceled += OnInputDrift;

        playerControllers.Keyboard.Steering.performed += OnInputSteering;
        playerControllers.Keyboard.Steering.canceled += OnInputSteering;

        isInitialized = true;
    }

    private static void OnInputAccelerator(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) OnAcceleratorPerformed?.Invoke();
        if(ctx.canceled) OnAcceleratorCanceled?.Invoke();
    }

    private static void OnInputReverse(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) OnReversePerformed?.Invoke();
        if(ctx.canceled) OnReverseCanceled?.Invoke();
    }

    private static void OnInputDrift(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) OnDriftPerformed?.Invoke();
        if(ctx.canceled) OnDriftCanceled?.Invoke();
    }

    private static void OnInputSteering(InputAction.CallbackContext ctx)
    {
        steeringDirection = ctx.ReadValue<float>();
    }
}
