using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    private int nextSceneToLoad;
    private int sceneToLoad;

    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField]
    private float FlickeringTimer;

    [SerializeField]
    private int PlayerHp;

    [SerializeField]
    private Image _livesSprite;

    [SerializeField]
    private Sprite[] _playerLivesList;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState obj)
    {

    }

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchScenes();
        //Testing HP 
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (PlayerHp <= 0)
            {
                GameOverSequence();
                StartCoroutine(LoadLevelAfterDelay(5.0f));
            }
            PlayerHp -= 1;
        }
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
                UpdateLives(PlayerHp);
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
            GameOverSequence();
            StartCoroutine(LoadLevelAfterDelay(5.0f));
        }
    }

    void GameOverSequence()
    {
        StartCoroutine(FlickeringGameOverPanel());
    }

    IEnumerator FlickeringGameOverPanel()
    {
        while (true)
        {
            _gameOverPanel.gameObject.SetActive(true);
            yield return new WaitForSeconds(FlickeringTimer);
            _gameOverPanel.gameObject.SetActive(false);
            yield return new WaitForSeconds(FlickeringTimer);
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //This Should Be Changed To 0 (MainMenu) For Final Build
        SceneManager.LoadScene(1);
    }
}
