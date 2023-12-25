using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Tham chiếu đến transform của player
    public Vector3 offset; // Độ lệch giữa camera và player

    void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f); // Lerp để làm mượt di chuyển của camera
            transform.position = smoothedPosition;
        }
    }
}
