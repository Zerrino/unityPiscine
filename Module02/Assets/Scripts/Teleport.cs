using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] Rigidbody next;
    [SerializeField] private float debounceSeconds = 0.2f;
	private static float lastPressedTime = -10f;


	private void OnTriggerEnter(Collider other)
	{
		CharacterController cc = other.GetComponent<CharacterController>();
		if (cc != null && next != null && Time.unscaledTime - lastPressedTime > debounceSeconds)
		{
			lastPressedTime = Time.unscaledTime;
			cc.enabled = false;
			other.transform.position = next.position;
			cc.enabled = true;
		}
	}
}
