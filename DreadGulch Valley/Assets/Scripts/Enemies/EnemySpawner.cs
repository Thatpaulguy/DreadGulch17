using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;

    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public bool spawnInRangeOnly = true;

	// Use this for initialization
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    void Spawn()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth.currentHealth <= 0)
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (spawnPoints.Length == 0)
            return;

        if (spawnPoints.Length == 1)
            spawnPointIndex = 0;

        if (spawnInRangeOnly)
        {
            Vector3 pv = player.transform.position;
            Vector3 ev = spawnPoints[spawnPointIndex].position;
            float distanceToPlayer =
                Mathf.Sqrt(Mathf.Pow(pv.x - ev.x, 2) + Mathf.Pow(pv.y - ev.y, 2) + Mathf.Pow(pv.z - ev.z, 2));

            EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();
            if (distanceToPlayer <= enemyBase.chaseRange)
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        else
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}