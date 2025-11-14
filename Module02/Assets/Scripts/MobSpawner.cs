using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] GameObject MobToSpawn;
    [SerializeField] BaseScript baseData;
    [SerializeField] float spawnRate = 1f;


    bool flag = true;
    float spawnRateDelta;

    private List<GameObject> spawned = new List<GameObject>();

    public float GetSpawnRate()
	{
        return spawnRate;
	}

    public void SpawnBlop()
    {
        GameObject go = Instantiate(MobToSpawn, transform.position, transform.rotation);
        spawned.Add(go);
    }

    public void DestroyAllBlops()
    {
        for (int i = spawned.Count - 1; i >= 0; i--)
        {
            if (spawned[i] != null)
                Destroy(spawned[i]);
            spawned.RemoveAt(i);
        }
    }

    public void Unregister(GameObject go)
    {
        spawned.Remove(go);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (baseData && baseData.GetHP() > 0)
        {
            spawnRateDelta -= Time.deltaTime;
            if (spawnRateDelta <= 0)
            {
                SpawnBlop();
                spawnRateDelta = spawnRate;
            }
        }
        else if (flag)
		{

            DestroyAllBlops();
            flag = false;
		}
    }
}
