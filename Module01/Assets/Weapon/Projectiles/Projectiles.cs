using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class Projectiles : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] CharacterController who;
    private GameOver finish;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-(projectileSpeed * Time.deltaTime), 0f, 0f));
    }
    void OnTriggerEnter(Collider other)
    {
        CharacterController cc = other.GetComponent<CharacterController>();
        if (cc)
        {
            if (who == cc)
            {
                #if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }
        }
        Destroy(gameObject);
    }
}
