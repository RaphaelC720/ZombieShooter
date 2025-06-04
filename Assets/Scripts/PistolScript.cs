using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject Bullet;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.SetParent(collision.transform);
            transform.rotation = collision.transform.rotation;
            float offset = 0.5f; 
            Vector3 forward = collision.transform.up;
            transform.position = collision.transform.position + forward * offset;
        }
    }
}
