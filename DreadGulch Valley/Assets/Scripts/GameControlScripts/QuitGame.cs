using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //a function to quit the game
    public void Quit()
    {
        //if you are in the editor playmode it quits back to the editor
        //otherwise if it's a build it quit the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
