using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int yellowHP;
    [SerializeField] int redHP;
    [SerializeField] int blueHP;
    int maxTotalHP;

    int currYHP;
    int currRHP;
    int currBHP;

    int redHueVal = 0;

    GameObject redHPbar;
    GameObject yellowHPbar;
    GameObject blueHPbar;


    void Start()
    {
        maxTotalHP = yellowHP + redHP + blueHP;

        currYHP = yellowHP;
        currRHP = redHP;
        currBHP = blueHP;

        //the hue value for red can be 0 or 360
        //if transitioning between red/yellow/orange, red must be set to 0
        //if transitioning between red/blue/purple, red must be set to 360
        if (blueHP > 0) {
            redHueVal = 360;
        }

        //set starting enemy colour
        ChangeColour();

        //get enemy HP bar lights and set to off if no HP in that colour
        redHPbar = transform.GetChild(0).gameObject;
        if (currRHP <= 0) {
            SetHPBarOff(redHPbar);
        }
        yellowHPbar = transform.GetChild(1).gameObject;
        if (currYHP <= 0)
        {
            SetHPBarOff(yellowHPbar);
        }
        blueHPbar = transform.GetChild(2).gameObject;
        if (currBHP <= 0)
        {
            SetHPBarOff(blueHPbar);
        }
    }

    void Update()
    {
        
    }

    public void TakeDamage(Colours colour)
    {
        switch (colour)
        {
            case Colours.Red:
                if (currRHP > 0)
                {
                    currRHP--;
                    ChangeColour();
                    if (currRHP <= 0) {
                        SetHPBarOff(redHPbar);
                    }
                    CheckIfDead();
                }
                break;
            case Colours.Yellow:
                if (currYHP > 0)
                {
                    currYHP--;
                    ChangeColour();
                    if (currYHP <= 0)
                    {
                        SetHPBarOff(yellowHPbar);
                    }
                    CheckIfDead();
                }
                break;
            case Colours.Blue:
                if (currBHP > 0)
                {
                    currBHP--;
                    ChangeColour();
                    if (currBHP <= 0)
                    {
                        SetHPBarOff(blueHPbar);
                    }
                    CheckIfDead();
                }
                break;
        }
    }

    void ChangeColour()
    {
        float hue;
        float sat;
        float val;
        
        Color.RGBToHSV(GetComponent<Renderer>().material.color, out hue, out sat, out val);

        int currTotalHP = currRHP + currYHP + currBHP;

        if (currTotalHP > 0) 
        {
            hue = ((currRHP * redHueVal) + (currYHP * (int)Colours.Yellow) + (currBHP * (int)Colours.Blue)) / (currTotalHP);
            //hue range from 0 to 1 so must be fraction
            hue /= 360;
        }

        //change sat and val based on HP %
        sat = (float)currTotalHP / (float)maxTotalHP;
        val = ((float)currTotalHP / (float)maxTotalHP) / 2;
        Color newColour = Color.HSVToRGB(hue, sat, val);
        GetComponent<Renderer>().material.color = newColour;

        //emission colour should be more subtle
        val = 0.7f - val / 4;
        newColour = Color.HSVToRGB(hue, sat, val);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", newColour);
    }

    void CheckIfDead()
    {
        if ((currBHP + currRHP + currYHP) <= 0)
        {
            GetComponent<ParticleSystem>().Play();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        GetComponent<AudioSource>().Play(0);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void SetHPBarOff(GameObject hpBar)
    {
        Color hpCol = hpBar.GetComponent<Renderer>().material.color;

        float hue;
        float sat;
        float val;

        //turn saturation and value down to half each to give effect of turned off light
        Color.RGBToHSV(hpCol, out hue, out sat, out val);
        hpCol = Color.HSVToRGB(hue, 0.1f, val);
        hpCol.a = 0.5f;
        hpBar.GetComponent<Renderer>().material.color = hpCol;

        Destroy(hpBar.transform.GetChild(0).gameObject);

        //stop emission by turning emission colour to black
        hpBar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }
}
