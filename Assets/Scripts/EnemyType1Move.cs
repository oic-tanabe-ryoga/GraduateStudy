
//　ゲームプログラマー３年制コース　田邉崚雅
//　エネミーキャラテストクラス

using UnityEngine;
using System.Collections;

public class EnemyType1Move : MonoBehaviour {
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
	public float searchArea=4.0f;
	private float distance;
	public float speed =0.1f;
	public float speedZ=0.1f;
	private Vector3 vec;

	private float rotationSmooth = 1.0f;
	public float changeDistance = 1.0f;

	public GameObject TestAttack;
	private float targetDistance;
	private float targetX;
	private float targetZ;
	private bool canAttack = true;
	private GameObject testMgr;



	void Start () {
		EnemyInitialize ();
	}

	void Update () {
		switch (enemyStatus_p) {
		case enemyStatus.Create:
			enemyStatus_p = enemyStatus.Stand;
			break;
		case enemyStatus.Stand:
			enemyStatus_p = enemyStatus.Serch_Run;
			break;
		case enemyStatus.Attack://攻撃範囲内：X軸同一線上
			SetTarget ();
			if (targetDistance > changeDistance) {
				enemyStatus_p = enemyStatus.Serch_Run;
			} else {
				if (this.gameObject.transform.position.z + 4.0f >= targetZ &&
				    this.gameObject.transform.position.z - 4.0f <= targetZ &&
				    this.gameObject.transform.position.x + 4.0f >= targetX &&
				    this.gameObject.transform.position.x - 4.0f <= targetX) {
					if (canAttack == true) {
						GameObject obj = Instantiate (TestAttack);
						obj.transform.parent = transform;
						obj.name = ("Effect");
						canAttack = false;
					} 
				}else {
						enemyStatus_p = enemyStatus.Escape;
				}
				/*if ((this.gameObject.transform.position.x +2.0f > targetX &&
					this.gameObject.transform.position.x - 2.0f < targetX)&&
					(this.gameObject.transform.position.z+2.0<targetZ&&
					this.gameObject.transform.position.z-2.0>targetZ)) {
					enemyStatus_p = enemyStatus.Escape;
				} else {
					if (canAttack == true) {
						GameObject obj = Instantiate (TestAttack);
						obj.transform.parent = transform;
						obj.name = ("Effect");
						canAttack = false;
					}
				}*/
			}
			break;
		case enemyStatus.Escape://逃避範囲内：X軸同一線上外
			SetTarget ();
			/*if (targetDistance > changeDistance) {
				enemyStatus_p = enemyStatus.Serch_Run;
			} else {*/
			if (targetDistance < changeDistance||
				this.gameObject.transform.position.z + 4.0f >= targetZ &&
					this.gameObject.transform.position.z - 4.0f <= targetZ &&
					this.gameObject.transform.position.x + 4.0f >= targetX &&
					this.gameObject.transform.position.x - 4.0f <= targetX) {
					enemyStatus_p = enemyStatus.Serch_Run;
				}else{
					if (this.gameObject.transform.position.z < targetZ) {
						speedZ = speed/2;
					} else {
						speedZ = -speed/2;
					}
					this.transform.position += new Vector3 (speed * Time.deltaTime,0, speedZ * Time.deltaTime);
				}

			break;
		case enemyStatus.Serch_Run://範囲外：X・Z非同一線上
			SetTarget ();
			if (targetDistance > changeDistance) {
				ToTargetMove ();
			} else {
				enemyStatus_p = enemyStatus.Attack;
			}
			break;
		case enemyStatus.Hit:
			break;
		case enemyStatus.Destroy:
			break;
		}
	}

	void EnemyInitialize(){
		targetPlayer1 = GameObject.FindGameObjectWithTag ("Player1").transform;
		targetPlayer2 = GameObject.FindGameObjectWithTag ("Player1").transform;
		targetX = 0.0f;
	}
	void SetTarget(){
		float sqrDistance1 = Vector3.SqrMagnitude (this.gameObject.transform.position - targetPlayer1.transform.position);
		float sqrDistance2 = Vector3.SqrMagnitude (this.gameObject.transform.position - targetPlayer2.transform.position);
		if (sqrDistance1 <= sqrDistance2) {
			transform.rotation = Quaternion.Slerp (this.gameObject.transform.rotation,
				Quaternion.LookRotation (targetPlayer1.transform.position - this.gameObject.transform.position), 0.3f);
			targetDistance = sqrDistance1;
			targetX = targetPlayer1.transform.position.x;
			targetZ = targetPlayer1.transform.position.z;
		} else {
			transform.rotation = Quaternion.Slerp (this.gameObject.transform.rotation,
				Quaternion.LookRotation (targetPlayer2.transform.position - this.gameObject.transform.position), 0.3f);
			targetDistance = sqrDistance2;
			targetX = targetPlayer2.transform.position.x;
			targetZ = targetPlayer2.transform.position.z;
		}
	}
	void ToTargetMove(){
		this.gameObject.transform.position += this.gameObject.transform.forward * speed * Time.deltaTime;
	}
		
	void Create(){
	}
	void Stand(){
	}
	void Search_Run(){
	}
	void Hit(){
	}
	void Attack(){
	}
	public void CanAttack(){
		canAttack = true;
	}


	/// <summary>
	/// ダメージ判定
	/// </summary>
	public void Damage(int damegePoint){
		enemyHp -= damegePoint;
	}
}