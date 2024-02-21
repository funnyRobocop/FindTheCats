using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Получение текущей активной сцены и её индекса
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

       
        if( currentSceneIndex<4)
        
             {SceneManager.LoadScene(currentSceneIndex + 1);
             }
             else 
             {SceneManager.LoadScene(0);
             }
        
        
    }
}
