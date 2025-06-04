using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public Rigidbody2D ZombRB;
    public float speed;
    public float health;
    public float damage;
    public float range;
    public GameObject target;
    


    void Start()
    {
        ZombRB = GetComponent<Rigidbody2D>();
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
        else
        {
            FollowPath();
        }
    }

    void FollowPath()
    {

    }

}
