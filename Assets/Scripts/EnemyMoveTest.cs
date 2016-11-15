
//　ゲームプログラマー３年制コース　田邉崚雅
//　エネミーキャラテストクラス

using UnityEngine;
using System.Collections;

public class EnemyMoveTest : MonoBehaviour {

	public int enemyHp;
	public int enemyAt;
	public int enemyDf;

	public enum enemyStatus{
		Create,
		Stand,
		Serch_Run,
		Escape,
		Attack,
		Hit,
		Destroy,
	} public enemyStatus enemyStatus_p;
	public enum enemyType{
		Type1,
	} public enemyType enemyType_p;
	private Transform targetPlayer1;
	private Transform targetPlayer2;

	public float searchArea_p=4.0f;
	private float searchArea;
	private float distance;
	public float speed =0.1f;
	public float speedZ=0.1f;
	private Vector3 vec;

	public float changeDistance = 1.0f;

	public GameObject TestAttack;
	private float targetDistance;
	private float targetX;
	private float targetZ;
	public float targetSizeX=0.0f;
	public float targetSizeZ=0.0f;
	private bool canAttack = true;
	private GameObject testMgr;

	public float thisGameObjX=0.0f;
	public float thisGameObjZ=0.0f;

	public int TestMgrCount = 0;

	void Start () {
		EnemyInitialize ();
		TestMgrCount = 0;
	}

