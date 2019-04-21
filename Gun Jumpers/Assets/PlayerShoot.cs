using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    public PlayerWeapon weapon;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;

    private const string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuScript.isOn)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Local client call, only called on the client doing the shooting so the local player
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

    // Method on server, give player id and display which player has been shot
    [Command]
    void CmdPlayerShot(string playerID, int damage)
    {
        //Debug.Log(playerID + " has been shot.");

        PlayerManager player = GameManager.GetPlayer(playerID);
        player.RpcTakeDamage(damage);
    }
}
