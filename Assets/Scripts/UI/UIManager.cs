using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject currentMainPanel;
    public ItemContextMenu currentContextMenu;

    private void Awake()
    {
        Instance = this;
    }

    // MAIN PANELS (inventory, character, ecc.)
    public void OpenMainPanel(GameObject panel)
    {
        CloseContextMenu();

        if (currentMainPanel != null)
            currentMainPanel.SetActive(false);

        panel.SetActive(true);
        currentMainPanel = panel;
    }

    public void CloseMainPanel()
    {
        if (currentMainPanel != null)
        {
            currentMainPanel.SetActive(false);
            currentMainPanel = null;
        }
    }

    // CONTEXT MENU
    public void OpenContextMenu(ItemContextMenu menu)
    {
        if (currentContextMenu != null && currentContextMenu != menu)
            currentContextMenu.Close();

        currentContextMenu = menu;
    }

    public void CloseContextMenu()
    {
        if (currentContextMenu != null)
        {
            currentContextMenu.Close();
            currentContextMenu = null;
        }
    }
}