using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject RegisterPanel;

    public Button LoginButton;
    public Button RegisterButton;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(LoginPlayer);
        RegisterButton.onClick.AddListener(RegisterPlayer);

    }
    public void LoginPlayer()
    {
        Debug.Log("Is Login");
        LoginPanel.SetActive(true);
    }

    public void RegisterPlayer()
    {
        Debug.Log("Is Register");
        RegisterPanel.SetActive(true);
    }
}
