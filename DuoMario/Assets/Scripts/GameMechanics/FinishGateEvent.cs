using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGateEvent : MonoBehaviour
{
    private bool character1Arrived = false;
    private bool character2Arrived = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character1Arrived && character2Arrived)
        {
            Debug.Log("GAME OVER!");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Character1")
        {
            character1Arrived = true;
        }
        
        if (other.gameObject.tag == "Character2")
        {
            character2Arrived = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Character1")
        {
            character1Arrived = false;
        }
        
        if (other.gameObject.tag == "Character2")
        {
            character2Arrived = false;
        }
    }
}
