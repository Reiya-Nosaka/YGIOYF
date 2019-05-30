using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject explosionPrefab;
	public LayerMask levelMask;
	private bool exploded = false; // すでに爆発している場合 true
	public int bombarea = 3;
	// Use this for initialization
	void Start () {
		GetComponent<BoxCollider> ().enabled = false;
		Invoke ("ChangeCollider",0.5f);
		Invoke ("Explode", 3f);

	}

	// Update is called once per frame
	void Update () {

	}
	private void Explode (){
		// 爆弾の位置に爆発エフェクトを作成
		Instantiate( explosionPrefab, transform.position, Quaternion.identity );

		// 爆弾を非表示にする
		GetComponent<MeshRenderer>().enabled = false;
		//爆風を広げる
		CreateExplosions( Vector3.forward); // 上に広げる
		CreateExplosions( Vector3.right ); // 右に広げる
		CreateExplosions( Vector3.back ); // 下に広げる
		CreateExplosions( Vector3.left ); // 左に広げる
		this.gameObject.SetActive( false );
		exploded = true;


		// 0.3 秒後に非表示にした爆弾を削除
		Destroy( gameObject, 0.3f );
	}
	// 爆風を広げる
	private void CreateExplosions( Vector3 direction )
	{
		// 2 マス分ループする
		for ( int i = 1; i < bombarea; i++ )
		{
			// ブロックとの当たり判定の結果を格納する変数
			RaycastHit hit;
			//Debug.Log ("loop"+direction+i);
			// 爆風を広げた先に何か存在するか確認
			Physics.Raycast
			(
				transform.position + new Vector3( 0, 0.5f, 0 ),
				direction,
				out hit,
				i,
				levelMask
			);


			// 爆風を広げた先に何も存在しない場合
			if ( !hit.collider )
			{
				// 爆風を広げるために、
				// 爆発エフェクトのオブジェクトを作成
				Instantiate
				(
					explosionPrefab,
					transform.position + ( i * direction ),
					explosionPrefab.transform.rotation
				);
			}
			// 爆風を広げた先にブロックが存在する場合
			else
			{
				// 爆風はこれ以上広げない
				break;
			}
		}
	}
	public void OnTriggerEnter( Collider other )
	{
		// まだ爆発していない、
		// かつ、この爆弾にぶつかったオブジェクトが爆発エフェクトの場合
		if ( !exploded && other.CompareTag( "Explosion" ) )
		{
			// 2 重に爆発処理が実行されないように
			// すでに爆発処理が実行されている場合は止める
			CancelInvoke( "Explode" );

			// 爆発する
			Explode();
		}
	}
	private void ChangeCollider(){
		//colliderの判定を反転させる
		if (GetComponent<BoxCollider> ().enabled) {
			GetComponent<BoxCollider> ().enabled = false;
		} 
		else {
			GetComponent<BoxCollider> ().enabled = true;
		}
	}
}
