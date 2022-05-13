using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlateDown : MonoBehaviour
{
    public GameObject targetWall;

    public float offsetY = 0f;
    
    private void moveWallUp() {
        targetWall.transform.position += new Vector3(0, offsetY, 0);
    }
    
    private void moveWallDown() {
        targetWall.transform.position -= new Vector3(0, offsetY, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Character"))
        {
            // Pressure plate is pressed
            moveWallDown();
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        // Pressure plate is released
        moveWallUp();
    }
}
