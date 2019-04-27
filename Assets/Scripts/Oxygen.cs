using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public Player player;
    Image _progressbar;


    void Awake()
    {
        _progressbar = GetComponent<Image>();
    }
    void Update()
    {
        _progressbar.fillAmount = player.Oxygen;
    }
    
}
