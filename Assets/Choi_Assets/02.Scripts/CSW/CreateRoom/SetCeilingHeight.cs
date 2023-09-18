using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetCeilingHeight : MonoBehaviour
{
    public Slider slider;
    public GameObject button_CreateRoom;
    public TMP_Text textMeshPro;
    private Button_CompleteCreatingRoom button_CompleteCreatingRoom;


    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        button_CompleteCreatingRoom = button_CreateRoom.GetComponent<Button_CompleteCreatingRoom>();

        textMeshPro.text = "Wall Height : " + button_CompleteCreatingRoom.wallHeight;
    }

    private void OnSliderValueChanged(float value)
    {
        value = Mathf.Round(value * 10f) / 10f;
        button_CompleteCreatingRoom.wallHeight = value;
        textMeshPro.text = "Wall Height : " + value;
        /*Vector3 ceilingPosition = ceiling.position;
        ceilingPosition.y = height;
        ceiling.position = ceilingPosition;*/
    }
}