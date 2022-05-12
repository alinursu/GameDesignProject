using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerWhenOnPlatform : MonoBehaviour
{
    private GameObject target=null;
    public Vector3 offset;
    
    void Start(){
        target = null;
    }
    
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name.Contains("Character"))
        {
            target = col.gameObject;
            offset = target.transform.position - transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Character")) {
            target = null;
        }
    }

    void LateUpdate(){
        if (target != null) {
            target.transform.position = transform.position+offset;
        }
    }
}
