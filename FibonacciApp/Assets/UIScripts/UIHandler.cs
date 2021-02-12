using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text fibonacciNumber;
    int x = 0, c = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get the latest saved up fibonacci number
        fibonacciNumber.text = PlayerPrefs.GetInt("LatestFibonacciNumber").ToString();
        // Get the amount of times the player clicked on the increase button 
        x = PlayerPrefs.GetInt("LatestSeqNumber");
    }

    public void increaseFibonacci()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");

        // Increase the the amount of times the player clicked on the increase button to go to the next fibonacci number 
        x++;

        if (x == 1)
        {
            fibonacciNumber.text = x.ToString();
        }

        int a = 0, b = 1;

        // Go to the next fibonacci number when clicked on the increase button
        for (int i = 1; i < x; i++)
        {
            c = a + b;
            fibonacciNumber.text = c.ToString();
            a = b;
            b = c;
            // Save the fibonacci number
            PlayerPrefs.SetInt("LatestFibonacciNumber", c);
            // Save the amount of times the player clicked on the increase button 
            PlayerPrefs.SetInt("LatestSeqNumber", x);
        }

        // Play the button animation when this method is called by clicking on the increase button
        GetComponent<Animation>().Play("Button_Touch");
    }

    public void resetFibonacci()
    {
        // Delete all saved up numbers
        PlayerPrefs.DeleteKey("LatestFibonacciNumber");
        PlayerPrefs.DeleteKey("LatestSeqNumber");
        // Set the numbers back to zero
        x = 0;
        fibonacciNumber.text = "0";
        // Call the audiosource from the audiomanager
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
}
