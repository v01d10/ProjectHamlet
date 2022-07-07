using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 5f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public GameObject gun;
    public AudioSource ShootingSound;
    public AudioSource Cock;
    public float CockWait;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            ShootingSound.Play();
            Shoot();
            Invoke("Clock", CockWait);
        }
    }

public void Clock()
{
    Cock.Play();
}

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
