using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLifeTime = 5f;


    Colours colour = Colours.Red;

    void Start() {
        StartCoroutine(DestroySelf());
    }

    public void SetColourAndMaterial(Colours colour, Material material)
    {
        this.colour = colour;
        GetComponent<Renderer>().material = material;
        
        Color tempColor = material.color;

        //change bullet particles colour
        GetComponent<ParticleSystem>().startColor = tempColor;

        //change trail renderer colour to match bullet colour
        tempColor.a = 1f;
        GetComponent<TrailRenderer>().startColor = tempColor;
        tempColor.a = 0f;
        GetComponent<TrailRenderer>().endColor = tempColor;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(colour);
            //TODO inflict damage on enemy
        }
        
        if (other.gameObject.tag != "Player")
        {
            //Destroy(gameObject);
            StopMoving();
            GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }

    void StopMoving()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
    }
}
