using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommandToQuit : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
