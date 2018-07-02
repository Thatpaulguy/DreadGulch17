using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip[] deathClips;
    public AudioClip[] hitClips;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public float chaseRange = 50f;
    public Slider enemyHealthSlider;
    public bool hasGun = true;

    private Animator anim;
    private AudioSource enemyAudio;
    private ParticleSystem hitParticles;
    private CapsuleCollider capsuleCollider;

    private bool isDead;
    private bool isSinking;
    private bool playerInRange;
    private float timer;

    private GameObject selfObj;
    private GameObject playerObj;
    private Transform playerTransform;
    private PlayerHealth playerHealth;
    private UnityEngine.AI.NavMeshAgent nav;

    void Start()
    {
		deathClips = Resources.LoadAll<AudioClip>("Audio/Deaths");
        hitClips = Resources.LoadAll<AudioClip>("Audio/Hits");
        enemyAudio = GetComponent<AudioSource>();
		
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;

        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObj.transform;
        playerHealth = playerObj.GetComponent<PlayerHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObj)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObj)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if (!isDead)
        {
            Vector3 pv = playerTransform.position;
            pv.y += 30;
            Vector3 ev = transform.position;
            float distanceToPlayer =
                Mathf.Sqrt(Mathf.Pow(pv.x - ev.x, 2) + Mathf.Pow(pv.y - ev.y, 2) + Mathf.Pow(pv.z - ev.z, 2));

			if (timer >= timeBetweenAttacks && playerInRange && currentHealth > 0)
            {
                Attack();
            }

            if (currentHealth > 0 && playerHealth.currentHealth > 0 && distanceToPlayer < chaseRange)
            {
                if (!nav.enabled)
                    nav.enabled = true;
                nav.SetDestination(playerTransform.position);
                anim.SetBool("isWalking", true);
            }
            else
            {
                nav.enabled = false;
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            nav.enabled = false;
            anim.SetBool("isWalking", false);
            if (timer >= 1f && !isSinking)
                StartSinking();
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        currentHealth -= amount;
        enemyAudio.PlayOneShot(hitClips[0]);
        enemyHealthSlider.value = ((float)currentHealth / startingHealth);
        
        if (currentHealth <= 0)
        {
            playerHealth.enemyDies += 1;
           // enemyAudio.PlayOneShot(hitClips[0]);
            Debug.Log("Enemy has died!");
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
      
        enemyAudio.PlayOneShot(deathClips[Random.Range(0, deathClips.Length)]);

        timer = 0f;
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }

    void Attack()
    {
        timer = 0f;

		if (playerHealth.currentHealth > 0 && hasGun && currentHealth > 0 && CheckAttackCone())
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

	bool CheckAttackCone()
	{
		float angle = 0f;
		float conicAngle = 30;

		Vector3 forward = gameObject.transform.forward;
		Vector3 toPlayer = gameObject.transform.position - playerTransform.position;

		//A dot B = |A| * |B| * cos(theta) = angle between two vectors
		angle = (Vector3.Dot(forward, toPlayer)) / (Vector3.Magnitude(forward) * Vector3.Magnitude(toPlayer));
		angle = Mathf.Acos (angle);

		float temp = 180 * (1 - angle / Mathf.PI);

		angle = Mathf.Abs(temp);

		if (angle < conicAngle) {
			return true;
		} else {
			return false;
		}
	}

    public bool IsPlayerInRange()
    {
        return playerInRange;
    }

    public bool IsDead()
    {
        return isDead;
    }
}