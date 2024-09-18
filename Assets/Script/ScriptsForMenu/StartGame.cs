using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn1 : MonoBehaviour
{
    public void OnMouseBtn()
    {
        SceneManager.LoadScene(1);
    }
}
