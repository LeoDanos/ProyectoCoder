using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource music;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
        music.Stop();
    }

    public void Play2()
    {
        SceneManager.LoadScene(2);
        music.Stop();
    }

    public void Play3()
    {
        SceneManager.LoadScene(3);
        music.Stop();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
