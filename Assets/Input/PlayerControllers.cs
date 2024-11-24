//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerControllers.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControllers: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllers()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllers"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""0fe003f6-d15e-42d7-a48d-8dc968b85958"",
            ""actions"": [
                {
                    ""name"": ""Accelerator"",
                    ""type"": ""Button"",
                    ""id"": ""28a02890-f2d1-4293-b520-612e57ceec93"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""308ec550-afbd-49c5-9294-268231f4da10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""2fae21fb-af17-4a34-baf8-44573db6a7ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""732b91aa-f4d5-4f62-b8d2-3369ab9162d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""35df12e0-ef82-41a9-9c28-a8a85f30202c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""369e4b4b-a382-462d-b930-ef258424fe94"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerator"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c366313a-2084-4cb7-a3e8-c6c36000f73a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39ca7a9c-69e0-4bf6-81a2-9f65dd678bac"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""46c4ea7a-03a1-4f11-876e-f774d9fb9778"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""96da92f9-aa0b-4c5e-9f6f-3b15bb5865ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dfd83deb-dcf0-4d16-b828-b9507943bda2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""21bd9e4b-9497-47bc-8aaf-99a3ae04564d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Accelerator = m_Keyboard.FindAction("Accelerator", throwIfNotFound: true);
        m_Keyboard_Reverse = m_Keyboard.FindAction("Reverse", throwIfNotFound: true);
        m_Keyboard_Drift = m_Keyboard.FindAction("Drift", throwIfNotFound: true);
        m_Keyboard_Steering = m_Keyboard.FindAction("Steering", throwIfNotFound: true);
        m_Keyboard_Pause = m_Keyboard.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private List<IKeyboardActions> m_KeyboardActionsCallbackInterfaces = new List<IKeyboardActions>();
    private readonly InputAction m_Keyboard_Accelerator;
    private readonly InputAction m_Keyboard_Reverse;
    private readonly InputAction m_Keyboard_Drift;
    private readonly InputAction m_Keyboard_Steering;
    private readonly InputAction m_Keyboard_Pause;
    public struct KeyboardActions
    {
        private @PlayerControllers m_Wrapper;
        public KeyboardActions(@PlayerControllers wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerator => m_Wrapper.m_Keyboard_Accelerator;
        public InputAction @Reverse => m_Wrapper.m_Keyboard_Reverse;
        public InputAction @Drift => m_Wrapper.m_Keyboard_Drift;
        public InputAction @Steering => m_Wrapper.m_Keyboard_Steering;
        public InputAction @Pause => m_Wrapper.m_Keyboard_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Add(instance);
            @Accelerator.started += instance.OnAccelerator;
            @Accelerator.performed += instance.OnAccelerator;
            @Accelerator.canceled += instance.OnAccelerator;
            @Reverse.started += instance.OnReverse;
            @Reverse.performed += instance.OnReverse;
            @Reverse.canceled += instance.OnReverse;
            @Drift.started += instance.OnDrift;
            @Drift.performed += instance.OnDrift;
            @Drift.canceled += instance.OnDrift;
            @Steering.started += instance.OnSteering;
            @Steering.performed += instance.OnSteering;
            @Steering.canceled += instance.OnSteering;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IKeyboardActions instance)
        {
            @Accelerator.started -= instance.OnAccelerator;
            @Accelerator.performed -= instance.OnAccelerator;
            @Accelerator.canceled -= instance.OnAccelerator;
            @Reverse.started -= instance.OnReverse;
            @Reverse.performed -= instance.OnReverse;
            @Reverse.canceled -= instance.OnReverse;
            @Drift.started -= instance.OnDrift;
            @Drift.performed -= instance.OnDrift;
            @Drift.canceled -= instance.OnDrift;
            @Steering.started -= instance.OnSteering;
            @Steering.performed -= instance.OnSteering;
            @Steering.canceled -= instance.OnSteering;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnAccelerator(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
