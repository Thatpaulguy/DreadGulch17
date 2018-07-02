using UnityEngine;

public class TownFromSaloon : MonoBehaviour
{
    private GameObject player;
    private SceneCheck playerscene;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerscene = player.GetComponent<SceneCheck>();
        if (playerscene.IsInSaloon)
        {
            player.transform.position = gameObject.transform.position;
            playerscene.IsInSaloon = false;
            playerscene.IsInTown = true;

            GameObject explosives = GameObject.Find("Explosives");
            ExplosivesScript script = explosives.GetComponent<ExplosivesScript>();
            script.IsDestroyed();

            GameObject obj = GameObject.FindGameObjectWithTag("OtherDynamite");
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