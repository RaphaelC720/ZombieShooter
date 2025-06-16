using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image Playerfillbar;
    public P1Script Player;
    public Image Enemyfillbar;
    public EnemyScript Enemy;

    void Update()
    {
        float HealthPercent = Mathf.Clamp01(Player.CurrentHealth / Player.MaxHealth);
        Playerfillbar.fillAmount = HealthPercent;

        float EHealthPercent = Mathf.Clamp01(Enemy.CurrentHealth / Enemy.MaxHealth);
        Enemyfillbar.fillAmount = EHealthPercent;
    }
}
