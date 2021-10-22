using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEDShockButton : MonoBehaviour
{
    public bool aedShockButtonPressed;

    private Animator animator;
    private AudioSource _audio;

    private  AEDController aedController;

    private void Start()
    {
        //AEDController aedController = new AEDController();

        animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        aedController = GameObject.FindGameObjectWithTag("AEDController").GetComponent<AEDController>();

        aedController.onShocked.AddListener(ShockButtonReset);
    }

    //private void Update()
    //{
    //    //aedShockButtonPressed = aedController.GetComponent<AEDController>().aedShockButtonPressed;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!aedShockButtonPressed)
        {
            if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
            {
                aedController.OnShockButtonPressed();
                //aedShockButtonPressed = true;
                animator.SetTrigger("Pressed");
                _audio.Play();
            }
        }
    }

    public void ShockButtonReset()//AEDControllerからのコールバック
    {
        aedShockButtonPressed = false;
        Debug.Log("Shock button reset");
    }
}
