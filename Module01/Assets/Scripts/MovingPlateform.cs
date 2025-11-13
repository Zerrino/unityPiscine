using UnityEngine;
using UnityEngine.InputSystem;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;
    [SerializeField] float speed = 3f;

    private Vector3 target;

    void Start()
    {
        transform.position = pointA;
        target = pointB;
    }



    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
