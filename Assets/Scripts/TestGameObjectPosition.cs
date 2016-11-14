using UnityEngine;
using System.Collections;

public class TestGameObjectPosition : MonoBehaviour {
	public Transform targetPlayer1;
	public Transform targetPlayer2;

	public float searchArea_p=4.0f;
	public float searchArea;
	public float distance;
	public float speed =0.1f;
	public float speedZ=0.1f;
	public Vector3 vec;

	public float changeDistance = 1.0f;

	public GameObject TestAttack;
	public float targetDistance;
	public float targetX;
	public float targetZ;
	public float targetSizeX=0.0f;
	public float targetSizeZ=0.0f;
	public float thisGameObjX=0.0f;
	public float thisGameObjZ=0.0f;
	public bool canAttack = true;
	public GameObject testMgr;

	// Use this for initialization
	void Start () {
		targetPlayer1 = GameObject.FindGameObjectWithTag ("Player1").transform;
		targetPlayer2 = GameObject.FindGameObjectWithTag ("Player1").transform;
		targetSizeX=targetPlayer1.GetComponent<BoxCollider> ().bounds.size.x;
		targetSizeZ=targetPlayer1.GetComponent<BoxCollider> ().bounds.size.z;
		searchArea = targetSizeX / 2 + this.gameObject.GetComponent<BoxCollider> ().bounds.size.x / 2 + searchArea_p;
		SetTarget ();
		thisGameObjX=this.gameObject.transform.position.x;
		thisGameObjZ=this.gameObject.transform.position.z;
		Console ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetTarget(){
		float sqrDistance1 = Vector3.SqrMagnitude (this.gameObject.transform.position - targetPlayer1.transform.position);
		float sqrDistance2 = Vector3.SqrMagnitude (this.gameObject.transform.position - targetPlayer2.transform.position);
		if (sqrDistance1 <= sqrDistance2) {
			targetDistance = sqrDistance1;
			targetX = targetPlayer1.transform.position.x;
			targetZ = targetPlayer1.transform.position.z;
		} else {
			targetDistance = sqrDistance2;
			targetX = targetPlayer2.transform.position.x;
			targetZ = targetPlayer2.transform.position.z;
		}
	}
	void Console(){
		Debug.Log (targetSizeX);
		Debug.Log (targetSizeZ);
		Debug.Log (searchArea);
		Debug.Log (thisGameObjX);
		Debug.Log (thisGameObjZ);
		Debug.Log (targetX);
		Debug.Log (targetZ);
	}
}
