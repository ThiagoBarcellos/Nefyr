using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHud : MonoBehaviour {

	public Jogador jogador;
	public Image[] healthImages;

	public void OnHealthChange()
	{
		for (int i = 0; i < healthImages.Length; i++) {
			healthImages [i].enabled = i < jogador.health;
		}
	}


	private void Update()
	{
		OnHealthChange ();
	}
}
