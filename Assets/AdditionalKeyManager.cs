using UnityEngine;
using UnityEngine.InputSystem;

public class AdditionalKeyManager : MonoBehaviour
{
    [SerializeField] private InputAction leftPrimaryButtonAction;
    [SerializeField] private InputAction rightPrimaryButtonAction;

    private void Awake()
    {
        leftPrimaryButtonAction.Enable();
    }

    private void OnEnable()
    {
        leftPrimaryButtonAction.performed += OnLeftPrimaryButtonPerformed;
        //leftPrimaryButtonAction.canceled += OnPrimaryButtonRelease;
    }

    private void OnDisable()
    {
        leftPrimaryButtonAction.performed -= OnLeftPrimaryButtonPerformed;
        //leftPrimaryButtonAction.canceled -= OnPrimaryButtonRelease;
    }

    public void OnLeftPrimaryButtonPerformed(InputAction.CallbackContext context)
    {
        Managers.UI.ToggleOptionMenu();
    }

    /*private void OnPrimaryButtonRelease(InputAction.CallbackContext context)
    {
    }*/

}
