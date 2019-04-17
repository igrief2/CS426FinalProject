using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
	[SerializeField]
	RectTransform healthBar;

	[SerializeField]
	Text ammo;

	[SerializeField]
	GameObject pauseMenu;

	[SerializeField]
	GameObject scoreboard;

	private PlayerManager player;
	private Gun gun;

	public void SetPlayer (PlayerManager _player, Gun _gun)
	{
		player = _player;
		gun = _gun;
	}

	void Start ()
	{
		//	PauseMenu.IsOn = false;
	}

	void Update ()
	{
		SetHealthAmount(player.GetHealth());
		SetAmmoAmount(gun.GetAmmo());

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePauseMenu();
		}

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			scoreboard.SetActive(true);
		} else if (Input.GetKeyUp(KeyCode.Tab))
		{
			scoreboard.SetActive(false);
		}
	}

	public void TogglePauseMenu ()
	{
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		PauseMenu.IsOn = pauseMenu.activeSelf; 
	}

	void SetHealthAmount (float _amount)
	{
		healthBar.localScale = new Vector3(1f, _amount, 1f);
	}

	void SetAmmoAmount (int _amount)
	{
		ammo.text = _amount.ToString();
	}

}
