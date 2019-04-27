using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    static float _oxygen = 1f;

    [SerializeField] Image _progressbar;

    public static float CurrentOxygen
    {
        get
        {
            return _oxygen;
        }
    }

    void Update()
    {
        _progressbar.fillAmount = _oxygen;

        if (Input.GetKeyDown(KeyCode.Escape)) { _oxygen = 0f; }
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

    public static void ResetOxygen()
    {
        _oxygen = 1f;
    }
}