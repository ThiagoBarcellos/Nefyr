using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {

	public MovimentoPlayer Mp;

	public int health = 2;

	private bool lendoHistoria = false;

	public GameObject Hud;

	public Rigidbody2D rb2d;
	public bool podePular;
	public float velocidade = 3f;
	private SpriteRenderer sR;
	public bool irFaseDois = false;

	public GameObject Puzzle;

	// 0 para rua, 1 pra biblioteca...
	static public int fase = 0;

	public GameObject botao;
	public GameObject livro;
	public GameObject interagivel;
	public bool PegueiLivro = false;

	public GameObject botaoCO;
	public GameObject CaixaO;
	public GameObject interagivelCaixaO;

	public GameObject botaoCP;
	public GameObject CaixaP;
	public GameObject interagivelCaixaP;

	public GameObject botaoCB;
	public GameObject CaixaB;
	public GameObject interagivelCaixaB;

	public GameObject botaoSubir;
	public GameObject interagivelSubir;

	public GameObject botaoDescer;
	public GameObject interagivelDescer;

	public GameObject porta;

	static public bool abrirPorta = false;
	static public bool proximaCena = false;

	public bool mudarAndar;

	public bool HabilitarPuzzle = false;

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
		if (this.transform.position.x > 28f) {
			this.transform.position = new Vector2 (28f, this.transform.position.y);	
		}

		float andar = Input.GetAxis("Horizontal") * velocidade;
		this.transform.position += new Vector3(andar, 0) * Time.deltaTime;

		if (podePular == true && Input.GetKeyDown (Mp.jumpKey)) {
			rb2d.AddForce (Vector2.up * 4, ForceMode2D.Impulse);
		}
		bool flipSprite = (sR.flipX ? (andar > 0.01f) : (andar < 0.01f));
		if (flipSprite) 
		{
			sR.flipX = !sR.flipX;
		}
		if (HabilitarPuzzle & Input.GetKeyDown(KeyCode.I)) {
			lendoHistoria = !lendoHistoria;
			if (lendoHistoria) {
				Time.timeScale = 1;
				Puzzle.SetActive (false);
			}
			else
			{
				Time.timeScale = 0;
				Puzzle.SetActive (true);
			}
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
		if (botao.activeSelf & Input.GetKey (Mp.InteractKey)) {
			livro.SetActive(false);
			interagivel.SetActive (false);
			HabilitarPuzzle = true;
			PegueiLivro = true;
		}
		if (botaoCO.activeSelf & Input.GetKey (Mp.InteractKey) & PegueiLivro) {
			botaoCO.SetActive(false);
			interagivelCaixaO.SetActive (false);
		}
		if (botaoCP.activeSelf & Input.GetKey (Mp.InteractKey) & PegueiLivro) {
			botaoCP.SetActive(false);
			interagivelCaixaP.SetActive (false);
			abrirPorta = true;
		}
		if (botaoCB.activeSelf & Input.GetKey (Mp.InteractKey) & PegueiLivro) {
			botaoCB.SetActive(false);
			interagivelCaixaB.SetActive (false);
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
		else if (coll.tag == "PassarCenaLivro") {
			SceneManager.LoadScene ("SalaLivro");
		}
		else if(coll.tag == "CaixaO" & PegueiLivro){
			botaoCO.SetActive (true);
		}
		else if(coll.tag == "CaixaP" & PegueiLivro){
			botaoCP.SetActive (true);
		}
		else if(coll.tag == "CaixaB" & PegueiLivro){
			botaoCB.SetActive (true);
		}
		else {
			podePular = true;
			botao.SetActive (false);
			botaoSubir.SetActive (false);
			botaoDescer.SetActive(false);
			botaoCO.SetActive (false);
			botaoCP.SetActive (false);
			botaoCB.SetActive (false);

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
		else if(coll.tag == "CaixaO" & PegueiLivro){
			botaoCO.SetActive (true);
		}
		else if(coll.tag == "CaixaP" & PegueiLivro){
			botaoCP.SetActive (true);
		}
		else if(coll.tag == "CaixaB" & PegueiLivro){
			botaoCB.SetActive (true);
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
			botaoCO.SetActive (false);
			botaoCP.SetActive (false);
			botaoCB.SetActive (false);
		}
	}
}