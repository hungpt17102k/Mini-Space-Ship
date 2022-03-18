using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    
    public Transform[] spawnPoints;
    public Vector2 spawnSizeMinMax;
    public Vector2 secondBwtSpawnsMinMax;
    float nextSpawnTime;


    void Update()
    {
        if(Time.timeSinceLevelLoad > nextSpawnTime) {
            float secondBtwSpawns = Mathf.Lerp(secondBwtSpawnsMinMax.y, secondBwtSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime += secondBtwSpawns;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            GameObject newObstacle = Instantiate(obstacle, spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
            newObstacle.transform.localScale = Vector2.one * spawnSize;
        }
    }

}
