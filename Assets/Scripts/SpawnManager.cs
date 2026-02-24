using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    ObstacleSpawn obstacleSpawn;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner= GetComponent<PlotSpawner>();
        obstacleSpawn=GetComponent<ObstacleSpawn>();
    }

    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
        plotSpawner.SpawnPlot();
        obstacleSpawn.SpawnObstacle();

    }
}
