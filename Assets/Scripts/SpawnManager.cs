using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    PlotSpawner plotSpawner;
    CarSpawn carSpawner;
    void Start()
    {
        roadSpawner = GetComponent<RoadSpawner>();
        plotSpawner= GetComponent<PlotSpawner>();
        carSpawner = GetComponent<CarSpawn>();
    }

    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        roadSpawner.MoveRoad();
        plotSpawner.SpawnPlot();
        plotSpawner.SpawnPlot();

    }
}
