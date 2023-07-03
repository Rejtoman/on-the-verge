using UnityEngine;

public class CameraLag : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float lagSpeedX = 5f; // The speed at which the camera should lag behind the target on the X-axis
    public float lagSpeedY = 2f; // The speed at which the camera should lag behind the target on the Y-axis
    public float lagSpeedZ = 5f; // The speed at which the camera should lag behind the target on the Z-axis
    public Vector3 offset = Vector3.back; // The offset between the camera and the target

    private Vector3 desiredPosition;

    void LateUpdate()
    {
        // Check if a target has been assigned
        if (target != null)
        {
            // Calculate the desired camera position with lag
            desiredPosition = target.position + offset;
            Vector3 currentPosition = transform.position;
            Vector3 smoothedPosition = new Vector3(
                Mathf.Lerp(currentPosition.x, desiredPosition.x, Time.deltaTime * lagSpeedX),
                Mathf.Lerp(currentPosition.y, desiredPosition.y, Time.deltaTime * lagSpeedY),
                Mathf.Lerp(currentPosition.z, desiredPosition.z, Time.deltaTime * lagSpeedZ)
            );

            // Move the camera to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
