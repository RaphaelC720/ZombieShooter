using UnityEngine;

public class ExtraHeartScript : MonoBehaviour
{
    public PlayerScript player;
    public GameObject ExtraLife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.CurrentHealth <= 3)
            {
                player.CurrentHealth += 1;
                Destroy(gameObject);
            }

            else
            {
                player.CurrentHealth -= 0;
                Destroy(gameObject);
            }
        }
    }
}
