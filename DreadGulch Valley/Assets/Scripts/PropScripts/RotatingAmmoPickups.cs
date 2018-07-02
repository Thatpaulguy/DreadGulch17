using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingAmmoPickups : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.Rotate(new Vector3(30.0f, 0.0f, 10.0f) * Time.deltaTime);

    }
}
