using UnityEngine.SceneManagement;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public void SceneChanger(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
