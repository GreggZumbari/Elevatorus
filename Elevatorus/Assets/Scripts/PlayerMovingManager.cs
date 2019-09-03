/**
 * This class, when attached to a gameobject, will allow it to be moved with WASD.
 * Meant to be attached to the main player gameobject.
 * 
 * @author Greggory Hickman, Zoe Rego
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingManager : MonoBehaviour
{
    public float speed;
    public float jumpMagnitude;
    public float sprintMultiplier;
    public int multiJumpLimit; //Number of jumps in between rests
	public bool midAir;

    public GameObject head;

    private float sprint;
    private int jumps;
    private float vSpeed;
    private float dSpeed;

    void Start()
    {
        sprint = 1f;
        jumps = 0;
        vSpeed = speed;
        dSpeed = speed * 0.70710678118f;
    }
    
    void Update()
    {
        //Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
            sprint = sprintMultiplier;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            sprint = 1f;

        //Horizontal speed correction
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            speed = dSpeed;
        else
            speed = vSpeed;

        //WASD controls
        if (Input.GetKey(KeyCode.W))
            transform.Translate(
                new Vector3(head.GetComponent<Transform>().rotation.y,
                0,
                head.GetComponent<Transform>().forward.z)
                * Time.deltaTime * speed * sprint);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(
                new Vector3(-(head.GetComponent<Transform>().forward.x),
                0,
                -(head.GetComponent<Transform>().forward.z)) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-head.GetComponent<Transform>().right * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(head.GetComponent<Transform>().right * Time.deltaTime * speed);

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && jumps < multiJumpLimit)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpMagnitude, 0);
            jumps++;
        }
		if (!midAir)
			jumps = 0;
    }
}
