using System.Collections;
using UnityEngine;

public class PressurePlateMoveWallEvent : MonoBehaviour
{
    public GameObject targetWall;
	private int framesToWait;

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
		framesToWait = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(framesToWait > 0) {
			framesToWait--;
		}
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Character") && framesToWait == 0)
        {
            // Pressure plate is pressed
			moveWallUp();
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        // Pressure plate is released
        moveWallDown();

		if(framesToWait == 0){
			framesToWait = 30;
		}
    }
}
