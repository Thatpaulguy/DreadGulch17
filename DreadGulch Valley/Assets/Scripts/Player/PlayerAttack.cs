using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 10.15f;
    public float range = 100f;
    public int gunID = 0;
   
    private float timer;
    private Ray shootRay = new Ray();
    private RaycastHit shootHit;
    private int shootableMask;
    private ParticleSystem gunParticles;
    private LineRenderer gunLine;
    private AudioSource gunAudio;
    private Light gunLight;
    private float effectsDisplayTime = 0.2f;
    private PlayerHealth playerHealth;
    private int floorMask;

    // Use this for initialization
    void Start()
    {
        int shootable = LayerMask.NameToLayer("Shootable");
        int wallMask = LayerMask.NameToLayer("ShootableMinimap");
        shootableMask = (1 << shootable) | (1 << wallMask);
        
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        floorMask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (playerHealth != null)
        {
            if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 &&
                    playerHealth.currentGun == 0 && playerHealth.pistolAmmoCount > 0)
            {
                timer = 0.0f;
                Shoot();
            }
            
            else if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 &&
                 playerHealth.currentGun == 1 && playerHealth.shotgunAmmoCount > 0)
            {
                Shoot();
                timer = 0.0f;
            }
            
            else if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 &&
                  playerHealth.currentGun == 2 && playerHealth.rifleAmmoCount > 0)
            {
                Shoot();
                timer = 0.0f;
            }
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
            DisableEffects();
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;

        if (playerHealth.currentGun == 1)
        {
            foreach (LineRenderer line in gameObject.GetComponentsInChildren<LineRenderer>())
            {
                line.enabled = false;
            }
        }
    }

    void Shoot()
    {
        playerHealth.DecreaseAmmoCount(1);

        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;

        if (playerHealth.currentGun != 1)
        {
            Vector3[] positions =
            {
                transform.position,
                transform.forward,
                transform.position,
                transform.forward + new Vector3(1.0f, 0.0f, 0.0f),
                transform.position,
                transform.forward + new Vector3(-1.0f, 0.0f, 0.0f),
                transform.position,
                transform.forward + new Vector3(2.0f, 0.0f, 0.0f),
                transform.position,
                transform.forward + new Vector3(-2.0f, 0.0f, 0.0f)
            };

            gunLine.SetPositions(positions);

            shootRay.origin = transform.position;

            Vector3 mousePos = Input.mousePosition;
            Ray camRay = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, 100f, floorMask))
                shootRay.direction = floorHit.point - transform.position;

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                if (shootHit.collider.CompareTag("Enemy"))
                {
                    EnemyBase enemyHealth = shootHit.collider.GetComponent<EnemyBase>();
                    if (enemyHealth != null)
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
                else if (shootHit.collider.CompareTag("Explosives"))
                {
                    ExplosivesScript explosives = shootHit.collider.GetComponent<ExplosivesScript>();
                    explosives.Explode();
                }

                gunLine.SetPosition(1, shootHit.point);
            }
            else
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
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

                if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
                {
                    if (shootHit.collider.CompareTag("Enemy"))
                    {
                        EnemyBase enemyHealth = shootHit.collider.GetComponent<EnemyBase>();
                        if (enemyHealth != null)
                            enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }
                    else if (shootHit.collider.CompareTag("Explosives"))
                    {
                        ExplosivesScript explosives = shootHit.collider.GetComponent<ExplosivesScript>();
                        explosives.Explode();
                    }

                    line.SetPosition(1, shootHit.point);
                }
                else
                    line.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}