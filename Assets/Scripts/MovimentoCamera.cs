using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour {

	public float z = -20;

	public float speed = 0.15f;
	private Transform target;
	//Terreo
	public bool maxMin;

	public float xMin;
	public float yMin;
	public float xMax;
	public float xMaxDepois;
	public float yMax;
	//Informar o numero da andar (0 para terreo)
	static public int floor;
	//Primeiro andar
	public bool maxMin1;

	public float xMin1;
	public float yMin1;
	public float xMax1;
	public float yMax1;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null)
			return;

		if (floor == 0) {

				transform.position = Vector3.Lerp (transform.position, target.position, speed);

				if (maxMin & !Jogador.proximaCena) {

					transform.position = new Vector3 (Mathf.Clamp (transform.position.x, xMin, xMax), Mathf.Clamp (transform.position.y, yMin, yMax), z);
				}
				if(maxMin & Jogador.proximaCena){
					transform.position = new Vector3 (Mathf.Clamp (transform.position.x, xMin, xMaxDepois), Mathf.Clamp (transform.position.y, yMin, yMax), z);
				}

		}
		if (floor == 1) {
				transform.position = Vector3.Lerp (transform.position, target.position, speed);

				if (maxMin1) {

					transform.position = new Vector3 (Mathf.Clamp (transform.position.x, xMin1, xMax1), Mathf.Clamp (transform.position.y, yMin1, yMax1), z);
				}

		}
	}
}