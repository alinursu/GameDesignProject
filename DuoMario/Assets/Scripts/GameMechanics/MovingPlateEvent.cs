using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateEvent : MonoBehaviour
{
    public float finalPositionXOffset = 1f;

    public float speed = 0.01f;

    private Vector3 initialPosition;

    private Vector3 finalPosition;

    private string direction;

    private bool changedDirection = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

        Vector3 offsetVector = new Vector3(finalPositionXOffset, 0, 0);

        finalPosition = initialPosition + offsetVector;

        if (finalPositionXOffset > 0)
        {
            direction = "right";
        }
        else
        {
            direction = "left";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 previousPosition = transform.position;
        
        if (direction == "right")
        {
            transform.position += new Vector3(speed, 0, 0);
            
            float xInitial = finalPositionXOffset > 0 ? finalPosition.x : initialPosition.x;
            
            if ((transform.position.x >= finalPosition.x || PositionsAreEqual(previousPosition, transform.position)) && !changedDirection)
            {
                direction = "left";
                changedDirection = true;
            }
            else
            {
                changedDirection = false;
            }
        }
        
        if (direction == "left")
        {
            transform.position -= new Vector3(speed, 0, 0);

            float xInitial = finalPositionXOffset > 0 ? initialPosition.x : finalPosition.x;

            if ((transform.position.x <= xInitial || PositionsAreEqual(previousPosition, transform.position)) && !changedDirection)
            {
                direction = "right";
                changedDirection = true;
            }
            else
            {
                changedDirection = false;
            }
        }
    }

    private bool PositionsAreEqual(Vector3 position1, Vector3 position2)
    {
        return position1.x == position2.x && position1.y == position2.y && position1.z == position2.z;
    }
}
