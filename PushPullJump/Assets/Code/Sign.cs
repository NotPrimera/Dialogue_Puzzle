using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    public string message;
    public TextMeshPro textComponent; 

    void Start()
    {
        textComponent.text = message; 
        textComponent.gameObject.SetActive(false); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textComponent.gameObject.SetActive(true); 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textComponent.gameObject.SetActive(false);
        }
    }
}
