using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// ���� ��ġ�� xr ray�� �ٿ��� ��ũ��Ʈ ������Ʈ
/// Grab ���� XR Ray�� Layer Mask�� �����������(FURNITURE��.)
/// </summary>
public class GrabObject : MonoBehaviour
{
    public GameObject attachTransform; // attach transform of XR ray.
    public XRRayInteractor rayInteractor;
    
    [SerializeField]
    private RaycastHit raycastHit;
    private bool isGrabbing;

    private void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        isGrabbing = false;
        raycastHit = default;
    }

    private void Update()
    {
        if (isGrabbing)
            UpdateGrabbedPosition();
    }

    public void GrabFurniture()
    {
        if(rayInteractor.TryGetCurrent3DRaycastHit(out raycastHit)) //&& raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("FURNITURE")
            isGrabbing = true;
    }
    
    public void UnGrabFurniture()
    {
        raycastHit = default;
        isGrabbing = false;
    }

    private void UpdateGrabbedPosition()
    {
        //rayInteractor.TryGetCurrent3DRaycastHit(out raycastHit); ����
        // Why, XRRayInteractor �� OnSelectEntering �޼ҵ忡�� 
        // if (!m_UseForceGrab && interactablesSelected.Count == 1 && TryGetCurrent3DRaycastHit(out var raycastHit))
        // attachTransform.position = raycastHit.point;
        // �� ���ֱ⿡.

        //attachTransform.transform.SetPositionAndRotation(raycastHit.transform.position, raycastHit.transform.rotation);
    }
}