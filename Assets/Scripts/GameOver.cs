using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Player player;

    void Update()
    {
      if (player == null)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Oxygen.ResetOxygen();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
            }
        }  
    }
}
