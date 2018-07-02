using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaloonFromTown : MonoBehaviour
{
    private GameObject player;
    private SceneCheck playerscene;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerscene = player.GetComponent<SceneCheck>();
        if (playerscene.IsInTown)
        {
            player.transform.position = gameObject.transform.position;
            playerscene.IsInTown = false;
            playerscene.IsInSaloon = true;
            //GameObject.FindGameObjectWithTag("DestroyableBoulder").GetComponent<DoorExplosionScript>().IsDestroyed();
            GameObject obj = GameObject.FindGameObjectWithTag("DestroyableBoulder");
            if (obj != null)
            {
                DestroyBoulder objScript = obj.GetComponent<DestroyBoulder>();
                if (objScript != null)
                    objScript.IsDestroyed();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    { }
}