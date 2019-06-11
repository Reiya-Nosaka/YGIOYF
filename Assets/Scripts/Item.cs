using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour {

public void OnTriggerEnter (Collider other)
{
    if (other.CompareTag ("Player"))
    {
        // Itemを削除
        Destroy( gameObject );
    }
}
}
