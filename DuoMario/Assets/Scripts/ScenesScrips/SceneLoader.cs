using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Destroy(GameObject.Find("Canvas"));
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}