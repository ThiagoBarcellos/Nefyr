using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHud : MonoBehaviour {

	public Jogador jogador;
	public int maxHealth = 100;
	public int currHealth;

	void awake(){
		currHealth = maxHealth;
	}

	public void OnHealthChange()
	{
	}


	private void Update()
	{
		OnHealthChange ();
	}
}
