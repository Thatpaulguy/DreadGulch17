using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInstance : MonoBehaviour
{
    public static SingleInstance instance = null;

    // Use this for initialization
    void OnEnable ()
    {
        //the initialization of the GameManager instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}