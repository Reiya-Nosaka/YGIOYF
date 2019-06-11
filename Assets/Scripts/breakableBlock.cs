using System.Collections;
using UnityEngine;

public class breakableBlock : MonoBehaviour {

    public GameObject Item;
public void OnTriggerEnter (Collider other)
{
    if (other.CompareTag ("Explosion"))
    {
        // 爆弾を削除
        Destroy( gameObject );

        //Item生成（乱数で出たり、出なかったりしてもいい気がします）
        GameObject newItem =
         Instantiate (Item, this.transform.position, Quaternion.identity) as GameObject;
    
    }
}
}
