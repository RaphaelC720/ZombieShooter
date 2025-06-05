using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager CanvasSingleton;
    public PlayerScript player;
    public weaponBase ActiveWeaponWB;
    public TextMeshProUGUI CurrentAmmo;
    public TextMeshProUGUI MaxAmmo;



    public GameObject[] health;
    void Start()
    {
        CanvasSingleton = this;

        health = GameObject.FindGameObjectsWithTag("Health");
        //creates an array that looks like this:
        //health[0]
        //health[1]
        //health[2]
        //health[3]
    }

    public void ChangeHealth(int playerHealth)
    {
        //run code that turns off the index of the heart here
        for (int i = 0; i < health.Length; i++)
        {
            int visualIndex = health.Length - 1 - i; 

            if (i < playerHealth) { health[i].SetActive(true); }
            else { health[i].SetActive(false); }
        }
    }

    public void UpdateAmmo()
    {
        CurrentAmmo.text = player.ActiveWeaponWB.CurrentAmmo.ToString();
        MaxAmmo.text = ActiveWeaponWB.MaxAmmo.ToString();
    }

    void ChangeScore()
    {

    }
}
