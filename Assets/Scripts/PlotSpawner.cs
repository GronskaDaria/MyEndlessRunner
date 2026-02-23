using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> plots;

    private List<GameObject> spawnedPlots = new List<GameObject>();

    private int initAmount = 6;
    private float plotSize = 40f;
    private float xPozRight = 40f;
    private float xPozLeft = -40f;
    private float lastZPoz = -70f;

    void Start()
    {
        for (int i = 0; i<initAmount; i++)
        {
            SpawnPlot();
        }
    }

    void Update()
    {
        
    }

    public void SpawnPlot()
    {
        GameObject plotLeft = plots [Random.Range(0, plots.Count)];
        GameObject plotRight = plots [Random.Range(0, plots.Count)];

        float zPoz = lastZPoz+plotSize;

        GameObject left = Instantiate(plotLeft,
            new Vector3(xPozLeft, 0.01f, zPoz),
            plotLeft.transform.rotation);

        GameObject right = Instantiate(plotRight,
            new Vector3(xPozRight, 0.01f, zPoz),
            Quaternion.Euler(0, 180, 0));

        spawnedPlots.Add(left);
        spawnedPlots.Add(right);

        lastZPoz+=plotSize;
        RemoveOldPlots();
    }

    private void RemoveOldPlots()
    {
        if (spawnedPlots.Count==0)
            return;

        if (spawnedPlots [0].transform.position.z<player.transform.position.z)
        {
            Destroy(spawnedPlots [0]);
            Destroy(spawnedPlots [1]);

            spawnedPlots.RemoveAt(0);
            spawnedPlots.RemoveAt(0);
        }
    }
}