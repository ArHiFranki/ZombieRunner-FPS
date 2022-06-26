using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(OnRestartButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(OnRestartButtonClick);
        exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnRestartButtonClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnExitButtonClick()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
