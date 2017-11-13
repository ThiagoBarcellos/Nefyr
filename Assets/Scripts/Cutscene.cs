using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

	public GameObject cutsceneCamera;
	Vector3 local;
	Vector3 ir;

	// Use this for initialization
	void Start () {
		local = cutsceneCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Jogador.abrirPorta) {
			//Time.timeScale = 0;
			//ir.Lerp()
		}
	}
}
