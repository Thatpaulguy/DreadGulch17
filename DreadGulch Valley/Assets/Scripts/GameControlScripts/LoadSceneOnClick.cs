using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    //a function to load scenes based on their index number
    public void LoadSceneByIndex(int Index)
    {

        Time.timeScale = 1;

        Debug.Log("Click!!!");
        //a function that loads the scene with the index it was passed
        SceneManager.LoadScene(Index);
    }
}