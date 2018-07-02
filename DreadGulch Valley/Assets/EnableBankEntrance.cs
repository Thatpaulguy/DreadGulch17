using UnityEngine;

public class EnableBankEntrance : MonoBehaviour
{
    private CapsuleCollider exitTrigger;
    public GameObject triggerObject;

	// Use this for initialization
	void Start ()
	{
	    exitTrigger = triggerObject.GetComponent<CapsuleCollider>();
	    exitTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void EnableTrigger()
    {
        exitTrigger.enabled = true;
    }
}