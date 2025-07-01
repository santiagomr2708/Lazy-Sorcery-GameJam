using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    public void PlayButtonRestart()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
