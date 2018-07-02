using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISwitch : MonoBehaviour
{
    public GameObject player;

    private bool idontknow = false;
    private int counter = 0;
    private bool startGame = false;
    private float startTime = 0f;
    private float levelTime = 0f;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startGame = true;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame ==true)
        {
            levelTime = Time.time - startTime;
            counter = (int)(levelTime % 60f);
        }
       
        if ((counter == 40 && idontknow == false)||Input.anyKeyDown == true)
        {
            LoadSceneByIndex(1);
            idontknow = true;
            Debug.Log("anythingDoesntmatter");
            Debug.Log(idontknow);
            Debug.Log(counter);
            Debug.Log(startTime);
            counter += 1;
        }
    }

    public void LoadSceneByIndex(int Index)
    {
        Time.timeScale = 1;
        Debug.Log("Click!!!");
        //a function that loads the scene with the index it was passed
        SceneManager.LoadScene(1);
    }
}