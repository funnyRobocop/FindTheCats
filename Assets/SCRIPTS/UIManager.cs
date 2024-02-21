using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Text catCountText;
    public int catsCount = 0;
    public int CatToWin = 10;
    public GameObject winPanel;

    public Animator winPanelAnimator;

    public Vector3 winPosition;

    public Camera _camera;
    
    public int cameraSize;

    public bool wasStarted = false;

    public CameraDrag cameraDrag;
     public  List<CatsClick> allCats = new List<CatsClick>(); // Список всех котов

    
private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 


}
private void Start() 
{
UpdateUI();
    
}
public void ReverseMove()
{
    if (cameraDrag!=null)
    {
        cameraDrag.CanMove = !cameraDrag.CanMove;
    }
}
public void AddCat()
{
  catsCount++;
}
public void UpdateUI()
{
   catCountText.text = $"Найдено котиков: {catsCount}/{CatToWin}";
}

public void WinCheck()
{
    if(catsCount>=CatToWin)
    {
        winPanel.SetActive(true);
        winPanelAnimator.SetTrigger("isHide");
        _camera.orthographicSize = cameraSize;
        _camera.transform.position = winPosition;
        cameraDrag.enabled = false;
        SoundManager.Instance.PlayShot(SoundManager.Instance.winSound);
    }
}

 public  void ClickRandomCat()

    {
        if(wasStarted)
        {

        
        if(catsCount!=CatToWin)
        {
        if (allCats.Count > 0)
        {
            int randomIndex = Random.Range(0, allCats.Count); // Выбор случайного индекса
            CatsClick randomCat = allCats[randomIndex];

            for(int i = 0; i< allCats.Count; i++)
            {
                if(allCats[i].wasClicked == false)
                {
                    allCats[i].OnMouseDown();
                    randomCat = allCats[i];
                    break;
                }
            }

            
            if(catsCount!=CatToWin)
            {
            _camera.transform.position = new Vector3(randomCat.transform.position.x,randomCat.transform.position.y, -10);
            }
        }
        }
        }
    }
}
