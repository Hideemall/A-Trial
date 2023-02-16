using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   
    public static Score instance;
    public Text pkttext;
    public int points=0;

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
        pkttext.text=points.ToString();
    }
 
}
