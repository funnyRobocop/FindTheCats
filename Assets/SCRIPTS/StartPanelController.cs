using UnityEngine;

public class StartPanelController : MonoBehaviour
{
    public GameObject panel; // Ссылка на панель
    public GameObject settingsPanel;
    

    void Start()
    {
        UIManager.Instance.ReverseMove();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        UIManager.Instance.wasStarted = true;
        UIManager.Instance.ReverseMove();
        panel.SetActive(false);
        settingsPanel.SetActive(false);
    }
}
