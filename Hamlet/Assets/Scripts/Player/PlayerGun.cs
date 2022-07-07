using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint;

    [SerializeField]
    float firingSpeed;

    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;


    public GunScriptableObject gunScriptableObject;

    public static PlayerGun Instance;

    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<PlayerGun>();
    }

    public void Shoot()
    {
        if(lastTimeShot + firingSpeed <= Time.time)
        {
        Projectile _projectile = ProjectilePool.Instance.Instantiate(firingPoint.position, firingPoint.rotation);
        _projectile.Move();
        lastTimeShot = Time.time;
        }
    }
}
