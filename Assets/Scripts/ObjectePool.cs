using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectePool : MonoBehaviour
{
  [SerializeField] private GameObject obstaclePrefab;
   private GameObject[] obstacles;
  [SerializeField] private int poolSize = 5;
  [SerializeField] private float spawnTime= 2.5f;
  [SerializeField] private  float xSpawnPosition = 12;
  [SerializeField] private float minYPosition = -2f;
  [SerializeField] private float maxYPosition = 3f;

  private float timeElasep;
  private int obstacleCount;
    void Start()
    {
        obstacles = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(obstaclePrefab);
            obstacles[i].SetActive(false);
        }
    }

   
    void Update()
    {
        timeElasep += Time.deltaTime;
        if(timeElasep >spawnTime && !GameManager.Instance.isGameOver)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        timeElasep = 0f;
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;
       
        if(!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);
        }

        
        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }

}
