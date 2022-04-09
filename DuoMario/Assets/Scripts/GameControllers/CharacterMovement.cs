using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    private KeyCode MOVE_UP_KEY = KeyCode.W;
    private KeyCode MOVE_DOWN_KEY = KeyCode.S;
    private KeyCode MOVE_LEFT_KEY = KeyCode.A;
    private KeyCode MOVE_RIGHT_KEY = KeyCode.D;

	public float speedX = 5f;
	public float speedY = 8f;

	private Vector2 speed;

    public GameObject character;

    private bool characterIsInAir = false;

	private bool rotatedSprite = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
		speed = new Vector2(speedX, speedY);

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
		if (Input.GetKey(MOVE_UP_KEY) || Input.GetKey(MOVE_DOWN_KEY) || Input.GetKey(MOVE_LEFT_KEY) || Input.GetKey(MOVE_RIGHT_KEY)) {
			float inputX = Input.GetAxis("Horizontal");
			if(character.tag == "Character2" && rotatedSprite) {
				inputX *= -1;
			}

			float inputY = Input.GetAxis("Vertical");
		
			Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
			movement *= Time.deltaTime;

			character.transform.Translate(movement);
		}

		// TODO: Should work for Character1 too when sprite is changed.
		if (character.tag == "Character2") {
			if (Input.GetKey(MOVE_LEFT_KEY)) {
				rotatedSprite = true;
				character.transform.rotation = new Quaternion(character.transform.rotation.x, -180, character.transform.rotation.z, character.transform.rotation.w);
			}

			if (Input.GetKey(MOVE_RIGHT_KEY)) {
				rotatedSprite = false;
				character.transform.rotation = new Quaternion(character.transform.rotation.x, 0, character.transform.rotation.z, character.transform.rotation.w);
			}
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
