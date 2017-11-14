using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

	public Transform inicio;
	public Transform final;
	public float velocidade = 1.0F;
	private float comecarTempo;
	private float tamanhoCaminho;

	private bool chegouPorta;
	bool voltar = false;

	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		comecarTempo = Time.time;
		tamanhoCaminho = Vector3.Distance(inicio.position, final.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Jogador.abrirPorta) {
			float distCovered = (Time.time - comecarTempo) * velocidade;
			float fracJourney = distCovered / tamanhoCaminho;
			transform.position = Vector3.Lerp(inicio.position, final.position, fracJourney);
			coroutine = tempoAbrirPorta();
			StartCoroutine(coroutine);
			if (voltar == true) {
				transform.position = Vector3.Lerp(final.position, inicio.position, fracJourney);
				Jogador.abrirPorta = false;
			}
		}
	}

	private IEnumerator tempoAbrirPorta(){
		while (chegouPorta) {
			yield return new WaitForSeconds (5f);
			chegouPorta = false;
			voltar = true;
		}
	}
}