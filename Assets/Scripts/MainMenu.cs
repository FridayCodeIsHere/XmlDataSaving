using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public delegate void MainMenuEvent();
    public static MainMenuEvent OnCreateLevel;
    public static MainMenuEvent OnLoadLevel;

    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _panelMenu;

    private void OnEnable()
    {
        OnCreateLevel += HideMenu;
        OnLoadLevel += HideMenu;
    }

    private void OnDisable()
    {
        OnCreateLevel -= HideMenu;
        OnLoadLevel -= HideMenu;
    }

    public void ShowMenu()
    {
        _camera.SetActive(true);
        _panelMenu.SetActive(true);
    }

    public void HideMenu()
    {
        _camera.SetActive(false);
        _panelMenu.SetActive(false);
    }

}
