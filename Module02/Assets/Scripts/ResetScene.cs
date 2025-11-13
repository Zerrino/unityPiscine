using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetSceneOnKey : MonoBehaviour
{
    [SerializeField] private Key resetKey = Key.R;
    [SerializeField] private float debounceSeconds = 0.2f;
    private float lastPressedTime = -10f;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current[resetKey].wasPressedThisFrame && Time.unscaledTime - lastPressedTime > debounceSeconds)
        {
            lastPressedTime = Time.unscaledTime;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
