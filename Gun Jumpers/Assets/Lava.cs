using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Lava : NetworkBehaviour
{
    float timeColliding;
    float timeThreshold = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered");
            timeColliding = 0f;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Staying: " + timeColliding);
            if(timeColliding < timeThreshold)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                CmdlavaDamage(other.name, 5);
                Debug.Log(other.name + " Take Damage");
                timeColliding = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            Debug.Log("Left");
    }

    /*
    [Client]
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            // We hit a player
            if (hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(hit.collider.name, weapon.damage);
            }
        }
    }
    */

    // Method on server, give player id and display which player has been shot
    [Command]
    void CmdlavaDamage(string playerID, int damage)
    {
        //Debug.Log(playerID + " has been shot.");

        PlayerManager player = GameManager.GetPlayer(playerID);
        player.RpcTakeDamage(damage);
    }

}
