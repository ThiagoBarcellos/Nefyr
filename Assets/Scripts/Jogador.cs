﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour {

	public Rigidbody2D rb2d;
	public bool podePular;
	public float velocidade = 5f;
	private SpriteRenderer sR;
	public bool irFaseDois = false;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		podePular = false;
		sR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -4.269f){
			this.transform.position = new Vector2(-4.269f, -1.0487f);	
		}	
		if(this.transform.position.x > 10.6f){
			this.transform.position = new Vector2(10.6f, -1.0487f);	
		}

		float andar = Input.GetAxis("Horizontal") * velocidade;
		this.transform.position += new Vector3(andar, 0) * Time.deltaTime;
		if (podePular == true && Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (Vector2.up * 4, ForceMode2D.Impulse);
		}
		bool flipSprite = (sR.flipX ? (andar > 0.01f) : (andar < 0.01f));
		if (flipSprite) 
		{
			sR.flipX = !sR.flipX;
		}

		if (irFaseDois == true & Input.GetKey(KeyCode.W) || irFaseDois == true & Input.GetKey(KeyCode.UpArrow)) {
			SceneManager.LoadScene ("Biblioteca");
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "biblioteca") {
			irFaseDois = true;
		}
		else {
			podePular = true;
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "biblioteca") {
			irFaseDois = true;
		}
		else {		
			podePular = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (coll.tag == "biblioteca") {
			irFaseDois = false;
		}
		else {
			podePular = false;
		}
	}
}