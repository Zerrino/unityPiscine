using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float EnnemyHealth = 1f;


    private Rigidbody2D rb;

    public void TakeDamage(float attack)
	{
		EnnemyHealth -= attack;
	}

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		GameObject cc = other.gameObject;
        if (!cc)
            return ;
        BaseScript baseData = cc.GetComponent<BaseScript>();
        if (!baseData)
            return ;
		baseData.TakeDamage(1);
        print(baseData.GetHP());
        Destroy(gameObject);
	}

    void Update()
	{
		if (EnnemyHealth <= 0)
		{
			Destroy(gameObject);
		}
	}
    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.down * moveSpeed;
    }
}
