using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cam;
    private Transform player;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float smoothTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (cam == null ||  Player_movements.who == null) return;
        player = Player_movements.who.transform;
        Vector3 targetPos = player.position + offset;
        cam.position = Vector3.SmoothDamp(cam.position, targetPos, ref velocity, smoothTime);
    }
}


