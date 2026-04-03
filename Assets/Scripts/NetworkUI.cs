using UnityEngine;
using Mirror;

public class NetworkUI : MonoBehaviour
{
    public NetworkManager networkManager;
    public GameObject uiPanel;
    public GameObject gameplayUI;

    void Start()
    {
        ShowUI();
    }

    public void Host()
    {
        networkManager.StartHost();
        HideUI();
    }

    public void Client()
    {
        networkManager.StartClient();
        HideUI();
    }

    public void Disconnect()
    {
        networkManager.StopHost();
        ShowUI();
    }

    void ShowUI()
    {
        uiPanel.SetActive(true);
        gameplayUI.SetActive(false);
    }

    void HideUI()
    {
        uiPanel.SetActive(false);
        gameplayUI.SetActive(true);
    }
}