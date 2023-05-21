using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndToggleInventory : MonoBehaviour
{
    public Transform playerCamera;
    public float distanceFromPlayer = 2f;
    public float xOffset = -0.5f; // 인벤토리의 왼쪽으로부터의 X 오프셋
    public KeyCode toggleKey = KeyCode.I;

    private bool isInventoryActive = true;

    private void Update()
    {
        // 플레이어의 시선을 추적하여 인벤토리 위치를 업데이트합니다.
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * distanceFromPlayer;
        targetPosition += playerCamera.right * xOffset; // 왼쪽으로의 오프셋 적용
        transform.position = targetPosition;
        transform.rotation = Quaternion.LookRotation(playerCamera.forward, Vector3.up);

        // 키 입력을 감지하여 인벤토리를 활성화/비활성화합니다.
        if (UnityEngine.Input.GetKeyDown(toggleKey))
        {
            isInventoryActive = !isInventoryActive;
            gameObject.SetActive(isInventoryActive);
        }
    }
}
