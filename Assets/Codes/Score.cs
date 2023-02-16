using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text pkttext;
    public Text highscoretext;
    [SerializeField] int levelNumber;

    int points=0;
    int highscore=0;

    void Awake()
    {
        instance=this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore"  + levelNumber, 0);
        pkttext.text=points.ToString();
        highscoretext.text=highscore.ToString();
    }

    public void ChangeScore(int coinValue)
    {
        points+=coinValue;
        pkttext.text=points.ToString();
        if(highscore<points)
        {
            PlayerPrefs.SetInt("highscore" + levelNumber, points);
        }
    }

}