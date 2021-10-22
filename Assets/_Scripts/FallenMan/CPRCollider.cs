using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRCollider : MonoBehaviour
{

    public GameManager gameManager;
    public float span = 0.5f;
    public float showRedTime = 0.1f;

    public float cprDuration = 120f;
    public bool isOnFirstCPR;
    public bool isOnSecondCPR;

    private float _currentTime = 0f;
    private bool _indicatorOn;
    private Renderer _meshRenderer;


    private void Awake()
    {

    }
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
    }


    private void Update()
    {
        if (isOnFirstCPR)
        {
            _currentTime += Time.deltaTime;
            _meshRenderer.enabled = true;

            if (_currentTime > cprDuration)
            {
                gameManager.FirstCPRCompleted();
                isOnFirstCPR = false;
                _currentTime = 0f;
                _meshRenderer.enabled = false;
            }
        }

        if (isOnSecondCPR)
        {
            _currentTime += Time.deltaTime;
            _meshRenderer.enabled = true;

            if (_currentTime > cprDuration)
            {
                gameManager.SecondCPRCompleted();
                isOnSecondCPR = false;
                _currentTime = 0f;
                _meshRenderer.enabled = false;
            }
        }


    }
    //private void OnTriggerEnter(Collider other)
    //{

    //}

    public void ShowCPRIndication()
    {
        _indicatorOn = true;
        StartCoroutine(Indicator());
    }

    public void StopCPRIndication()
    {
        _indicatorOn =　false;
        StopCoroutine(Indicator());
    }

    IEnumerator Indicator()
    {
        while (_indicatorOn)
        {
            GetComponent<Renderer>().material.color = new Color(0.1f, 0.1f, 0.1f, 0.1f); //Color.gray;
            yield return new WaitForSeconds(span);
            GetComponent<Renderer>().material.color = new Color(0.5f, 0f, 0f, 0.5f);//Color.red;
            //Debug.Log("Indicator on");
            yield return new WaitForSeconds(showRedTime);

        }
    }
}
