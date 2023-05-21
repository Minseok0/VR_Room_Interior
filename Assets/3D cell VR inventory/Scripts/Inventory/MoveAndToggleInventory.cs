using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndToggleInventory : MonoBehaviour
{
    public Transform playerCamera;
    public float distanceFromPlayer = 2f;
    public float xOffset = -0.5f; // �κ��丮�� �������κ����� X ������
    public KeyCode toggleKey = KeyCode.I;

    private bool isInventoryActive = true;

    private void Update()
    {
        // �÷��̾��� �ü��� �����Ͽ� �κ��丮 ��ġ�� ������Ʈ�մϴ�.
        Vector3 targetPosition = playerCamera.position + playerCamera.forward * distanceFromPlayer;
        targetPosition += playerCamera.right * xOffset; // ���������� ������ ����
        transform.position = targetPosition;
        transform.rotation = Quaternion.LookRotation(playerCamera.forward, Vector3.up);

        // Ű �Է��� �����Ͽ� �κ��丮�� Ȱ��ȭ/��Ȱ��ȭ�մϴ�.
        if (UnityEngine.Input.GetKeyDown(toggleKey))
        {
            isInventoryActive = !isInventoryActive;
            gameObject.SetActive(isInventoryActive);
        }
    }
}
