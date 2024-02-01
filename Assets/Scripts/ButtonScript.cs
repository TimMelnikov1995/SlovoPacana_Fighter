using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    internal GameObject _previousScreen;



    public static void OnPlayClick()
    {
        UIManager.Instance.PlayMenuChoose();
        UIManager.Instance.ChangeScreen(UIManager.Instance.ArenaSelectionScreen);
    }
    
    public static void OnRestartClick()
    {
        UIManager.Instance.PlayMenuChoose();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void OnMainMenuClick()
    {
        UIManager.Instance.PlayMenuBack();
        SceneManager.LoadScene(NamesTags.MAIN_MENU_SCENE);
    }

    public static void OnExitClick()
    {
        UIManager.Instance.PlayMenuBack();
        Application.Quit();
    }

    public static void LoadArena(string scene_name)
    {
        UIManager.Instance.PlayMenuChoose();
        SceneManager.LoadScene(scene_name);
    }



    public static void OnSettingsClick()
    {
        UIManager.Instance.PlayMenuTransit();

        if (UIManager.Instance.MainMenuScreen != null)
            UIManager.Instance.ChangeScreen(UIManager.Instance.SettingsScreen);
        else
            GameManager.Instance.ChangeScreen(GameManager.Instance.SettingsScreen, true);
    }

    public static void OnBackClick()
    {
        UIManager.Instance.PlayMenuTransit();

        if (UIManager.Instance.MainMenuScreen != null)
            UIManager.Instance.ChangeScreen(UIManager.Instance.MainMenuScreen);
        else
            GameManager.Instance.ChangeScreen(GameManager.Instance.PauseScreen, true);
    }



    public static void OnRulesClick()
    {
        UIManager.Instance.PlayMenuTransit();
        UIManager.Instance.ChangeScreen(UIManager.Instance.RulesScreen);
    }

    public static void OnCreditsClick()
    {
        UIManager.Instance.PlayMenuTransit();
        UIManager.Instance.ChangeScreen(UIManager.Instance.CreditsScreen);
    }



    public static void OnResumeClick()
    {
        UIManager.Instance.PlayMenuTransit();
        GameManager.Instance.ChangeScreen(GameManager.Instance.GameScreen, false);
    }



    public static void OnCreditsNameClick(string link)
    {
        Application.OpenURL(link);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        //CursorManager.Instance.SetHandCursor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //CursorManager.Instance.SetStandartCursor();
    }
}
