// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""9fac34ce-487a-4f9a-b34d-505fd7cbb5c0"",
            ""actions"": [
                {
                    ""name"": ""Hit"",
                    ""type"": ""Button"",
                    ""id"": ""47b45947-3028-4be7-84d6-e1eef7dab35d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""117a0252-8b98-4efa-8f76-da64a1f47d4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""006a6d8d-5524-426f-b45e-346790aff18a"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""c415b5ce-4feb-4334-9673-255ddbc5289d"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""b2b908eb-e9f9-49a2-a7e0-068f884c0e8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""aaed7ac6-93b2-4282-900c-1611bce21bda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KHit"",
                    ""type"": ""Button"",
                    ""id"": ""62835e6c-33f5-4318-89f6-b83af3454734"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KDodge"",
                    ""type"": ""Button"",
                    ""id"": ""9845589f-cdc0-4866-ba59-109832e8ef09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KPickup"",
                    ""type"": ""Button"",
                    ""id"": ""d876b37e-e5f0-4d85-8601-15e3518f65e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WASD"",
                    ""type"": ""Button"",
                    ""id"": ""b3149f8e-2d92-4846-bcb7-43594c355486"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""c0c74b4f-1e5e-493a-a9a5-09fb33078c95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""261a5f19-5877-4f2d-8af2-1dcb1db18ab0"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31a34a65-f3be-46a6-8c87-077b25330247"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7880a9ac-1856-4314-8c7d-6eb69d8a2829"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d66408d-6b2c-4cf3-84b9-70d00c72a376"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3faffa3-e602-4a21-85a8-4cdc1e80c17f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cce6ef15-7c91-4c52-adc1-00cd385be9e0"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""461289ea-7a56-4344-a0ce-cc6a07edaa0e"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dbb049e-0c4e-4129-90ee-fb4afa88d73b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KDodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1e14fb5-4232-40b2-aa19-e752f752ece8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KPickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""217826eb-a660-4748-bffa-e3aa45398e73"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f01089ab-df05-4208-8a00-279976a68812"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a6ad4d3c-87d8-4f9c-a12a-92e6e70d5b3b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81def3d4-a7c9-4690-9d43-0ed9fec0b3e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""50f1f13a-096d-4147-9f84-84f92b7cc51a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""22a8bb03-cc80-4f93-877a-8216a1cb46af"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Hit = m_Gameplay.FindAction("Hit", throwIfNotFound: true);
        m_Gameplay_Dodge = m_Gameplay.FindAction("Dodge", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_PickUp = m_Gameplay.FindAction("PickUp", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_KHit = m_Gameplay.FindAction("KHit", throwIfNotFound: true);
        m_Gameplay_KDodge = m_Gameplay.FindAction("KDodge", throwIfNotFound: true);
        m_Gameplay_KPickup = m_Gameplay.FindAction("KPickup", throwIfNotFound: true);
        m_Gameplay_WASD = m_Gameplay.FindAction("WASD", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Hit;
    private readonly InputAction m_Gameplay_Dodge;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_PickUp;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_KHit;
    private readonly InputAction m_Gameplay_KDodge;
    private readonly InputAction m_Gameplay_KPickup;
    private readonly InputAction m_Gameplay_WASD;
    private readonly InputAction m_Gameplay_Attack;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Hit => m_Wrapper.m_Gameplay_Hit;
        public InputAction @Dodge => m_Wrapper.m_Gameplay_Dodge;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @PickUp => m_Wrapper.m_Gameplay_PickUp;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @KHit => m_Wrapper.m_Gameplay_KHit;
        public InputAction @KDodge => m_Wrapper.m_Gameplay_KDodge;
        public InputAction @KPickup => m_Wrapper.m_Gameplay_KPickup;
        public InputAction @WASD => m_Wrapper.m_Gameplay_WASD;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Hit.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHit;
                @Hit.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHit;
                @Hit.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHit;
                @Dodge.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDodge;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @PickUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @KHit.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKHit;
                @KHit.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKHit;
                @KHit.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKHit;
                @KDodge.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKDodge;
                @KDodge.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKDodge;
                @KDodge.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKDodge;
                @KPickup.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKPickup;
                @KPickup.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKPickup;
                @KPickup.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKPickup;
                @WASD.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWASD;
                @Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Hit.started += instance.OnHit;
                @Hit.performed += instance.OnHit;
                @Hit.canceled += instance.OnHit;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @KHit.started += instance.OnKHit;
                @KHit.performed += instance.OnKHit;
                @KHit.canceled += instance.OnKHit;
                @KDodge.started += instance.OnKDodge;
                @KDodge.performed += instance.OnKDodge;
                @KDodge.canceled += instance.OnKDodge;
                @KPickup.started += instance.OnKPickup;
                @KPickup.performed += instance.OnKPickup;
                @KPickup.canceled += instance.OnKPickup;
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnHit(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnKHit(InputAction.CallbackContext context);
        void OnKDodge(InputAction.CallbackContext context);
        void OnKPickup(InputAction.CallbackContext context);
        void OnWASD(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
