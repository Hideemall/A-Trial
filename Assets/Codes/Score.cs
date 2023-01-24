using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   
    public static Score instance;
    public Text text;
    int points;

    void Start()
    {
        if(instance==null)
        {
            instance=this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        points+=coinValue;
        text.text=points.ToString();
    }
 
}
