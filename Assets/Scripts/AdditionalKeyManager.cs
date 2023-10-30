using UnityEngine;
using UnityEngine.InputSystem;

public class AdditionalKeyManager : MonoBehaviour
{
    [SerializeField] private InputAction leftPrimaryButtonAction;
    [SerializeField] private GameObject leftTarget;
    [Space(10)]
    [SerializeField] private InputAction rightPrimaryButtonAction;
    [SerializeField] private GameObject rightTarget;

    private void Awake()
    {
        leftPrimaryButtonAction.Enable();
        rightPrimaryButtonAction.Enable();
    }

    private void OnEnable()
    {
        leftPrimaryButtonAction.performed += OnLeftPrimaryButtonPerformed;
        rightPrimaryButtonAction.performed += OnRightPrimaryButtonPerformed;
        //leftPrimaryButtonAction.canceled += OnPrimaryButtonRelease;
    }

    private void OnDisable()
    {
        //leftPrimaryButtonAction.performed -= OnLeftPrimaryButtonPerformed;
        //rightPrimaryButtonAction.performed -= OnRightPrimaryButtonPerformed;
        //leftPrimaryButtonAction.canceled -= OnPrimaryButtonRelease;
    }

    public void OnLeftPrimaryButtonPerformed(InputAction.CallbackContext context)
    {
        Managers.UI.ToggleOptionMenu();
        //Managers.UI.ToggleOptionMenu();
    }

    /*private void OnPrimaryButtonRelease(InputAction.CallbackContext context)
    {
    }*/
    public void OnRightPrimaryButtonPerformed(InputAction.CallbackContext context)
    {
        if(rightTarget != null)
            rightTarget.SetActive(!rightTarget.activeSelf);
    }
}
