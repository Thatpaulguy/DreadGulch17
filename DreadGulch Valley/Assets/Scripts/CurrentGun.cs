using UnityEngine;

public class CurrentGun : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playersGun;
    private int gunID = 0;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playersGun = player.GetComponent<PlayerHealth>();

        if (gameObject.tag == "Pistol")
            gunID = 0;
        else if(gameObject.tag == "Shotgun")
            gunID = 1;
        else if(gameObject.tag == "Rifle")
            gunID = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playersGun.ChangeGun(gunID);
            gameObject.SetActive(false);
        }
    }
}