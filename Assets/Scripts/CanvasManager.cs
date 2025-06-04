using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager CanvasSingleton;
    public PlayerScript player;

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

    void Update()
    {

    }

    public void ChangeHealth(int playerHealth)
    {
        //run code that turns off the index of the heart here
        for (int i = 0; i < health.Length; i++)
        {
            if (i < playerHealth) { health[i].SetActive(true); }
            else { health[i].SetActive(false); }
        }
    }

    void ChangeScore()
    {

    }
}
