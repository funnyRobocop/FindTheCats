using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel;
   

    public void Toggle()
    {
        if (panel != null)
        {   if(UIManager.Instance!= null)
        {
            if(UIManager.Instance.wasStarted)
            {
                UIManager.Instance.ReverseMove();
            }}
            
            panel.SetActive(!panel.activeSelf);
        }
    }
}
