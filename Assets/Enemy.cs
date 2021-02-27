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

        ChangeColour();
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
                    //TODO subtract red from enemy colour
                }
                break;
            case Colours.Yellow:
                if (currYHP > 0)
                {
                    currYHP--;
                    ChangeColour();

                    //TODO subtract yellow from enemy colour
                }
                break;
            case Colours.Blue:
                if (currBHP > 0)
                {
                    currBHP--;
                    ChangeColour();

                    //TODO subtract blue from enemy colour
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
        val = 0.5f + ((float)currTotalHP / (float)maxTotalHP) / 2;
        print("hue: " + hue + " sat: " + sat + " val: " + val);
        Color newColour = Color.HSVToRGB(hue, sat, val);
        GetComponent<Renderer>().material.color = newColour;

        //emission colour should be more subtle
        val = 0.5f - val / 4;
        newColour = Color.HSVToRGB(hue, sat, val);
        GetComponent<Renderer>().material.SetColor("_EmissionColor", newColour);
    }
}
