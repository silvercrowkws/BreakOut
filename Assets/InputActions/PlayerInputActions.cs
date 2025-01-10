//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/InputActions/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""2d01f56e-2978-4c75-bc95-7eb652dc551d"",
            ""actions"": [
                {
                    ""name"": ""MoveAction"",
                    ""type"": ""Value"",
                    ""id"": ""53f0d65b-eb48-428b-944b-676f7bad3bc2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5e85caec-d244-4897-8e30-19ddda689941"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bee4580d-8012-4319-98cc-1ea3b82c8615"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49221c2e-84da-4fa7-9300-4ef05aa79966"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""StartBall"",
            ""id"": ""6fba4625-025a-4506-869c-5d046823fb77"",
            ""actions"": [
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""5f5c720f-42b2-45b2-8300-2c8e13606e7d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1fc0ba64-4867-453c-a58a-334872cd1233"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";KM"",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KM"",
            ""bindingGroup"": ""KM"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_MoveAction = m_Move.FindAction("MoveAction", throwIfNotFound: true);
        // StartBall
        m_StartBall = asset.FindActionMap("StartBall", throwIfNotFound: true);
        m_StartBall_Space = m_StartBall.FindAction("Space", throwIfNotFound: true);
    }

    ~@PlayerInputActions()
    {
        UnityEngine.Debug.Assert(!m_Move.enabled, "This will cause a leak and performance issues, PlayerInputActions.Move.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_StartBall.enabled, "This will cause a leak and performance issues, PlayerInputActions.StartBall.Disable() has not been called.");
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

    // Move
    private readonly InputActionMap m_Move;
    private List<IMoveActions> m_MoveActionsCallbackInterfaces = new List<IMoveActions>();
    private readonly InputAction m_Move_MoveAction;
    public struct MoveActions
    {
        private @PlayerInputActions m_Wrapper;
        public MoveActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveAction => m_Wrapper.m_Move_MoveAction;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void AddCallbacks(IMoveActions instance)
        {
            if (instance == null || m_Wrapper.m_MoveActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MoveActionsCallbackInterfaces.Add(instance);
            @MoveAction.started += instance.OnMoveAction;
            @MoveAction.performed += instance.OnMoveAction;
            @MoveAction.canceled += instance.OnMoveAction;
        }

        private void UnregisterCallbacks(IMoveActions instance)
        {
            @MoveAction.started -= instance.OnMoveAction;
            @MoveAction.performed -= instance.OnMoveAction;
            @MoveAction.canceled -= instance.OnMoveAction;
        }

        public void RemoveCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMoveActions instance)
        {
            foreach (var item in m_Wrapper.m_MoveActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MoveActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MoveActions @Move => new MoveActions(this);

    // StartBall
    private readonly InputActionMap m_StartBall;
    private List<IStartBallActions> m_StartBallActionsCallbackInterfaces = new List<IStartBallActions>();
    private readonly InputAction m_StartBall_Space;
    public struct StartBallActions
    {
        private @PlayerInputActions m_Wrapper;
        public StartBallActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Space => m_Wrapper.m_StartBall_Space;
        public InputActionMap Get() { return m_Wrapper.m_StartBall; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StartBallActions set) { return set.Get(); }
        public void AddCallbacks(IStartBallActions instance)
        {
            if (instance == null || m_Wrapper.m_StartBallActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StartBallActionsCallbackInterfaces.Add(instance);
            @Space.started += instance.OnSpace;
            @Space.performed += instance.OnSpace;
            @Space.canceled += instance.OnSpace;
        }

        private void UnregisterCallbacks(IStartBallActions instance)
        {
            @Space.started -= instance.OnSpace;
            @Space.performed -= instance.OnSpace;
            @Space.canceled -= instance.OnSpace;
        }

        public void RemoveCallbacks(IStartBallActions instance)
        {
            if (m_Wrapper.m_StartBallActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStartBallActions instance)
        {
            foreach (var item in m_Wrapper.m_StartBallActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StartBallActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StartBallActions @StartBall => new StartBallActions(this);
    private int m_KMSchemeIndex = -1;
    public InputControlScheme KMScheme
    {
        get
        {
            if (m_KMSchemeIndex == -1) m_KMSchemeIndex = asset.FindControlSchemeIndex("KM");
            return asset.controlSchemes[m_KMSchemeIndex];
        }
    }
    public interface IMoveActions
    {
        void OnMoveAction(InputAction.CallbackContext context);
    }
    public interface IStartBallActions
    {
        void OnSpace(InputAction.CallbackContext context);
    }
}
