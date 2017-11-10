using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {

	public int health = 2;

	public Rigidbody2D rb2d;
	public bool podePular;
	public float velocidade = 3f;
	private SpriteRenderer sR;
	public bool irFaseDois = false;

	// 0 para rua, 1 pra biblioteca...
	static public int fase = 0;

	public GameObject botao;
	public GameObject livro;
	public GameObject interagivel;

	public GameObject botaoSubir;
	public GameObject interagivelSubir;

	public GameObject botaoDescer;
	public GameObject interagivelDescer;

	public GameObject porta;

	static public bool abrirPorta = false;
	static public bool proximaCena = false;

	public bool mudarAndar;

	public void TomaDano( int dano )
	{
		health -= dano;
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		podePular = false;
		sR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x < -4.269f){
			this.transform.position = new Vector2(-4.269f, this.transform.position.y);	
		}	
		/*if (!proximaCena) {
			if (MovimentoCamera.floor == 0) {
				if (this.transform.position.x > 10.4f) {
					this.transform.position = new Vector2 (10.4f, this.transform.position.y);	
				}
			}
		}*/
		//if(proximaCena) {
			if (this.transform.position.x > 28f) {
				this.transform.position = new Vector2 (28f, this.transform.position.y);	
			}
		//}

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
			fase = 1;
		}
		if (mudarAndar == true & MovimentoCamera.floor == 0 & Input.GetKey (KeyCode.W) || mudarAndar == true & MovimentoCamera.floor == 0 & Input.GetKey (KeyCode.UpArrow)) {
			MovimentoCamera.floor = 1;
			this.transform.position = new Vector2(10.6f, 2.643f);
		}
		if (mudarAndar == true & MovimentoCamera.floor == 1 & Input.GetKey (KeyCode.S) || mudarAndar == true & MovimentoCamera.floor == 1 & Input.GetKey (KeyCode.DownArrow)) {
			MovimentoCamera.floor = 0;
			this.transform.position = new Vector2(10.6f, -1.0487f);
		}
		if (botao.activeSelf & Input.GetKey (KeyCode.E)) {
			livro.SetActive(false);
			interagivel.SetActive (false);
			abrirPorta = true;
		}
		if (abrirPorta) {
			porta.transform.Translate (new Vector2 (0f, -0.1f));
			if (porta.transform.position.y < -2.58) {
				abrirPorta = false;
				proximaCena = true;
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "biblioteca") {
			irFaseDois = true;
		} 
		else if (coll.tag == "Escada") {
			mudarAndar = true;
		} 
		else if (coll.tag == "Interagivel") {
			botao.SetActive (true);
		} 
		else if (coll.tag == "Subir") {
			botaoSubir.SetActive (true);
		}
		else if (coll.tag == "Descer") {
			botaoDescer.SetActive (true);
		}
		else {
			podePular = true;
			botao.SetActive (false);
			botaoSubir.SetActive (false);
			botaoDescer.SetActive(false);
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "biblioteca") {
			irFaseDois = true;
		}
		else if (coll.tag == "Escada") {
			mudarAndar = true;
		}
		else if (coll.tag == "Interagivel") {
			botao.SetActive (true);
		}
		else if (coll.tag == "Subir") {
			botaoSubir.SetActive (true);
		} 
		else if (coll.tag == "Descer") {
			botaoDescer.SetActive (true);
		}
		else if (coll.tag == "Porta" & abrirPorta == true & Input.GetKey(KeyCode.E)) {
			Debug.Log ("Ganhou");
		}
		else {		
			podePular = true;
		}
	}

	void OnTriggerExit2D (Collider2D coll){
		if (coll.tag == "biblioteca") {
			irFaseDois = false;
		} 
		else if (coll.tag == "Escada") {
			mudarAndar = false;
		} 
		else {
			podePular = false;
			botao.SetActive (false);
			botaoSubir.SetActive (false);
			botaoDescer.SetActive (false);
		}
	}
}