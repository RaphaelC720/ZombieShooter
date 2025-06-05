using UnityEngine;

[CreateAssetMenu(fileName = "weaponBase", menuName = "Scriptable Objects/weaponBase")]
public class weaponBase : ScriptableObject
{
    public GameObject Weapon;
    public GameObject Projectile;
    public string WeaponName;
    public int CurrentAmmo;
    public int MaxAmmo;
    public float shootInterval;
    public float shootTimer;
    public float ReloadCooldown;
    public float ReloadTimer;
    public Vector3 equipPosition;
    public Vector3 equipRotation;
    public Vector3 equipScale;
}
