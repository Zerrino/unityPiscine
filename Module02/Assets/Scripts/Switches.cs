using UnityEngine;
using UnityEngine.InputSystem;

public class Switches : MonoBehaviour
{
    [SerializeField] DoorScript Door;
    [SerializeField] GameObject Plateform;
    [SerializeField] CharacterController Who;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        CharacterController cc = other.GetComponent<CharacterController>();
        if (!cc)
            return;
        if (!Who)
        {
            Renderer src = cc.GetComponent<Renderer>();
            Renderer dst = this.GetComponent<Renderer>();
            if (src && dst && src.sharedMaterial)
            {
                dst.sharedMaterial = src.sharedMaterial;
            }
        }
        if (Door)
        {
            Door.OpenDoor(cc);
        }
        else if (Plateform && cc)
		{
            CopyLayerTo(Plateform, cc);
		}
    }

    void OnTriggerExit(Collider other)
    {
        CharacterController cc = other.GetComponent<CharacterController>();
        if (!cc)
            return ;
        if (Door)
        {
            Door.CloseDoor(cc);
        }
    }

    void CopyLayerTo(GameObject target, CharacterController controller)
    {
        if (target == null || controller == null)
            return;

        target.layer = controller.gameObject.layer - 1;
        Renderer src = controller.GetComponent<Renderer>();
        Renderer dst = target.GetComponent<Renderer>();

        if (src && dst && src.sharedMaterial)
        {
            dst.sharedMaterial = src.sharedMaterial;
        }
    }

    void OnTriggerExit()
	{

	}
}
