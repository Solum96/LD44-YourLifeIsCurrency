using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    static float _oxygen = 1f;
    Image _progressbar;
    public static float CurrentOxygen
    {
        get
        {
            return _oxygen;
        }
    }


    void Awake()
    {
        _progressbar = GetComponent<Image>();
    }
    void Update()
    {
        _progressbar.fillAmount = _oxygen;
    }
    public static void AddOxygen(float value)
    {
        _oxygen += value;
        _oxygen = Mathf.Clamp01(_oxygen);
    }
    public static void RemoveOxygen(float value)
    {
        _oxygen -= value;
        _oxygen = Mathf.Clamp01(_oxygen);
    }
}
