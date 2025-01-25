using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breaker : MonoBehaviour
{
    public Button targetButton; 
    public Color newColor;
    public void ChangeButtonColor()
    {
        if (targetButton != null)
        {
            targetButton.image.color = newColor;
        }
    }
}

