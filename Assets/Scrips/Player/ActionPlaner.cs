// GENERATED AUTOMATICALLY FROM 'Assets/Scrips/Player/ActionPlaner.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionPlaner : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ActionPlaner()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionPlaner"",
    ""maps"": [
        {
            ""name"": ""thirdPerson"",
            ""id"": ""6784067c-a78b-45e2-b2b4-4f4c30eb53de"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""81f1ce7f-5c45-4aeb-9348-49ccb940969b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Directional"",
                    ""type"": ""Value"",
                    ""id"": ""ed66e810-1bff-4c9f-abf5-66fa3454d48c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45a8cdbd-60cc-4048-8aca-12af180cbe8d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""85e6bf6a-fbc0-43ed-8875-bbf122c346f5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""308795ff-f9fe-4eb6-abe5-ff4444d81926"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4fc83435-7def-4eb1-9adf-27bd740e817c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2b2eae17-5024-4e5b-9ce5-d734ac496a6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""44c74f8f-0c26-4b5e-b31d-a56c6fa5b503"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directional"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // thirdPerson
        m_thirdPerson = asset.FindActionMap("thirdPerson", throwIfNotFound: true);
        m_thirdPerson_Jump = m_thirdPerson.FindAction("Jump", throwIfNotFound: true);
        m_thirdPerson_Directional = m_thirdPerson.FindAction("Directional", throwIfNotFound: true);
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

    // thirdPerson
    private readonly InputActionMap m_thirdPerson;
    private IThirdPersonActions m_ThirdPersonActionsCallbackInterface;
    private readonly InputAction m_thirdPerson_Jump;
    private readonly InputAction m_thirdPerson_Directional;
    public struct ThirdPersonActions
    {
        private @ActionPlaner m_Wrapper;
        public ThirdPersonActions(@ActionPlaner wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_thirdPerson_Jump;
        public InputAction @Directional => m_Wrapper.m_thirdPerson_Directional;
        public InputActionMap Get() { return m_Wrapper.m_thirdPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThirdPersonActions set) { return set.Get(); }
        public void SetCallbacks(IThirdPersonActions instance)
        {
            if (m_Wrapper.m_ThirdPersonActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnJump;
                @Directional.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnDirectional;
                @Directional.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnDirectional;
                @Directional.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnDirectional;
            }
            m_Wrapper.m_ThirdPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Directional.started += instance.OnDirectional;
                @Directional.performed += instance.OnDirectional;
                @Directional.canceled += instance.OnDirectional;
            }
        }
    }
    public ThirdPersonActions @thirdPerson => new ThirdPersonActions(this);
    public interface IThirdPersonActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDirectional(InputAction.CallbackContext context);
    }
}
