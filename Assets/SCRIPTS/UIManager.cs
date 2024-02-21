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
   catCountText.text = $"Найдено котиков: {catsCount}/30";
}

public void WinCheck()
{
    if(catsCount>=CatToWin)
    {
        winPanel.SetActive(true);
    }
}

 public  void ClickRandomCat()
    {
        if (allCats.Count > 0)
        {
            int randomIndex = Random.Range(0, allCats.Count); // Выбор случайного индекса
            CatsClick randomCat = allCats[randomIndex];

            // Вызов метода OnMouseDown для случайного кота
            randomCat.OnMouseDown();
        }
    }
}
