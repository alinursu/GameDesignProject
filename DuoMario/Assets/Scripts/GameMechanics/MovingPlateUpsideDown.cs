using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateUpsideDown : MonoBehaviour
{
    public GameObject targetWall;
    
    private int rotations = 0;
    
    private void moveWallUp() {
        targetWall.transform.position = new Vector3(1.595f, 6.73f, 0);
        targetWall.transform.Rotate(new Vector3(0, 0, 50));
        rotations--;
    }
    
    private void moveWallDown() {
        targetWall.transform.position = new Vector3(1.13f, 6.73f, 0);
        targetWall.transform.Rotate(new Vector3(0, 0, -50));
        rotations++;
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
        if (other.gameObject.tag.Contains("Character") && rotations == 0)
        {
            // Pressure plate is pressed
            moveWallDown();
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        // Pressure plate is released
        if (rotations == 1)
        {
            moveWallUp();
        }
    }
}
