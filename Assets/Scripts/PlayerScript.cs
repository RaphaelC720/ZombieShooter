using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float speed;
    public float health;
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 vel = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
        }
        myRB.linearVelocity = vel;

    }
}
