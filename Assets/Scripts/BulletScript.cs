using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float offset = 0.5f;
        transform.position += transform.up * offset * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ZombieScript zombie = collision.GetComponent<ZombieScript>();
            if (zombie != null)
            {
                zombie.TakeDamage(1); 
            }

            Destroy(gameObject);
        }
        
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
