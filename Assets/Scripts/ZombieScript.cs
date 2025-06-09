using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public Rigidbody2D ZombRB;
    public float speed;
    public float health;
    public float damage;
    public float range;
    public GameObject target;
    public PlayerScript player;
    void Start()
    {
        ZombRB = GetComponent<Rigidbody2D>();
        //target = GetComponent<GameObject>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(target.transform.position, transform.position);
        if (distanceToPlayer <= range)
        {
            Vector2 vel;
            vel = (target.transform.position - transform.position).normalized;
            ZombRB.linearVelocity = new Vector2(vel.x * speed, vel.y * speed);
        }

        if (player.Score >= 50)
        {
            speed = 1.5f;
        }
        else if (player.Score >= 100)
            speed = 2;
    }

    public void SetTarget(GameObject targetObject, PlayerScript playerScript)
    {
        target = targetObject;
        player = playerScript;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        player.Score += 1;
        Destroy(gameObject);
    }



}
