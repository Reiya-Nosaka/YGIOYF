using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {
	private Player PY;
	public float Delay = 3f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, Delay);
	}

}
