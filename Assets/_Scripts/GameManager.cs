using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Intro,
        Learn,//あとで
        Exercise,//あとで
        Practice
    }

    public static GameState eGameStatus;

    [Header("Game structure Events")]
    public UnityEvent onLevelSelected;
    public UnityEvent onStartActivated;
    public UnityEvent onManFallen;
    public UnityEvent onSurroundChecked;
    public UnityEvent onCalledAmbulanceAndAED;
    public UnityEvent onBreathChecked;
    public UnityEvent onFirstCPRCompleted;
    public UnityEvent onReadyToPad;
    public UnityEvent onFirstAEDShocked;
    public UnityEvent onSecondCPRCompleted;
    public UnityEvent onSecondAEDShocked;
    public UnityEvent onCheckedBreathReturned;
    public UnityEvent onComplete;
    public UnityEvent onReset;


    private void Start()
    {
        eGameStatus = GameState.Intro;
        Reset();
    }

    public void LearnState()
    {
        eGameStatus = GameState.Learn;
        LevelSelected();
    }

    public void ExerciseState()
    {
        eGameStatus = GameState.Exercise;
        LevelSelected();
    }

    public void PracticeState()
    {
        eGameStatus = GameState.Practice;
        LevelSelected();
    }

    public void StartAgain()
    {
        LevelSelected();
    }


    //Invoke Unity Event Method

    public void LevelSelected()
    {
        onLevelSelected.Invoke();
        Reset();
    }

    public void StartClicked()//UI: Click "Start" button in Click Start
    {
        onStartActivated.Invoke();
    }

    public void ManFallen()//Fallen Man Controller
    {
        onManFallen.Invoke();
    }

    public void SurroundChecked() //UI: Click "Surround Checked" button in 1_CheckAround
    {
        onSurroundChecked.Invoke();
    }

    public void AmbulanceAndAEDCalled() //TaskManager
    {
        onCalledAmbulanceAndAED.Invoke();
    }

    public void BreathChecked()//UI: Click "No" button in 3_CheckBreath"
    {
        onBreathChecked.Invoke();
    }

    public void FirstCPRCompleted()//CPR collider
    {
        onFirstCPRCompleted.Invoke();
    }

    public void ReadyToPad()//AED Controller
    {
        onReadyToPad.Invoke();
    }

    public void FirstAEDShocked()//AED Controller
    {
        onFirstAEDShocked.Invoke();
    }

    public void SecondCPRCompleted()//CPR collider
    {
        onSecondCPRCompleted.Invoke();
    }

    public void SecondAEDShocked()//AED Controller
    {
        onSecondAEDShocked.Invoke();
    }

    public void CheckedBreathReturned()//UI: Returend breath checked button
    {
        onCheckedBreathReturned.Invoke();
        StartCoroutine(Completed());
    }

    private IEnumerator Completed()
    {
        yield return new WaitForSeconds(5);
        onComplete.Invoke();
    }

    public void Reset()
    {
        onReset.Invoke();
    }
}
