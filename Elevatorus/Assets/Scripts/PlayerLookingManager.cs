/**
 * This class will allow the player to look around with the mouse.
 * Meant to be attached to the player's head/camera.
 *
 * @author Greggory Hickman
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingManager : MonoBehaviour
{
    public float mouseSensitivity;

    public float horiz, vert;

    public GameObject feet;

	// Start is called before the first frame update
	void Start()
    {
		horiz = 0;
        vert = 0;
	}

    // Update is called once per frame
    void Update()
    {
		//Mouse look
		horiz += mouseSensitivity * Input.GetAxis("Mouse X");
		vert -= mouseSensitivity * Input.GetAxis("Mouse Y");

		//Prevent the in-game player from breaking their neck
		if (vert >= 85)
            vert = 85f;
        if (vert <= -85)
            vert = -85f;

		transform.eulerAngles = new Vector3(vert, horiz, 0.0f);
        feet.transform.eulerAngles = new Vector3(0, horiz, 0.0f);
    }
}
