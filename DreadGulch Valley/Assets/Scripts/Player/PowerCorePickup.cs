using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCorePickup : MonoBehaviour
{ 
    public GameObject inventoryBar;
    public GameObject icons;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerCore")
        {
            GameObject icon = Instantiate(icons);

            icon.transform.SetParent(inventoryBar.transform);

        }
    }
}
