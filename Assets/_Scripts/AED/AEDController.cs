using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AEDController : MonoBehaviour
{
    public GameObject box;
    public GameObject powerButton;
    public GameObject shockButton;
    public GameObject rightPad;
    public GameObject leftPad;
    public GameObject screenText;
    public GameManager gameManager;
    public GameObject fallenMan;

    public bool isClothesOff;
    public bool aedPowerButtonPressed;
    //public bool aedShockButtonPressed;
    public bool rightPadded;
    public bool leftPadded;

    //private FallenManController fallenManController;
    private Collider powerButtonCollider;
    private Collider shockButtonCollider;
    private ShowMessageFromList textList;
    private AudioSource _audio;

    private Vector3 originalBoxPos;
    private Vector3 originalBoxRotation;
    //private Transform originalRightPadPos;
    //private Transform originalLeftPadPos;


    private bool _isReadyToPadCalled;
    private bool _isPaddedCalled;
    private bool _isShockCalled;
    private int _shockCount;

    public UnityEvent onShocked = new UnityEvent();
    public UnityEvent onReset = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        //fallenManController = fallenMan.GetComponent<FallenManController>();
        powerButtonCollider = powerButton.GetComponent<Collider>();
        shockButtonCollider = shockButton.GetComponent<Collider>();
        textList = screenText.GetComponent<ShowMessageFromList>();
        _audio = GetComponent<AudioSource>();

        originalBoxPos = box.transform.position;
        originalBoxRotation = box.transform.eulerAngles;
        //Debug.Log(originalAedPos +","+ originalAedRotation);
        //originalRightPadPos = rightPad.transform;
        //originalLeftPadPos = leftPad.transform;
　　　}

    // Update is called once per frame
    void Update()
    {
        //aedPowerButtonPressed = powerButton.GetComponent<AEDPowerButton>().aedPowerButtonPressed;
        //aedShockButtonPressed = shockButton.GetComponent<AEDShockButton>().aedShockButtonPressed;

        //rightPadded = rightPad.GetComponent<AEDRightChestPad>().rightPadded;
        //leftPadded = leftPad.GetComponent<AEDLeftChestPad>().leftPadded;

        //call ready to pad
        if (!_isReadyToPadCalled)
        {
            if (isClothesOff && aedPowerButtonPressed)
            {
                gameManager.ReadyToPad();
                _isReadyToPadCalled = true;
                powerButtonCollider.enabled = false;
                textList.ShowMessageAtIndex(0);
                _audio.Play();
            }
        }

        //call to analyze 
        if (!_isPaddedCalled)
        {
            if(rightPadded && leftPadded)
            {
                _isPaddedCalled = true;
                StartCoroutine(AEDMessages());
                _audio.Play();
            }
        }
    }

    //call from ManController
    public void ManClothesOff()
    {
        isClothesOff = true;
    }

    //call from Power Button
    public void PowerButtonPressed()
    {
        aedPowerButtonPressed = true;
    }

    //call from RightPad
    public void RightPadded()
    {
        rightPadded = true;
    }

    //call from LeftPad
    public void LeftPadded()
    {
        leftPadded = true;
    }

    //Call from AEDShockButton
    public void OnShockButtonPressed()
    {
        //when press shock
        //if (aedShockButtonPressed)
        //{
            if (!_isShockCalled)
            {
                if (_shockCount == 0)
                {
                    WhenShockButtonPressed();
                    gameManager.FirstAEDShocked();
                    Debug.Log("First shocked: Shock count" + _shockCount);
                    _shockCount = 1;


                }
                else if (_shockCount == 1)
                {
                    WhenShockButtonPressed();
                    gameManager.SecondAEDShocked();
                    Debug.Log("Second shocked: Shock count" + _shockCount);
                }

            }
        //}
    }

    public void WhenShockButtonPressed()
    {
        onShocked.Invoke();//AEDShockButton Callback

        _isShockCalled = true;
        textList.ShowMessageAtIndex(5);
        //aedShockButtonPressed = false;
        shockButtonCollider.enabled = false;
        _audio.Play();
    }

    public void ReadyForSecondShock()
    {
        _isShockCalled = false;
        StartCoroutine(AEDMessages());
    }

    //Ready to Pad
    public void ReadyToPad()
    {
        rightPad.GetComponent<Collider>().enabled = true;
        leftPad.GetComponent<Collider>().enabled = true;
    }

    //start analyze and shock
    private IEnumerator AEDMessages()
    {
        textList.ShowMessageAtIndex(1);
        yield return new WaitForSeconds(4);
        textList.ShowMessageAtIndex(2);
        yield return new WaitForSeconds(4);
        textList.ShowMessageAtIndex(3);
        yield return new WaitForSeconds(4);
        textList.ShowMessageAtIndex(4);
        shockButtonCollider.enabled = true;
    }


    //Reset
    public void ResetAed()
    {
        _shockCount = 0;
        
        textList.ShowMessageAtIndex(6);

        //aedShockButtonPressed = false;
        _isReadyToPadCalled = false;
        _isPaddedCalled = false;
        _isShockCalled = false;
        powerButtonCollider.enabled = true;
        shockButtonCollider.enabled = false;
        rightPad.GetComponent<Collider>().enabled = false;
        leftPad.GetComponent<Collider>().enabled = false;

        isClothesOff = false;
        aedPowerButtonPressed = false;
        rightPadded = false;
        leftPadded = false;

        onShocked.Invoke();//AEDShockButton Callback
        onReset.Invoke();//Pad Callback, Power button callback

        //Transform Reset
        box.transform.position = originalBoxPos;
        box.transform.eulerAngles = originalBoxRotation;
        //Debug.Log(transform.position + "," + transform.eulerAngles);

        gameObject.SetActive(false);

        //rightPad.transform.position = originalRightPadPos.position;
        //rightPad.transform.rotation = Quaternion.identity;

        //leftPad.transform.position = originalLeftPadPos.position;
        //leftPad.transform.rotation = Quaternion.identity;


    }

    //Button Control
    //public void AedPowerButtonPressed(bool _isPressed)
    //{
    //    aedPowerButtonPressed = _isPressed;
    //}

    //public void AedShockButtonPressed(bool _isPressed)
    //{
    //    aedShockButtonPressed = _isPressed;
    //}
}
