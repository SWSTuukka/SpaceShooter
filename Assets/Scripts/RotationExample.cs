using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExample : MonoBehaviour
{
    [Range(10f, 100F)]
    public float rotateSpeed = 50f;

    [Range(10f, 100f)]
    public float drivingSpeed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(1f, 2f, 3f);

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward* ver * drivingSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, hor * rotateSpeed*Time.deltaTime);
    }
}
