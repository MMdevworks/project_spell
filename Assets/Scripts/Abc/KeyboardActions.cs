//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.1
//     from Assets/KeyboardActions.inputactions
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

public partial class @KeyboardActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyboardActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardActions"",
    ""maps"": [
        {
            ""name"": ""AlphabetActions"",
            ""id"": ""571ca218-2c3c-4650-8bcf-6f442168b75b"",
            ""actions"": [
                {
                    ""name"": ""DestroyLetter"",
                    ""type"": ""Button"",
                    ""id"": ""c324efd2-4f0b-4525-97aa-626e31310c52"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3e51f57e-8809-4d24-8307-3c910905d160"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DestroyLetter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AlphabetActions
        m_AlphabetActions = asset.FindActionMap("AlphabetActions", throwIfNotFound: true);
        m_AlphabetActions_DestroyLetter = m_AlphabetActions.FindAction("DestroyLetter", throwIfNotFound: true);
    }

    ~@KeyboardActions()
    {
        UnityEngine.Debug.Assert(!m_AlphabetActions.enabled, "This will cause a leak and performance issues, KeyboardActions.AlphabetActions.Disable() has not been called.");
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

    // AlphabetActions
    private readonly InputActionMap m_AlphabetActions;
    private List<IAlphabetActionsActions> m_AlphabetActionsActionsCallbackInterfaces = new List<IAlphabetActionsActions>();
    private readonly InputAction m_AlphabetActions_DestroyLetter;
    public struct AlphabetActionsActions
    {
        private @KeyboardActions m_Wrapper;
        public AlphabetActionsActions(@KeyboardActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @DestroyLetter => m_Wrapper.m_AlphabetActions_DestroyLetter;
        public InputActionMap Get() { return m_Wrapper.m_AlphabetActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AlphabetActionsActions set) { return set.Get(); }
        public void AddCallbacks(IAlphabetActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_AlphabetActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AlphabetActionsActionsCallbackInterfaces.Add(instance);
            @DestroyLetter.started += instance.OnDestroyLetter;
            @DestroyLetter.performed += instance.OnDestroyLetter;
            @DestroyLetter.canceled += instance.OnDestroyLetter;
        }

        private void UnregisterCallbacks(IAlphabetActionsActions instance)
        {
            @DestroyLetter.started -= instance.OnDestroyLetter;
            @DestroyLetter.performed -= instance.OnDestroyLetter;
            @DestroyLetter.canceled -= instance.OnDestroyLetter;
        }

        public void RemoveCallbacks(IAlphabetActionsActions instance)
        {
            if (m_Wrapper.m_AlphabetActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAlphabetActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_AlphabetActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AlphabetActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AlphabetActionsActions @AlphabetActions => new AlphabetActionsActions(this);
    public interface IAlphabetActionsActions
    {
        void OnDestroyLetter(InputAction.CallbackContext context);
    }
}