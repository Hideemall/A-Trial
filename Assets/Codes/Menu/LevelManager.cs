using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    int unlockedLevelNumber;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("levelIsUnlocked"))
        {
            PlayerPrefs.SetInt("levelIsUnlocked", 1);
        }

        unlockedLevelNumber = PlayerPrefs.GetInt("levelIsUnlocked");

        for (int i = 0; i < levelButtons.Length; i++)
        {
                levelButtons[i].interactable = false;
        }
    }

    private void Update()
    {
        unlockedLevelNumber = PlayerPrefs.GetInt("levelIsUnlocked");
        for(int i=0; i<unlockedLevelNumber; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

}