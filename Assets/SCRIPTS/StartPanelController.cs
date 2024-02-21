using UnityEngine;

public class StartPanelController : MonoBehaviour
{
    public GameObject panel; // Ссылка на панель
    

    void Start()
    {
        UIManager.Instance.ReverseMove();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        UIManager.Instance.ReverseMove();
        panel.SetActive(false);
    }
}
