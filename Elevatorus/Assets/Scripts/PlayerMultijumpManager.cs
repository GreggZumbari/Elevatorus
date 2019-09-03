/**
 * This class exists to notify the parent when the attached gameobject has touched the ground.
 * Meant to be attached to the player's feet.
 *
 * @author Greggory Hickman
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultijumpManager : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<PlayerMovingManager>().midAir = false;
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMovingManager>().midAir = true;
    }
}
