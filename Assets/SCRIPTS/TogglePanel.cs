using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel;
   

    public void Toggle()
    {
        if (panel != null)
        {
            UIManager.Instance.ReverseMove();
            panel.SetActive(!panel.activeSelf);
        }
    }
}
