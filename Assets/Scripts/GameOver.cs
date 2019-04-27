//(We have nothing to lose but our chains)
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Player player;
    public GameObject GameOverText;
    void Update()
    {
        //Game Over Text och Omstart 
        GameOverText.SetActive(player==null);
      if (player == null)
        {

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Oxygen.ResetOxygen();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Oxygen.ResetOxygen();
                SceneManager.LoadScene(0);
            }
        }  
    }
}
