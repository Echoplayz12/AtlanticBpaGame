using UnityEngine.SceneManagement;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public void SceneChanger(int sceneName)
    {
        SceneManager.LoadScene(1);
    }
}
