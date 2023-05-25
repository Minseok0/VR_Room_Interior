using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.OpenXR.Input;

public class Colorpicker : MonoBehaviour
{
    public TextMeshProUGUI DebugText;

    RectTransform Rect;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 delta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, hit.point, null, out delta);

        string debug = "RayHitPosition = " + hit.point;
        debug += "<br>delta = " + delta;

        DebugText.text = debug;
    }
}
