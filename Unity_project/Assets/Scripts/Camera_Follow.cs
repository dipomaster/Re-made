using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    [Range(1f,10f)]
    public float smoothSpeed = .125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed/100f);
        transform.position = smoothPosition;

        transform.LookAt(target);
        
    }

}
