using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject bullets;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float damage = 0.5f;
    private EnemyController ennemy;
    private GameObject target;
    private float fireRateDelta;


    void Start()
    {
    }

    void    Fire(EnemyController ennemyToGet)
	{
        if (!ennemyToGet)
            return ;
        GameObject bullet = Instantiate(bullets, transform.position, transform.rotation);
        Bullet selfB = bullet.GetComponent<Bullet>();
        selfB.Init(ennemyToGet.gameObject, damage);
	}

    void OnTriggerEnter2D(Collider2D other)
	{
		target = other.gameObject;
        if (!target)
            return ;
        ennemy = target.GetComponent<EnemyController>();
        if (!ennemy)
            return ;
	}

    void OnTriggerStay2D(Collider2D other)
	{
		target = other.gameObject;
        if (!target)
            return ;
        ennemy = target.GetComponent<EnemyController>();
        if (!ennemy)
            return ;
	}

    void OnTriggerExit2D(Collider2D other)
	{
		GameObject cc = other.gameObject;
        if (!cc)
            return ;
        if (ennemy == cc.GetComponent<EnemyController>())
        {
            ennemy = null;
        }

	}


    // Update is called once per frame
    void Update()
	{
        fireRateDelta -= Time.deltaTime;
        if (fireRateDelta <= 0)
        {
            if (!ennemy)
                return ;
            Fire(ennemy);
            fireRateDelta = fireRate;
        }
	}
}
