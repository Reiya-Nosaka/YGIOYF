using UnityEngine;
using System.Collections;

public class bomberd : MonoBehaviour {
	public bool destroyed = false;//壊れたらtrue
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Explosion"))
		{
			Debug.Log ("The wall destroyed!");
			destroyed = true;
			Destroy (gameObject);
		}
	}
}
