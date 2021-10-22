using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] uis;

    public void ResetUI()
    {
        for(int i = 1; i < uis.Length; i++)
        {
            uis[i].SetActive(false);
        }

    }

    public void CheckAround(bool _isOn)
    {
        //if eGameStatus
        uis[1].SetActive(_isOn);
    }

    public void CallAmbulanceAndAED(bool _isOn)
    {
        //if eGameStatus
        uis[2].SetActive(_isOn);
    }

    public void CheckBreath(bool _isOn)
    {
        //if eGameStatus
        uis[3].SetActive(_isOn);
    }

    public void StartCPROne(bool _isOn)
    {
        //if eGameStatus
        uis[4].SetActive(_isOn);
    }

    public void EShockOne(bool _isOn)
    {
        //if eGameStatus
        uis[5].SetActive(_isOn);
    }

    public void StartCPRTwo(bool _isOn)
    {
        //if eGameStatus
        uis[6].SetActive(_isOn);
    }

    public void EshockTwo(bool _isOn)
    {
        //if eGameStatus
        uis[7].SetActive(_isOn);
    }

    public void BreathBackCheck(bool _isOn)
    {
        //if eGameStatus
        uis[8].SetActive(_isOn);
    }

    public void AmbulanceAndComplete(bool _isOn)
    {
        //if eGameStatus
        uis[9].SetActive(_isOn);
    }
}
