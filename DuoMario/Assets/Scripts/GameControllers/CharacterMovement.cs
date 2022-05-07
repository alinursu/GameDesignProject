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

	private bool triggeredRunning = false;
	private bool triggeredJumping = false;
	private bool triggeredSliding = false;
    
    
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
		bool pressedUpKey = Input.GetKey(MOVE_UP_KEY);
		bool pressedDownKey = Input.GetKey(MOVE_DOWN_KEY);
		bool pressedLeftKey = Input.GetKey(MOVE_LEFT_KEY);
		bool pressedRightKey = Input.GetKey(MOVE_RIGHT_KEY);

		if (pressedUpKey || pressedDownKey || pressedLeftKey || pressedRightKey) {
			var animator = character.GetComponent<Animator>();

			if(pressedLeftKey || pressedRightKey) {
				// Trigger running animation
				if(!triggeredRunning) {
					animator.SetTrigger("IsRunning");
					animator.ResetTrigger("IsIdle");
					animator.ResetTrigger("IsJumping");
					animator.ResetTrigger("IsSliding");
					triggeredRunning = true;
					triggeredJumping = false;
					triggeredSliding = false;
				}
			}
			else if (pressedUpKey) {
				// Trigger jumping animation
				if(!triggeredJumping) {
					animator.SetTrigger("IsJumping");
					animator.ResetTrigger("IsRunning");
					animator.ResetTrigger("IsIdle");
					animator.ResetTrigger("IsSliding");
					triggeredRunning = false;
					triggeredJumping = true;
					triggeredSliding = false;
				}
			}
			else if (pressedDownKey) {
				// Trigger sliding animation
				if(!triggeredSliding) {
					animator.SetTrigger("IsSliding");
					animator.ResetTrigger("IsRunning");
					animator.ResetTrigger("IsIdle");
					animator.ResetTrigger("IsJumping");
					triggeredSliding = true;
					triggeredRunning = false;
					triggeredJumping = false;
				}
			}

			float inputX = Input.GetAxis("Horizontal");
			if(rotatedSprite) {
				inputX *= -1;
			}

			float inputY = Input.GetAxis("Vertical");
		
			Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
			movement *= Time.deltaTime;

			character.transform.Translate(movement);
		}
		else {
			// Trigger idle animation
			var animator = character.GetComponent<Animator>();
			animator.SetTrigger("IsIdle");
			animator.ResetTrigger("IsRunning");
			animator.ResetTrigger("IsJumping");
			animator.ResetTrigger("IsSliding");
			triggeredRunning = false;
			triggeredJumping = false;
			triggeredSliding = false;
		}

		if (pressedLeftKey) {
			rotatedSprite = true;
			character.transform.rotation = new Quaternion(character.transform.rotation.x, -180, character.transform.rotation.z, character.transform.rotation.w);
		}

		if (pressedRightKey) {
			rotatedSprite = false;
			character.transform.rotation = new Quaternion(character.transform.rotation.x, 0, character.transform.rotation.z, character.transform.rotation.w);
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
