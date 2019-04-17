using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{

    [SerializeField] private int maxHealth = 100;

    // Each time variable is changed on server, value is pushed out to all clients
    [SyncVar] private int currentHealth;

    private void Awake()
    {
        SetDefaults();
    }
		
	public int GetHealth(){
		return currentHealth;
	}

    // Locally change current health and since it is a SyncVar, the server will update accross all clients
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " now has " + currentHealth + " health.");
    }

    public void SetDefaults()
    {
        currentHealth = maxHealth;
    }
}
