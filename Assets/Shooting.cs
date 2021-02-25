using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{   
    [SerializeField] Transform bulletSpawn;

    //colour materials
    [SerializeField] Material blue;
    [SerializeField] Material red;
    [SerializeField] Material yellow;

    //bullet prefabs    
    [SerializeField] GameObject blueBullet;
    [SerializeField] GameObject redBullet;
    [SerializeField] GameObject yellowBullet;

    [SerializeField] float bulletForce = 10f;

    enum Colours {Blue, Red, Yellow};

    Colours currentColour = Colours.Red;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
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
        GameObject bullet = new GameObject();
        switch (currentColour)
        {
            case Colours.Blue:
                bullet = Instantiate(blueBullet, bulletSpawn.position, bulletSpawn.rotation);
                break;
            case Colours.Red:
                bullet = Instantiate(redBullet, bulletSpawn.position, bulletSpawn.rotation);
                break;
            case Colours.Yellow:
                bullet = Instantiate(yellowBullet, bulletSpawn.position, bulletSpawn.rotation);
                break;
        }
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
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
}
