using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPersistentData : MonoBehaviour
{
    public static LevelPersistentData instance;

	public string actualLevel;
    
    private void Awake() {
    	if (instance != null) {
			Destroy(gameObject);
			return;
		}
    
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        actualLevel = "SampleScene";
    }

    public static string getActualLevel() {
		return instance.actualLevel;
	}

	public static void goToNextLevel() {
		string actualLevel = instance.actualLevel;

		if(actualLevel == "SampleScene") {
			instance.actualLevel = "Level2";
			return;
		}

		if(actualLevel == "Level2") {
			instance.actualLevel = "Level3";
			return;
		}

		if(actualLevel == "Level3") {
			instance.actualLevel = "Level4";
			return;
		}

		if(actualLevel == "Level4") {
			instance.actualLevel = "EndGame";
			return;
		}

		if(actualLevel == "Level4") {
			instance.actualLevel = "SampleScene";
			return;
		}
	}
}
