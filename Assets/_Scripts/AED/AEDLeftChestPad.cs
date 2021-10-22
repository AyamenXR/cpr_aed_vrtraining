using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDLeftChestPad : MonoBehaviour
{
    private bool _leftPadded;
    private AudioSource _audio;
    private AEDController aedController;
    private Vector3 _originalPos;

    private void Start()
    {
        _originalPos = this.transform.position;
        _audio = GetComponent<AudioSource>();
        aedController = GameObject.FindGameObjectWithTag("AEDController").GetComponent<AEDController>();

        aedController.onReset.AddListener(ResetPad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_leftPadded)
        {
            if (other.gameObject.CompareTag("LeftPadCollider"))
            {
                aedController.LeftPadded();
                _leftPadded = true;
                _audio.Play();
            }
        }
    }

    private void ResetPad()
    {
        _leftPadded = false;
        transform.position = _originalPos;
        transform.rotation = Quaternion.identity;
    }
}
