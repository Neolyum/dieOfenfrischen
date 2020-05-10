// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/FlightControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FlightControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FlightControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FlightControls"",
    ""maps"": [
        {
            ""name"": ""Flight"",
            ""id"": ""84cf4f97-42ab-43ff-889c-95a6141e1db0"",
            ""actions"": [
                {
                    ""name"": ""PitchYaw"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2de2de11-972e-4d9d-8c80-102bbb6a0016"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""312591f2-8a58-479d-8cd3-05aad88eaf72"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Speed"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bda0d5e6-5768-43a8-a153-88bd3cbb206a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""11f82adc-6415-40b4-9134-e09a873c6081"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3ca552af-42c0-49ed-aa08-710faaacc7e3"",
                    ""path"": ""*/{Primary2DMotion}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PitchYaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1a612117-d102-4c92-9f7e-23eecc69bfa0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d9c4ef6f-ed56-41de-afb6-6c6ef2a4b8e0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cdfd23b9-d7da-4b80-88b1-e2fd77e2ae92"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9701b96d-691d-4694-bfbb-f9acc2a55136"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bb8215fd-d88b-4743-b587-2c3d24c2aacf"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b88b39dc-1b20-4c51-ab0f-98d61277ab67"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f1b2686d-1a6e-46a0-8f12-c9508de439c9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Turret"",
            ""id"": ""f7dfbde8-17ec-4429-9d77-23e1b7c4627f"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""0e809dc2-c174-4ab8-ac3d-8a97dab636b9"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""83f70c7b-a650-4750-a6a4-8d2f2902458a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1653dc8f-760e-46bd-9495-8e4e44190795"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad;KM"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d3d4130-844d-428e-8e79-f51e72abf9ec"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
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
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Flight
        m_Flight = asset.FindActionMap("Flight", throwIfNotFound: true);
        m_Flight_PitchYaw = m_Flight.FindAction("PitchYaw", throwIfNotFound: true);
        m_Flight_Roll = m_Flight.FindAction("Roll", throwIfNotFound: true);
        m_Flight_Speed = m_Flight.FindAction("Speed", throwIfNotFound: true);
        m_Flight_Camera = m_Flight.FindAction("Camera", throwIfNotFound: true);
        // Turret
        m_Turret = asset.FindActionMap("Turret", throwIfNotFound: true);
        m_Turret_Aim = m_Turret.FindAction("Aim", throwIfNotFound: true);
        m_Turret_Shoot = m_Turret.FindAction("Shoot", throwIfNotFound: true);
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

    // Flight
    private readonly InputActionMap m_Flight;
    private IFlightActions m_FlightActionsCallbackInterface;
    private readonly InputAction m_Flight_PitchYaw;
    private readonly InputAction m_Flight_Roll;
    private readonly InputAction m_Flight_Speed;
    private readonly InputAction m_Flight_Camera;
    public struct FlightActions
    {
        private @FlightControls m_Wrapper;
        public FlightActions(@FlightControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PitchYaw => m_Wrapper.m_Flight_PitchYaw;
        public InputAction @Roll => m_Wrapper.m_Flight_Roll;
        public InputAction @Speed => m_Wrapper.m_Flight_Speed;
        public InputAction @Camera => m_Wrapper.m_Flight_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Flight; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FlightActions set) { return set.Get(); }
        public void SetCallbacks(IFlightActions instance)
        {
            if (m_Wrapper.m_FlightActionsCallbackInterface != null)
            {
                @PitchYaw.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnPitchYaw;
                @PitchYaw.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnPitchYaw;
                @PitchYaw.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnPitchYaw;
                @Roll.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnRoll;
                @Speed.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnSpeed;
                @Speed.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnSpeed;
                @Speed.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnSpeed;
                @Camera.started -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_FlightActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_FlightActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PitchYaw.started += instance.OnPitchYaw;
                @PitchYaw.performed += instance.OnPitchYaw;
                @PitchYaw.canceled += instance.OnPitchYaw;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Speed.started += instance.OnSpeed;
                @Speed.performed += instance.OnSpeed;
                @Speed.canceled += instance.OnSpeed;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public FlightActions @Flight => new FlightActions(this);

    // Turret
    private readonly InputActionMap m_Turret;
    private ITurretActions m_TurretActionsCallbackInterface;
    private readonly InputAction m_Turret_Aim;
    private readonly InputAction m_Turret_Shoot;
    public struct TurretActions
    {
        private @FlightControls m_Wrapper;
        public TurretActions(@FlightControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Turret_Aim;
        public InputAction @Shoot => m_Wrapper.m_Turret_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Turret; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TurretActions set) { return set.Get(); }
        public void SetCallbacks(ITurretActions instance)
        {
            if (m_Wrapper.m_TurretActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_TurretActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_TurretActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_TurretActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_TurretActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_TurretActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_TurretActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_TurretActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public TurretActions @Turret => new TurretActions(this);
    private int m_KMSchemeIndex = -1;
    public InputControlScheme KMScheme
    {
        get
        {
            if (m_KMSchemeIndex == -1) m_KMSchemeIndex = asset.FindControlSchemeIndex("KM");
            return asset.controlSchemes[m_KMSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IFlightActions
    {
        void OnPitchYaw(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnSpeed(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface ITurretActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
