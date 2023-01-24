using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public int coinValue=1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Score.instance.ChangeScore(coinValue);
        }
    }

}
