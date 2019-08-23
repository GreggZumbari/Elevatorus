/**
 * This class, when attached to a gameobject, will allow it to be moved with WASD
 * 
 * @author Greggory Hickman, Zoe Rego
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingManager : MonoBehaviour
{

    public float speed;
    public float sprintMultiplier;
    public float mouseSensitivity;

    private float sprint;
    private float yaw;
    private float pitch;

    void Start()
    {
        sprint = 1f;
        yaw = 0;
        pitch = 0;
    }
    
    void Update()
    {
        //WASD controls and sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
            sprint = sprintMultiplier;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            sprint = 1f;
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * speed * sprint);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * speed);

        //Mouse look
        yaw += mouseSensitivity * Input.GetAxis("Mouse X");
        pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");

        //Prevent the in-game player from breaking their neck
        if (pitch >= 90)
            pitch = 90f;
        if (pitch <= -90)
            pitch = -90f;

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
