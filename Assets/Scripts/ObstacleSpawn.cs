using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> obstacles;

    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private int obstacleAmount = 15;
    private float obstacleDistance = 12.3f;
    private float xPozRight = 3.5f;
    private float xPozCenter = 0f;
    private float xPozLeft = -3.5f;
    private float lastZPoz = -50f;

    private bool spawnLeft = true;

    void Start()
    {
        for (int i = 0; i<obstacleAmount; i++)
        {
            SpawnObstacle();
        }
    }

    void Update()
    {
        RemoveOldObstacle();
    }

    public void SpawnObstacle()
    {
        GameObject carPrefab = obstacles [Random.Range(0, obstacles.Count)];

        float zPoz = lastZPoz+obstacleDistance;
        int lane = Random.Range(0, 3);

        float xPos = xPozCenter;

        if (lane==0)
            xPos=xPozLeft;
        if (lane==1)
            xPos=xPozCenter;
        if (lane==2)
            xPos=xPozRight;


        GameObject car = Instantiate(
            carPrefab,
            new Vector3(xPos, 0.01f, zPoz),
            carPrefab.transform.rotation);

        spawnedObstacles.Add(car);

        lastZPoz+=obstacleDistance;

        spawnLeft=!spawnLeft;
    }

    private void RemoveOldObstacle()
    {
        if (spawnedObstacles.Count==0)
            return;

        if (spawnedObstacles [0].transform.position.z<player.transform.position.z-5f)
        {
            Destroy(spawnedObstacles [0]);
            spawnedObstacles.RemoveAt(0);

            SpawnObstacle();
        }
    }
}
