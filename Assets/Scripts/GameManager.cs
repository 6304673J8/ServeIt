using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int nextSceneToLoad;
    private int sceneToLoad;

    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private Image _livesSprite;

    [SerializeField]
    private Sprite[] _playerLivesList;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        SwitchScenes();
    }

    private void SwitchScenes()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        switch (sceneToLoad)
        { 
            case 0:
                if (Input.GetKeyDown(KeyCode.Space))
                    LoadInGameScene();
                break;
            case 1:
                UpdateLives(3);
                break;
        }
    }

    private void LoadInGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateLives(int currentLives)
    {
        _livesSprite.sprite = _playerLivesList[currentLives];
        if (currentLives == 0)
        {
            _gameOverPanel.gameObject.SetActive(true);
            LoadLevelAfterDelay(5.0f);
        }
    }

    void GameOverSequence()
    {
        _gameOverPanel.gameObject.SetActive(true);
        StartCoroutine(FlickeringGameOverPanel);
    }
    IEnumerator FlickeringGameOverPanel()
    { 
        while (_)
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
