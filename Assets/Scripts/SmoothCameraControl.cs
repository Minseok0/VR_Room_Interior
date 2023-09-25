using UnityEngine;

public class SmoothCameraControl : MonoBehaviour
{
    [Range(0, 1)] public float PositionDamping;
    [Range(0, 1)] public float RotationDamping;

    public Transform Target;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        transform.position = Target.position;
        transform.rotation = Target.rotation;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref velocity, PositionDamping);
        transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, RotationDamping);
    }
}