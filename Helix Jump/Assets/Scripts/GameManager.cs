using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private int score;
    public Text scoreText;
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            score = 0;
        }
        else if (currentSceneIndex == 2)
        {
            score = 1000;
        }
        else if (currentSceneIndex == 3)
        {
            score = 2000;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }

        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
            {
                OpenPanel();
            }

            else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
            {
                ClosePanel();

            }
        }
    }
    public void IncreaseGameScore(int ringScore)
    {
        score += ringScore;
        scoreText.text = score.ToString();
    }


    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetLevels()
    {
        ClosePanel();
        SceneManager.LoadSceneAsync(1);
    }


    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                ThemeSong.instance.StopMusic();

            }

            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void MainMenu()
    {
        ClosePanel();
        SceneManager.LoadSceneAsync(0);
    }


    public void OpenPanel()
    {
        if (PauseMenu != null)
        {
            ThemeSong.instance.PauseMusic();
            PauseMenu.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void ClosePanel()
    {
        if (PauseMenu != null)
        {
            ThemeSong.instance.PlayMusic();
            PauseMenu.SetActive(false);
            Time.timeScale = 1;

        }
    }

}
