using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Для загрузки сцен
using System.Collections.Generic;

public class CatsClick : MonoBehaviour
{
    public GameObject catsParticle;
    
   

   
    public Text winMessage; // Текст сообщения на панели
    public bool wasClicked = false;
    public Sprite catSprite;

  


    void Start()
        {
            UIManager.Instance.allCats.Add(this); // Добавление этого кота в список
        }
    public void OnMouseDown() 
    {
        if(!wasClicked)
        {
            wasClicked = true;
            GetComponent<SpriteRenderer>().sprite = catSprite;
            UIManager.Instance.AddCat();
            UIManager.Instance.UpdateUI();
            SoundManager.Instance.PlayRandomSounds();
            GameObject particle = Instantiate(catsParticle, transform.position, transform.rotation);
            Destroy(particle, 2f);
            UIManager.Instance.WinCheck();

           
           
        }
    }

   
   

    public void LoadNextLevel()
    {
        // Загрузка следующего уровня
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
