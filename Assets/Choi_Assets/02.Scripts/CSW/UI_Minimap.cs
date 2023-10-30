using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Minimap : MonoBehaviour
{
    [SerializeField]
    private Camera minimapCamera;
    [SerializeField]
    private float zoomMin = 1; // ī�޶��� ortho �ּ� ũ��
    [SerializeField]
    private float zoomMax = 30; // ī�޶��� ortho �ִ� ũ��
    [SerializeField]
    private float zoomOneStep = 1;
    //[SerializeField]
    //private TextMeshProUGUI textMapName;

    private void Awake()
    {
        if (minimapCamera == null)
            minimapCamera = GameObject.Find("Minimap Camera").GetComponent<Camera>();
    }

    public void ZoomIn()
    {
        print("zoom in");
        minimapCamera.orthographicSize = Mathf.Max(minimapCamera.orthographicSize - zoomOneStep, zoomMin );
        print(minimapCamera.orthographicSize);
    }

    public void ZoomOut()
    {
        print("zoom out");
        minimapCamera.orthographicSize = Mathf.Min(minimapCamera.orthographicSize + zoomOneStep, zoomMax);
        print(minimapCamera.orthographicSize);
    }
}
