using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWallOnEvent : MonoBehaviour
{
    public GameObject targetWall;
    public int degrees = 0;
    
    private int rotations = 0;
    
    private void rotateBack() {
        targetWall.transform.Rotate(new Vector3(0, 0, degrees));
        rotations--;
    }
    
    private void rotate() {
        targetWall.transform.Rotate(new Vector3(0, 0, -degrees));
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
            rotate();
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        // Pressure plate is released
        if (rotations == 1)
        {
            rotateBack();
        }
    }
}
