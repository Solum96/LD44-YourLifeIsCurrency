using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemUI : MonoBehaviour
{
    public CanvasGroup MainGroup;
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

    public void SetCanAfford(bool canAfford)
    {
        MainGroup.alpha = canAfford ? 1f : 0.25f;
    }
}