using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject ItemPrefab;
    public Player Player;

    List<UpgradeItemUI> _buttons = new List<UpgradeItemUI>();

    void Start()
    {
        _buttons.Add(null);
        for (var i = 0; i < Player.GetMaxHulls() - 1; ++i)
        {
            var btn = GameObject.Instantiate(ItemPrefab, transform).GetComponent<UpgradeItemUI>();
            btn.SetText((i + 1).ToString());
            btn.SetProgress(0);
            _buttons.Add(btn);
        }
    }

    void Update()
    {
        // Sawp hull
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapHull(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapHull(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapHull(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwapHull(4);
        }

        // Update progress
        if (Player.CurrentHull.HullIndex > 0)
        {
            _buttons[Player.CurrentHull.HullIndex].SetProgress(Player.CurrentHull.GetLifetime());

            if (Player.CurrentHull.GetLifetime() <= 0)
            {
                SwapHull(0);
            }
        }
    }

    void SwapHull(int index)
    {
        Player.SwapHull(index);
        foreach (var btn in _buttons)
        {
            if (btn != null)
            {
                btn.SetProgress(0);
            }
        }
    }
}