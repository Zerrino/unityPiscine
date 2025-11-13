using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] CharacterController Owner;
    [SerializeField] GameObject visualSelf;
    Renderer visualRenderer;
    Collider doorCollider;


    void Start()
    {
        visualRenderer = visualSelf.GetComponent<Renderer>();
        doorCollider = visualSelf.GetComponent<Collider>();
    }

    public void OpenDoor(CharacterController other)
    {
        if (!Owner || other == Owner)
        {
            if (visualRenderer != null)
                visualRenderer.enabled = false;

            if (doorCollider != null)
                doorCollider.enabled = false;
        }
    }

    public void CloseDoor(CharacterController other)
    {
        if (!Owner || other == Owner)
        {
            if (visualRenderer != null)
                visualRenderer.enabled = true;

            if (doorCollider != null)
                doorCollider.enabled = true;
        }
    }

    public CharacterController GetOwner()
    {
        return Owner;
    }

    void Update()
    {

    }
}
