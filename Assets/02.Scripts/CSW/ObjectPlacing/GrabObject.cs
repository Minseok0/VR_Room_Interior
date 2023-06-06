using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabObject : MonoBehaviour
{
    public GameObject xrRayAttachFurniture;
    public XRRayInteractor rayInteractor;
    
    private void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    private void Update()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit) && rayInteractor.isSelectActive)
        {
            xrRayAttachFurniture.transform.SetPositionAndRotation(raycastHit.transform.position, raycastHit.transform.rotation);
            //Debug.Log("raycastHit.rigidbody.gameObject " + raycastHit.rigidbody.gameObject.name);

        }
    }
}