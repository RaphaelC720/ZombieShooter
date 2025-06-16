using UnityEngine;

[CreateAssetMenu(fileName = "weaponBase", menuName = "Scriptable Objects/weaponBase")]
public class weaponBase : ScriptableObject
{
    public GameObject Weapon;
    public GameObject Projectile;
    public string WeaponName;
    public int MaxAmmo;
    public float shootInterval;
    public float shootTimer;
}
