using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;

    private Vector3 carSpawnPos;
    private Quaternion carSpawnRotation;

    private void Start()
    {
        carSpawnPos = transform.position;
        carSpawnRotation = this.transform.rotation;
        Debug.Log(carSpawnPos);
    }

    public void SpawnCar()
    {
        GameObject spawnedCar = GameObject.Instantiate(car, carSpawnPos, carSpawnRotation);
        Destroy(spawnedCar, 5);
    }

    
}
