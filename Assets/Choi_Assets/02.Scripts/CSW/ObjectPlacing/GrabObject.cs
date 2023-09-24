using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 가구 배치할 xr ray에 붙여줄 스크립트 컴포넌트
/// Grab 전용 XR Ray는 Layer Mask를 설정해줘야함(FURNITURE로.)
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
        //rayInteractor.TryGetCurrent3DRaycastHit(out raycastHit); 안함
        // Why, XRRayInteractor 의 OnSelectEntering 메소드에서 
        // if (!m_UseForceGrab && interactablesSelected.Count == 1 && TryGetCurrent3DRaycastHit(out var raycastHit))
        // attachTransform.position = raycastHit.point;
        // 를 해주기에.

        //attachTransform.transform.SetPositionAndRotation(raycastHit.transform.position, raycastHit.transform.rotation);
    }
}