using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject  Ennemy;
    [SerializeField] float  speed = 1f;
    [SerializeField] float  damage = 0.1f;

    Transform target;
    Vector2 lastDirection = Vector2.down;
    Rigidbody2D rb;

    public void Init(GameObject  Ennemy, float damage)
	{
        this.Ennemy = Ennemy;
        this.damage = damage;
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        target = Ennemy.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		GameObject cc = other.gameObject;
        if (!cc)
            return ;
        EnemyController ennemyData = cc.GetComponent<EnemyController>();
        if (!ennemyData)
            return ;
        ennemyData.TakeDamage(damage);
        Destroy(gameObject);
	}


    void FixedUpdate()
	{
        if (target)
        {
            Vector2 dir = (target.position - transform.position);
            float dist = dir.magnitude;
            if (dist > 0.001f)
            {
                lastDirection = dir.normalized;
                Vector2 targetPos = (Vector2)transform.position + lastDirection * speed * Time.fixedDeltaTime;
                rb.MovePosition(targetPos);
            }
        }
        else
        {
            Vector2 targetPos = (Vector2)transform.position + lastDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(targetPos);
        }
	}

    void Update()
    {

    }
}
