using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private KeyCode MOVE_UP_KEY = KeyCode.W;
    private KeyCode MOVE_DOWN_KEY = KeyCode.S;
    private KeyCode MOVE_LEFT_KEY = KeyCode.A;
    private KeyCode MOVE_RIGHT_KEY = KeyCode.D;

    private float xAxisStep = 0.1f;

    private float yAxisStep = 6.5f;

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
        // TODO: This is for local co-op. Should be deleted when multiplayer is added.
        if (character.tag == "Character2")
        {
            MOVE_UP_KEY = KeyCode.UpArrow;
            MOVE_DOWN_KEY = KeyCode.DownArrow;
            MOVE_LEFT_KEY = KeyCode.LeftArrow;
            MOVE_RIGHT_KEY = KeyCode.RightArrow;
        }
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
        if (characterIsInAir == true)
        {
            characterIsInAir = false;
        }
    }
}
