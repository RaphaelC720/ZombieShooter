using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerScript player;
    public GameObject Speeditem;
    public float boost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.Speed += boost;
        Destroy(gameObject);
    }

}
