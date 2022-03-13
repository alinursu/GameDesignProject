using System.Collections;
using UnityEngine;

public class PressurePlateMoveWallEvent : MonoBehaviour
{
    public GameObject targetWall;

    private void moveWallUp()
    {
        var rigidBodyComponent = targetWall.GetComponent<Rigidbody2D>();
        
        targetWall.transform.position += new Vector3(0, 1f, 0);
        
        rigidBodyComponent.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
    }

    private void moveWallDown()
    {
        var rigidBodyComponent = targetWall.GetComponent<Rigidbody2D>();
        
        rigidBodyComponent.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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
            moveWallUp();
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        // TODO: [BUG] If a colission is made and it's not exited, the wall won't go down. (To replicate, do many 
        // collisions in a short time)
        
        // Pressure plate is released
        moveWallDown();
    }
}
