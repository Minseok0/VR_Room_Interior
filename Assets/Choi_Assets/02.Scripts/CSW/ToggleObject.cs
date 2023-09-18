using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject targetObject;
    public bool isObjectActive;

    public void Toggle()
    {
        isObjectActive = !isObjectActive;
        targetObject.SetActive(isObjectActive);
    }
}
