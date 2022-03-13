using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private string MOVE_UP_KEY = "w";
    private string MOVE_DOWN_KEY = "s";
    private string MOVE_LEFT_KEY = "a";
    private string MOVE_RIGHT_KEY = "d";

    private float xAxisStep = 0.1f;

    private float yAxisStep = 5f;

    private float movementSpeed = 0.5f;

    public GameObject character;

    private bool characterIsInAir = false;

    private void MoveCharacterOnXAxis(float actualStep)
    {
        character.transform.position += new Vector3(actualStep * movementSpeed, 0, 0);
    }
    private void MoveCharacterOnYAxis(float actualStep)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 
            actualStep), ForceMode2D.Impulse);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(MOVE_UP_KEY))
        {
            if (!characterIsInAir)
            {
                characterIsInAir = true;
                MoveCharacterOnYAxis(yAxisStep); 
            }
        }
        else if (Input.GetKey(MOVE_DOWN_KEY))
        {
            MoveCharacterOnYAxis(-yAxisStep);
        }
        else if (Input.GetKey(MOVE_LEFT_KEY))
        {
            MoveCharacterOnXAxis(-xAxisStep);
        }
        else if (Input.GetKey(MOVE_RIGHT_KEY))
        {
            MoveCharacterOnXAxis(xAxisStep);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" && characterIsInAir == true)
        {
            characterIsInAir = false;
        }
    }
}
