using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGunAttack : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public int gunType = 0;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int playerMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyBase enemybase;
    bool playerInRange;

    void Start()
    {
        playerMask = LayerMask.GetMask("Player");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemybase = GetComponentInParent<EnemyBase>();

        playerInRange = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        playerInRange = enemybase.IsPlayerInRange();
        if (playerInRange && timer >= timeBetweenBullets && Time.timeScale != 0 && 
            enemybase.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;

        if (gunType == 1)
        {
            foreach (LineRenderer line in gameObject.GetComponentsInChildren<LineRenderer>())
            {
                line.enabled = false;
            }
        }
    }

    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        if (gunType != 1)
        {
            gunLine.SetPosition(0, transform.position);
            gunLine.enabled = true;
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if (Physics.Raycast(shootRay, out shootHit, range, playerMask))
            {
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damagePerShot);
                }
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction*range);
            }
        }
        else
        {
            List<LineRenderer> lines = GetComponentsInChildren<LineRenderer>().ToList();
            lines.Insert(0, gunLine);

            foreach (LineRenderer line in lines)
            {
                line.SetPosition(0, transform.position);
                line.enabled = true;
                shootRay.origin = transform.position;
                shootRay.direction = line.transform.forward;

                if (Physics.Raycast(shootRay, out shootHit, range, playerMask))
                {
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damagePerShot);
                    }

                    line.SetPosition(1, shootHit.point);
                }
                else
                {
                    line.SetPosition(1, shootRay.origin + shootRay.direction * range);
                }
            }
        }
    }
}