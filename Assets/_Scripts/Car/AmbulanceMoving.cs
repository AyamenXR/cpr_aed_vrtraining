using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMoving : MonoBehaviour
{
    public GameObject ambulance;

    private Transform carSpawnPos;
    private Animator _animator;
    private AudioSource _audioSource;
    private GameObject _spawnedAmbulance;

    private void Start()
    {
        carSpawnPos = this.transform;
    }

    public void SpawnAmbulance()
    {
 
        GameObject spawnedAmbulance = GameObject.Instantiate(ambulance, carSpawnPos.position, carSpawnPos.rotation);

        _spawnedAmbulance = spawnedAmbulance;
        _animator = _spawnedAmbulance.GetComponent<Animator>();
        _audioSource = _spawnedAmbulance.GetComponent<AudioSource>();
        //_animator.SetBool("Ambulance", true);
        _audioSource.Play();
        
    }

    public void ResetAmbulance()
    {
        //_animator.SetBool("Ambulance", false);
        Destroy(_spawnedAmbulance);
    }
}
