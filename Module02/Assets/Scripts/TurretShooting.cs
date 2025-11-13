using UnityEngine;
using UnityEngine.InputSystem;

public class TurretShooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Gun currentGun;
    private float fireRate;
    private float fireRateDelta;

    void Start()
    {
        currentGun = GetComponentInChildren<Gun>();
        fireRate = currentGun.GetRateOfFire();
    }

    // Update is called once per frame
    void Update()
    {
        fireRateDelta -= Time.deltaTime;
        if (fireRateDelta <= 0)
        {
            currentGun.Fire();
            fireRateDelta = fireRate;
        }
    }
}
