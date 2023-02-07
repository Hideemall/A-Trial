using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    public int LevelToUnlock;
    int numofunlocklevels;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            numofunlocklevels = PlayerPrefs.GetInt("levelIsUnlocked");
            if(numofunlocklevels <= LevelToUnlock){
                PlayerPrefs.SetInt("levelIsUnlocked", numofunlocklevels+1);
            }
        }

    }
}
