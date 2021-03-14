using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI text;
    Color32 textColour;
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();  
        textColour = text.faceColor;  
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.faceColor = new Color32(255, 0, 0, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.faceColor = textColour;
    }
}
