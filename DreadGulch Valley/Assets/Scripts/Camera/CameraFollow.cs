using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public Transform target;
    public float smoothing = 5f;
    private Vector3 offset;
    private Scene currentScene;
    private int counter = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>().transform;
        offset.y= 16; offset.z = -20;

        currentScene = SceneManager.GetActiveScene();
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}