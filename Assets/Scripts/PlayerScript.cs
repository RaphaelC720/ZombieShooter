using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject currentWeapon;
    //public Animation ActiveWeaponAnim;

    public CanvasManager myCanvas;

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
        {
            UseWeapon();
        }

        //Score
        scoreText.text = Score.ToString();

        //die
        if (CurrentHealth <= 0)
            Die();

        if (myCanvas == null && CanvasManager.CanvasSingleton != null)
        {
            myCanvas = CanvasManager.CanvasSingleton;
        }

        //if (ActiveWeaponWB != null)
        //{
            
        //}
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            EquipWeapon(other.gameObject);
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
    void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
            Destroy(currentWeapon);

        weapon.transform.SetParent(transform);
        weapon.transform.rotation = transform.rotation;
        float offset = 0.5f;
        Vector3 forward = transform.up;
        weapon.transform.position = transform.position + forward * offset;

        currentWeapon = weapon;

        WeaponPickup pickup = weapon.GetComponent<WeaponPickup>();
        if (pickup != null)
        {
            ActiveWeaponWB = pickup.weaponData;
        }

        ActiveWeaponWB.CurrentAmmo += ActiveWeaponWB.MaxAmmo;
    }

    void UseWeapon()
    {
        if (ActiveWeaponWB == null) return;

        ActiveWeaponWB.shootTimer -= Time.deltaTime;
        if ((ActiveWeaponWB.shootTimer <= 0) && (ActiveWeaponWB.CurrentAmmo > 0))
        { 
            if (ActiveWeaponWB.WeaponName == "Pistol")
            {
                ActiveWeaponWB.CurrentAmmo -= 1;
                //ActiveWeaponAnim = PistolScript.GetComponent<Animator>();
                Vector3 offset = transform.up * 0.5f;
                GameObject obj = Instantiate(ActiveWeaponWB.Projectile, transform.position + offset * 0.5f, transform.rotation);
                ActiveWeaponWB.shootTimer = ActiveWeaponWB.shootInterval;

            }
        }
    }

    void Die()
    {
        //SceneManager.LoadScene("GameOver");
    }

    void UpdateHealth()
    {

    }

}
