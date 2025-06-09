using UnityEngine;

public class WeaponInstance
{
    public weaponBase weaponData;
    public int CurrentAmmo;

    public WeaponInstance(weaponBase data)
    {
        weaponData = data;
        CurrentAmmo = 0;
    }
}
