using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public void EnableGun()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
        PlayerAttack pa = GetComponentInChildren<PlayerAttack>();
        pa.enabled = true;
    }

    public void DisableGun()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        PlayerAttack pa = GetComponentInChildren<PlayerAttack>();
        pa.enabled = false;
    }
}
