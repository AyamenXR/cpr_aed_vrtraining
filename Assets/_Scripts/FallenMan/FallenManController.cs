using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenManController : MonoBehaviour
{
    public GameObject fallenMan;
    public GameObject fallenManBody;
    public GameObject fallenManClothes;
    public GameObject rightPadCollider;
    public GameObject leftPadCollider;
    public Vector3 originalPos = new Vector3 (0.19f, 0f, 2.7f);
    public Vector3 originalRotation = new Vector3 (0, 180,0);

    public GameManager gameManager;
    public GameObject cprColliderGO;
    public bool clothesOff;


    private CPRCollider _cprCollider;
    private Animator _fallenManAnimator;
    private AEDController aedController;

    void Start()
    {
        _fallenManAnimator = GetComponentInChildren<Animator>();
        _cprCollider = cprColliderGO.GetComponent<CPRCollider>();
        aedController = GameObject.FindGameObjectWithTag("AEDController").GetComponent<AEDController>();
        //_manOriginalPos = transform.position;
        //_manOriginalRotation = transform.eulerAngles;
    }

    public void Fall()
    {
        StartCoroutine(WaitAndFall());
    }

    private IEnumerator WaitAndFall()
    {
        yield return new WaitForSeconds(2);
        _fallenManAnimator.SetBool("Fall", true);
        yield return new WaitForSeconds(2);
        gameManager.ManFallen();
    }

    public void Lay()
    {
        _fallenManAnimator.SetBool("Laying", true);
        fallenMan.transform.eulerAngles = new Vector3 (0, -90, 0);
    }

    public void Breathing()
    {
        _fallenManAnimator.SetBool("Breathing", true);
    }

    public void ChangeClothesToBody()
    {
        fallenManBody.SetActive(true);
        fallenManClothes.SetActive(false);
        clothesOff = true;
        aedController.ManClothesOff();//Call on AED Controller
    }

    public void ReadyToPad()
    {
        rightPadCollider.SetActive(true);
        leftPadCollider.SetActive(true);
    }

    public void ResetFallenMan()
    {
        this.transform.position = originalPos;
        this.transform.eulerAngles = originalRotation;
        fallenMan.transform.position = originalPos;
        fallenMan.transform.eulerAngles = originalRotation;

        _fallenManAnimator.SetBool("Breathing", false);
        _fallenManAnimator.SetBool("Laying", false);
        _fallenManAnimator.SetBool("Fall", false);
        _fallenManAnimator.Play("Standing");

        fallenManBody.SetActive(false);
        fallenManClothes.SetActive(true);
        clothesOff = false;

        rightPadCollider.SetActive(false);
        leftPadCollider.SetActive(false);
    }

    //CPR Collider
    public void IsOnFirstCPR(bool _isOn)
    {
        _cprCollider.isOnFirstCPR = _isOn;
    }

    public void IsOnSecondCPR(bool _isOn)
    {
        _cprCollider.isOnSecondCPR = _isOn;
    }

    public void ShowCPRIndication()
    {
        _cprCollider.ShowCPRIndication();
    }

    public void StopCPRIndication()
    {
        _cprCollider.StopCPRIndication();
    }

}
