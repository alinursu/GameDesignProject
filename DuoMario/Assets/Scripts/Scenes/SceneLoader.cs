using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {   
        Destroy (GameObject.Find ("Canvas"));
        SceneManager.LoadScene(sceneName);
    }
    
    public static void StaticChangeScene(string sceneName)
    {   
        SceneManager.LoadScene(sceneName);
    }
}
