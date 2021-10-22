using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public bool isSurrroundChecked;
    public bool isAmbulanceCalled;
    public bool isAedAasked;

    public GameManager gameManager;

    private bool _ambulanceAndAedCalled;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (!_ambulanceAndAedCalled)
        {
            if (isAmbulanceCalled && isAedAasked)
            {
                gameManager.AmbulanceAndAEDCalled();
                _ambulanceAndAedCalled = true;
            }
        }

    }

    public void IsSurroundChecked(bool _isSurroundChecked)
    {
        isSurrroundChecked = _isSurroundChecked;
    }

    public void IsAmbulanceCalled(bool _isAmbulanceCalled)
    {
        isAmbulanceCalled = _isAmbulanceCalled;
    }

    public void IsAedAsked(bool _isAedAasked)
    {
        isAedAasked = _isAedAasked;
    }

    public void Reset()
    {
        isSurrroundChecked = false;
        isAmbulanceCalled = false;
        isAedAasked = false;
        _ambulanceAndAedCalled = false;
    }
}
