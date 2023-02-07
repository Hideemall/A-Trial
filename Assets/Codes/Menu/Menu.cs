using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int Scene;

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll ();
        Application.Quit();
        Debug.Log("quit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(Scene);
        }
    }
}
