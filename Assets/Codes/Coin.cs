using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip CoinSound;
    public int coinValue=1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(CoinSound);
            Score.instance.ChangeScore(coinValue);
        }
    }

}
