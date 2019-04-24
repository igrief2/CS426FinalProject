using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
	[SerializeField] PlayerManager playerM;
	[SerializeField] PlayerController playerC;
	[SerializeField] TextMeshProUGUI Ammo;
	[SerializeField] TextMeshProUGUI Health;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenuScript.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
		UpdateAmmo(playerC.GetGun().GetAmmo());
		UpdateHealth(playerM.GetHealth());
    }

    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenuScript.isOn = pauseMenu.activeSelf;
    }

	public void SetPlayerController(PlayerController p){
		playerC = p;

	}
	public void SetPlayerManager(PlayerManager p){
		playerM = p;
	}

	void UpdateAmmo(int ammo){
		Ammo.text = "Ammo: " + ammo;
	}
	void UpdateHealth(int health){
		Health.text = "Health: " + health;
	}

}
