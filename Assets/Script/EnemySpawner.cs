using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float Timer = 0f;
    float TimerDiff = 1f;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > TimerDiff)
        {
            Instantiate(enemy);
            enemy.transform.position = new Vector3(Random.Range(-1.9f, 1.9f), 10f, 0);
            Timer = 0;
        }
    }
}
