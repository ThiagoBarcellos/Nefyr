using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCamera : MonoBehaviour {

	public float speed = 0.15f;
	private Transform target;
	//Terreo
	public bool maxMin;

	public float xMin;
	public float yMin;
	public float xMax;
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
		if (floor == 0) {
			if (target) {

				transform.position = Vector3.Lerp (transform.position, target.position, speed) + new Vector3 (0, 0, target.position.z);

				if (maxMin) {

					transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax), 2 * target.position.z - 20);
				}
			}
		}
		if (floor == 1) {
			if (target) {

				transform.position = Vector3.Lerp (transform.position, target.position, speed) + new Vector3 (0, 0, target.position.z);

				if (maxMin1) {

					transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin1, xMax1), Mathf.Clamp (target.position.y, yMin1, yMax1), 2* target.position.z - 20);
				}
			}
		}
	}
}