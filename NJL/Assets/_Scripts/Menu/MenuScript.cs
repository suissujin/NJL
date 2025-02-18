using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject OptionMenu;
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OptionsButton()
    {
        OptionMenu.SetActive(true);
    }
    public void QuitButton()
    {
        Debug.Log("I Quit");
        Application.Quit();
    }
}
