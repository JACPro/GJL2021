using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{   
    [SerializeField] Transform bulletSpawn;

    [SerializeField] float timeBetweenShots = 0.5f;

    //colour materials
    [SerializeField] Material blue;
    [SerializeField] Material red;
    [SerializeField] Material yellow;

    //bullet prefabs    
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float bulletForce = 10f;

    Colours currentColour = Colours.Red;

    bool canFire = true;

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            ChangeBulletColour();
        }
    }

    void Shoot()
    {
        if (canFire)
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Bullet>().SetColourAndMaterial(currentColour, GetComponent<Renderer>().material);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);

            canFire = false;
            StartCoroutine(WaitToFire());
        }

    }    

    void ChangeBulletColour()
    {
        switch(currentColour)
        {
            case Colours.Blue:
                currentColour = Colours.Red;
                GetComponent<Renderer>().material = red;
                transform.GetChild(0).GetComponent<Renderer>().material = red;
                break;
            case Colours.Red:
                currentColour = Colours.Yellow;
                GetComponent<Renderer>().material = yellow;
                transform.GetChild(0).GetComponent<Renderer>().material = yellow;
                break;
            case Colours.Yellow:
                currentColour = Colours.Blue;
                GetComponent<Renderer>().material = blue;
                transform.GetChild(0).GetComponent<Renderer>().material = blue;
                break;            
        }
    }

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canFire = true;
    }
}
