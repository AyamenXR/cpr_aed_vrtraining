using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDPowerButton : MonoBehaviour
{
    private bool _aedPowerButtonPressed;
    private Animator animator;
    private AudioSource _audio;
    private AEDController aedController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        aedController = GameObject.FindGameObjectWithTag("AEDController").GetComponent<AEDController>();
        aedController.onReset.AddListener(ResetButton);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
        if (!_aedPowerButtonPressed)
        {
            if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
            {
                Debug.Log("colliding");
                _aedPowerButtonPressed = true;
                aedController.PowerButtonPressed();
                animator.SetTrigger("Pressed");
                _audio.Play();
            }
        }
    }

    private void ResetButton()
    {
        _aedPowerButtonPressed = false;
    }
}
