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
    
    public void ChangeSceneOnLose()
    {
        Debug.Log("Actual level is: " + LevelPersistentData.getActualLevel());
        Destroy (GameObject.Find ("Canvas"));
        SceneManager.LoadScene(LevelPersistentData.getActualLevel());
    }

    public static void StaticChangeSceneOnLose()
    {
        Debug.Log("Actual level is: " + LevelPersistentData.getActualLevel());
        SceneManager.LoadScene(LevelPersistentData.getActualLevel());
    }
    
    public void ChangeSceneOnWin()
    {
        LevelPersistentData.goToNextLevel();
        Debug.Log("Next level is: " + LevelPersistentData.getActualLevel());
        
        Destroy (GameObject.Find ("Canvas"));
        SceneManager.LoadScene(LevelPersistentData.getActualLevel());
    }
    
    public static void StaticChangeSceneOnWin()
    {
        LevelPersistentData.goToNextLevel();
        Debug.Log("Next level is: " + LevelPersistentData.getActualLevel());
        SceneManager.LoadScene(LevelPersistentData.getActualLevel());
    }
}
