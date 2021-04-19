using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject helper;
    public GameObject bunny;
    public GameObject heron;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            helper.SetActive(!helper.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCharacter(heron, bunny);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCharacter(bunny, heron);
        }

    }


    void SwitchCharacter(GameObject newChar, GameObject oldChar)
    {
        oldChar.GetComponent<PlayerMovement>().isActive = false;
        newChar.GetComponent<PlayerMovement>().isActive = true;
    }
}
