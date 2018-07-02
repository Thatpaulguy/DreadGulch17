using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonFromGraveYard : MonoBehaviour
{
    private GameObject player;
    private SceneCheck playerscene;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerscene = player.GetComponent<SceneCheck>();
        if (playerscene.IsInGraveyard)
        {
            player.transform.position = gameObject.transform.position;
            playerscene.IsInGraveyard = false;
            playerscene.IsInCanyon = true;
            //GameObject.FindGameObjectWithTag("DestroyableBoulder").GetComponent<DestroyBoulder>().IsDestroyed();
            //GameObject.FindGameObjectWithTag("DynamitePickup").GetComponent<PickupDynamite>().IsPickedUp();
            GameObject obj = GameObject.FindGameObjectWithTag("DestroyableBoulder");
            if (obj != null)
            {
                DestroyBoulder objScript = obj.GetComponent<DestroyBoulder>();
                if (objScript != null)
                    objScript.IsDestroyed();
            }
            obj = GameObject.FindGameObjectWithTag("DynamitePickup");
            if (obj != null)
            {
                PickupDynamite objScript = obj.GetComponent<PickupDynamite>();
                if (objScript != null)
                    objScript.IsPickedUp();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    { }
}