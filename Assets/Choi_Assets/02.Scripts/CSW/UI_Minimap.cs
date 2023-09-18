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
    private float zoomMin = 1; // 카메라의 ortho 최소 크기
    [SerializeField]
    private float zoomMax = 30; // 카메라의 ortho 최대 크기
    [SerializeField]
    private float zoomOneStep = 1;
    //[SerializeField]
    //private TextMeshProUGUI textMapName;

    private void Awake()
    {
        //textMapName.text = SceneManager.GetActiveScene().name;
    }

    public void ZoomIn()
    {
        minimapCamera.orthographicSize = Mathf.Max(minimapCamera.orthographicSize - zoomOneStep, zoomMin );
    }

    public void ZoomOut()
    {
        minimapCamera.orthographicSize = Mathf.Min(minimapCamera.orthographicSize + zoomOneStep, zoomMax);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
