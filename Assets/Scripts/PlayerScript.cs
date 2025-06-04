using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRB;
    public SpriteRenderer mySR;
    public float Speed;
    public float CurrentHealth;
    public float MaxHealth = 3;

    public float InvicibilityTimer = 0;
    public int Score;
    public TextMeshProUGUI scoreText;

    public weaponBase ActiveWeaponWB;
    public Animation ActiveWeaponAnim;

    CanvasManager myCanvas;

    void Start()
    {
        myCanvas = CanvasManager.CanvasSingleton;
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
        CurrentHealth = MaxHealth;
        Score = 0;
    }
    void Update()
    {
        //movement
        bool moveUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool moveDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        Vector2 vel = new Vector2(0, 0);
        if (moveUp)
        {
            vel.y = Speed;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (moveLeft)
        {
            vel.x = -Speed;
            transform.rotation = Quaternion.Euler(0f, 0f, 90);

        }
        if (moveDown)
        {
            vel.y = -Speed;
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);

        }
        if (moveRight)
        {
            vel.x = Speed;
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);

        }
        myRB.linearVelocity = vel;

        //invincible
        if (InvicibilityTimer > 0)
        {
            Invincible();
        }

        //shoot
        if (Input.GetKey(KeyCode.Space))
            UseWeapon();

        //Score
        scoreText.text = Score.ToString();

        //die
        if (CurrentHealth <= 0)
            Die();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (InvicibilityTimer <= 0)
            {
                InvicibilityTimer = 3f;
                CurrentHealth -= 1;
                myCanvas.ChangeHealth((int)CurrentHealth);
            }
        }
    }

    void Invincible()
    {
        InvicibilityTimer -= Time.deltaTime;
        if (InvicibilityTimer > 0)
        {
            mySR.color = Color.blue;

        }
        else
            mySR.color = Color.white;
        return;
    }
    void UseWeapon()
    {
        if (ActiveWeaponWB.WeaponName == "Pistol")
        {
            //ActiveWeaponAnim = PistolScript.GetComponent<Animator>();
            //GameObject obj = Instantiate(weaponBase.PistolBullet, transform.position + offset * 0.5f, Quaternion.identity);

        }
    }

    void Die()
    {

    }

    void UpdateHealth()
    {

    }
}
