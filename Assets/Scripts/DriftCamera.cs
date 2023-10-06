using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriftCamera : MonoBehaviour
{
    [Serializable]
    public class AdvancedOptions
    {
        public bool updateCameraInUpdate;
        public bool updateCameraInFixedUpdate = true;
        public bool updateCameraInLateUpdate;
    }

    public float smoothing = 6f;
    public Transform lookAtTarget;
    public Transform positionTarget;
    public Transform sideView;
    public AdvancedOptions advancedOptions;
    public InputActionAsset primaryActions;
    InputActionMap inputActionMap;
    InputAction changeCameraAction;
    private void Awake()
    {
        inputActionMap = primaryActions.FindActionMap("Camera");
        changeCameraAction = inputActionMap.FindAction("Change");
        changeCameraAction.performed += ctx => m_ShowingSideView = !m_ShowingSideView;
    }

    private void OnEnable()
    {
        primaryActions.Enable();
        inputActionMap.Enable();
        changeCameraAction.Enable();
    }

    private void OnDisable()
    {
        primaryActions.Disable();
        inputActionMap.Disable();
        changeCameraAction.Disable();
    }

    bool m_ShowingSideView;

    private void FixedUpdate()
    {
        if (advancedOptions.updateCameraInFixedUpdate)
            UpdateCamera();
    }

    private void Update()
    {
        if (advancedOptions.updateCameraInUpdate)
            UpdateCamera();
    }

    private void LateUpdate()
    {
        if (advancedOptions.updateCameraInLateUpdate)
            UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (m_ShowingSideView)
        {
            transform.position = sideView.position;
            transform.rotation = sideView.rotation;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, positionTarget.position, Time.deltaTime * smoothing);
            transform.LookAt(lookAtTarget);
        }
    }
}
