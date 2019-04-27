using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemUI : MonoBehaviour
{
    public Image ProgressBar;
    public Text Text;

    public void SetText(string text)
    {
        Text.text = text;
    }

    public void SetProgress(float value)
    {
        ProgressBar.fillAmount = value;
    }
}