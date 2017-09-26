using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

	public Rigidbody2D rb2d;
	public bool podePular;
	public float velocidade = 5f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		podePular = false;
	}
	
	// Update is called once per frame
	void Update () {
		float andar = Input.GetAxis("Horizontal") * velocidade;
		this.transform.position += new Vector3(andar, 0) * Time.deltaTime;
		if (podePular == true && Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (Vector2.up * 3, ForceMode2D.Impulse);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		podePular = true;
	}

	void OnTriggerStay2D(Collider2D coll){
		podePular = true;
	}

	void OnTriggerExit2D(Collider2D coll){
		podePular = false;
	}
}