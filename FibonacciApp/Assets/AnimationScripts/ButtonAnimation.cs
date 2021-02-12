using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    // Get the animation for the button to play when this method is called
    public void ButtonTouch()
    {
        GetComponent<Animation>().Play("Button_Touch");
    }
}
