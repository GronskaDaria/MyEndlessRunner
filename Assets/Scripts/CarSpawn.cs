using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> cars;

    private List<GameObject> spawnedCars = new List<GameObject>();

    private int carAmount = 8;
    private float carsDistance = 29.7f;
    private float xPozRight = 3f;
    private float xPozLeft = -3f;
    private float lastZPoz = -40f;

    private bool spawnLeft = true; 

    void Start()
    {
        for (int i = 0; i<carAmount; i++)
        {
            SpawnCar();
        }
    }

    void Update()
    {
        RemoveOldCars();
    }

    private void SpawnCar()
    {
        GameObject carPrefab = cars [Random.Range(0, cars.Count)];

        float zPoz = lastZPoz+carsDistance;
        float xPos = spawnLeft ? xPozLeft : xPozRight;

        GameObject car = Instantiate(
            carPrefab,
            new Vector3(xPos, 0.01f, zPoz),
            carPrefab.transform.rotation);

        spawnedCars.Add(car);

        lastZPoz+=carsDistance;

        spawnLeft=!spawnLeft;
    }

    private void RemoveOldCars()
    {
        if (spawnedCars.Count==0)
            return;

        if (spawnedCars [0].transform.position.z<player.transform.position.z-5f)
        {
            Destroy(spawnedCars [0]);
            spawnedCars.RemoveAt(0);

            SpawnCar(); 
        }
    }
}

