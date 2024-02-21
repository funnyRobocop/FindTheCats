using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Получение текущей активной сцены и её индекса
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Загрузка следующей сцены по индексу
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
