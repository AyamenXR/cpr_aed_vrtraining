using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDRightChestPad : MonoBehaviour
{
    private bool _rightPadded;
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
        if (!_rightPadded)
        {
            if (other.gameObject.CompareTag("RightPadCollider"))
            {
                aedController.RightPadded();
                _rightPadded = true;
                _audio.Play();
            }
        }
    }

    private void ResetPad()
    {
        _rightPadded = false;
        transform.position = _originalPos;
        transform.rotation = Quaternion.identity;
    }
}
