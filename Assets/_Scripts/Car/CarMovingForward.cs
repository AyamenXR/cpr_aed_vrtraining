using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovingForward : MonoBehaviour
{
    public float carSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CarForward();
    }

    public void CarForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed);
    }
}
