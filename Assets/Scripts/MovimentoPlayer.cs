using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour {

	public KeyCode jumpKey;
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode InteractKey;

	public bool IsMovingLeft(){
		return Input.GetKey (leftKey);
	}
	public bool IsMovingRight(){
		return Input.GetKey (rightKey);
	}
	public bool IsJumping(){
		return Input.GetKey (jumpKey);
	}
	public bool IsInteracting(){
		return Input.GetKey (InteractKey);
	}
	public bool IsAscending(){
		return Input.GetKey (upKey);
	}
	public bool IsDescending(){
		return Input.GetKey (downKey);
	}
}