using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float cooldown;
    public GameObject toSpawn;

    float time;

    void Update()
    {
        if (canSpawn() && cooldown != 0)
        {
            Spawn();
        }
    }

    private void OnDestroy()
    {
        if(cooldown == 0)
        {
            Spawn();
        }
    }

    bool canSpawn()
    {
        if(time <= 0)
        {
            return true;
        }
        else
        {
            time -= Time.deltaTime;
            return false;
        }
    }

    void Spawn()
    {
        Instantiate(toSpawn, transform.position, Quaternion.identity);
        time = cooldown;
    }
}