	void Update () {
		//Console ();
		switch (enemyStatus_p) {
		case enemyStatus.Create:
			enemyStatus_p = enemyStatus.Stand;
			break;
		case enemyStatus.Stand:
			enemyStatus_p = enemyStatus.Serch_Run;
			break;
		case enemyStatus.Attack://攻撃範囲内：X軸同一線上
			SetTarget ();
			Attack ();
			StateDetermination ();
			break;
		case enemyStatus.Escape://逃避範囲内：X軸同一線上外
			SetTarget ();
			Escape ();
			StateDetermination ();
			break;
		case enemyStatus.Serch_Run://範囲外：X・Z非同一線上
			SetTarget ();
			SearchRun ();
			StateDetermination ();
			break;
		case enemyStatus.Hit:
			break;
		case enemyStatus.Destroy:
			break;
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void EnemyInitialize(){
		targetPlayer1 = GameObject.FindGameObjectWithTag ("Player1").transform;
		targetPlayer2 = GameObject.FindGameObjectWithTag ("Player1").transform;
		targetSizeX=targetPlayer1.GetComponent<BoxCollider> ().bounds.size.x;
		targetSizeZ=targetPlayer1.GetComponent<BoxCollider> ().bounds.size.z;
		searchArea = targetSizeX / 2 + this.gameObject.GetComponent<BoxCollider> ().bounds.size.x / 2 + searchArea_p;
	}

	/// <summary>
	/// ターゲットの位置情報から一番近いターゲットを指定する
	/// </summary>
	void SetTarget(){
		Vector3 pos1 = targetPlayer1.transform.position;
		pos1.x = targetPlayer1.transform.position.x ;
		Vector3 pos2 = targetPlayer2.transform.position;
		pos2.x = targetPlayer2.transform.position.x ;

		float sqrDistance1 = Vector3.SqrMagnitude (this.gameObject.transform.position - pos1);
		float sqrDistance2 = Vector3.SqrMagnitude (this.gameObject.transform.position - pos2);
		if (sqrDistance1 <= sqrDistance2) {
			targetDistance = sqrDistance1;
			targetX = pos1.x;
			targetZ = pos1.z;
		} else {
			targetDistance = sqrDistance2;
			targetX = pos2.x;
			targetZ = pos2.z;
		}
	}

	/// <summary>
	/// 攻撃
	/// </summary>
	void Attack(){
		if (canAttack == true) {
			GameObject obj = Instantiate (TestAttack);
			obj.transform.parent = transform;
			obj.name = ("Effect");
			canAttack = false;
		}
	}

	/// <summary>
	/// 状態の設定
	/// </summary>
	void StateDetermination(){
		if (searchArea < targetDistance) {
			enemyStatus_p=enemyStatus.Serch_Run;
		} else {
			if (targetZ + 0.5f > this.gameObject.transform.position.z &&
				targetZ - 0.5f < this.gameObject.transform.position.z) {
				if (targetX< this.gameObject.transform.position.x + 2.0f &&
					targetX> this.gameObject.transform.position.x- 2.0f ) {//プレイヤーが左
					enemyStatus_p = enemyStatus.Attack;
				} else {
					enemyStatus_p=enemyStatus.Escape;
				}
			} else {
				enemyStatus_p=enemyStatus.Escape;
			}
		}
	}

	/// <summary>
	/// テスト用のログ出力
	/// </summary>
	void Console(){
		thisGameObjX=this.gameObject.transform.position.x;
		thisGameObjZ=this.gameObject.transform.position.z;
		Debug.Log (targetSizeX+"targetSizeX");
		Debug.Log (targetSizeZ+"targetSizeZ");
		Debug.Log (searchArea+"searchArea");
		Debug.Log (thisGameObjX+"thisGameObjX");
		Debug.Log (thisGameObjZ+"thisGameObjZ");
		Debug.Log (targetX+"targetX");
		Debug.Log (targetZ+"targetZ");
	}

	void Create(){
	}
	void Stand(){
	}

	/// <summary>
	/// 逃避用・攻撃範囲だけどZ軸がずれてるなどの状態
	/// </summary>
	void Escape(){
		Vector3 forwardx =new Vector3(speed,0.0f,0.0f);
		Vector3 forwardz =new Vector3(0.0f,0.0f,speedZ);
		if (targetZ + 0.5f > this.gameObject.transform.position.z &&
		    targetZ - 0.5f < this.gameObject.transform.position.z) {
			if (targetX <= this.gameObject.transform.position.x) {
				transform.localPosition -= forwardx * Time.deltaTime;
			} else {
				transform.localPosition += forwardx * Time.deltaTime;
			}
		} else {
			if (targetZ > this.gameObject.transform.position.z) {
				if (targetX < this.gameObject.transform.position.x + 1.5f&&
					targetX > this.gameObject.transform.position.x - 1.5f) {
					if (targetX <= this.gameObject.transform.position.x) {
						transform.localPosition += forwardx * Time.deltaTime;
					} else {
						transform.localPosition -= forwardx * Time.deltaTime;
					}
				} else {
					transform.localPosition += forwardz * Time.deltaTime;
				}
			} else {
				if (targetX < this.gameObject.transform.position.x + 1.5f&&
					targetX > this.gameObject.transform.position.x - 1.5f) {
					if (targetX <= this.gameObject.transform.position.x) {
						transform.localPosition += forwardx * Time.deltaTime;
					} else {
						transform.localPosition -= forwardx * Time.deltaTime;
					}
				} else {
					transform.localPosition -= forwardz * Time.deltaTime;
				}
			}
		}
	}

	/// <summary>
	/// サーチ中
	/// </summary>
	void SearchRun(){
		Vector3 forwardx =new Vector3(speed,0.0f,0.0f);
		Vector3 forwardz =new Vector3(0.0f,0.0f,speedZ);
		if (targetX <= this.gameObject.transform.position.x) {
			transform.localPosition -= forwardx * Time.deltaTime;
		} else {
			transform.localPosition += forwardx * Time.deltaTime;
		}
		if (targetZ < this.gameObject.transform.position.z) {
			transform.localPosition -= forwardz * Time.deltaTime;
		} else if(targetZ > this.gameObject.transform.position.z){
			transform.localPosition += forwardz * Time.deltaTime;
		}
	}

	/// <summary>
	/// タイトル初期化
	/// </summary>
	void Hit(){
	}

	/// <summary>
	/// 攻撃エフェクト終了時に呼ぶ
	/// </summary>
	public void CanAttack(){
		canAttack = true;
	}
	/// <summary>
	/// ダメージ判定
	/// </summary>
	public void Damage(int damegePoint){
		enemyHp -= damegePoint;
	}

	public void Test(){
		TestMgrCount++;
	}
}