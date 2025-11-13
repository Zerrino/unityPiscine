using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOffFire = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float GetRateOfFire()
	{
        return rateOffFire;
	}

    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
