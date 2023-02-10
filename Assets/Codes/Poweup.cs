using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweup : MonoBehaviour
{
    private bool item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            item = true;
            PlayerPrefs.SetInt("DoubleJump", (item ? 1 : 0));
        }
    }
}
