using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReadInst()
    {
        SceneManager.LoadScene(2);
    }
}
