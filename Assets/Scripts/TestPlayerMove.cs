
//　ゲームプログラマー３年制コース　田邉崚雅
//　テスト用プレイヤー移動クラス

using UnityEngine;
using System.Collections;

public class TestPlayerMove : MonoBehaviour {
	public float speed = 2.0f;
	private enum playerPosition{
		Before,
		During,
		After,
	}
	[SerializeField]
	private playerPosition playerPosition_p;
	[SerializeField]
	private float playerTargetZ;
	[SerializeField]
	private bool canMoving;
	public float TestZ=10.0f;
	private enum playerStatus
	{
		Create,
		Stand,
		Hit,
		Moving,
		Attack,
	}playerStatus playerStatus_p;
	private enum playerMovingType{
		Stop,
		Up,
		Down,
	}
	[SerializeField]
	private playerMovingType playerMovingType_p;
	// Use this for initialization
	void Start () {
		playerPosition_p = playerPosition.During;
		canMoving = true;
		playerStatus_p = playerStatus.Stand;
		playerMovingType_p = playerMovingType.Stop;
	}

	// Update is called once per frame
	void Update () {
		InputPlayer ();
		SetPlayerTarget ();
		PlayerMovingZ ();
	}
	void SetPlayerTarget(){
		switch (playerPosition_p) {
		case playerPosition.Before:
			playerTargetZ = TestZ;
			break;
		case playerPosition.During:
			playerTargetZ = 0.0f;
			break;
		case playerPosition.After:
			playerTargetZ = -TestZ;
			break;
		}
	}
	void InputPlayer(){
		if (InputMgr.vertical>=0.7f||InputMgr.vertical<=-0.7f) {
			if (InputMgr.vertical > 0.0f&&canMoving == true) {
				canMoving = false;
				switch (playerPosition_p) {
				case playerPosition.Before:
					playerPosition_p = playerPosition.Before;
					playerMovingType_p = playerMovingType.Up;
					break;
				case playerPosition.During:
					playerPosition_p = playerPosition.Before;
					playerMovingType_p = playerMovingType.Up;
					break;
				case playerPosition.After:
					playerPosition_p = playerPosition.During;
					playerMovingType_p = playerMovingType.Up;
					break;
				}
				playerStatus_p = playerStatus.Moving;
			}else if(InputMgr.vertical < 0.0f&&canMoving == true){
				canMoving = false;
				switch (playerPosition_p) {
				case playerPosition.Before:
					playerPosition_p = playerPosition.During;
					playerMovingType_p = playerMovingType.Down;
					break;
				case playerPosition.During:
					playerPosition_p = playerPosition.After;
					playerMovingType_p = playerMovingType.Down;
					break;
				case playerPosition.After:
					playerPosition_p = playerPosition.After;
					playerMovingType_p = playerMovingType.Down;
					break;
				}
				playerStatus_p = playerStatus.Moving;
			}
		}
		if (InputMgr.horizontal!=0.0f) {
			transform.position += transform.right * InputMgr.horizontal*Time.deltaTime*speed;
			playerStatus_p = playerStatus.Moving;
		}
		if (InputMgr.vertical == 0.0f && InputMgr.horizontal == 0.0f) {
			playerStatus_p = playerStatus.Stand;
		}
	}
	void PlayerMovingZ(){
		if (canMoving == false) {
			if (this.gameObject.transform.position.z == playerTargetZ) {
				playerMovingType_p = playerMovingType.Stop;
				canMoving = true;
			} else {
				if (playerMovingType_p == playerMovingType.Up) {
					transform.position += transform.forward *Time.deltaTime*speed;
					if (this.gameObject.transform.position.z > playerTargetZ){
						Vector3 pos = transform.position;
						pos.z = playerTargetZ;
						transform.position = pos;
					}
				} else if (playerMovingType_p == playerMovingType.Down) {
					transform.position += transform.forward *Time.deltaTime*-speed;
					if (this.gameObject.transform.position.z < playerTargetZ){
						Vector3 pos = transform.position;
						pos.z = playerTargetZ;
						transform.position = pos;
					}
				}
				if (playerPosition_p == playerPosition.During&&this.gameObject.transform.position.z==0.0f) {
					playerMovingType_p = playerMovingType.Stop;
					canMoving = true;	
				}else if (playerPosition_p == playerPosition.Before&&this.gameObject.transform.position.z==1.0f) {
					playerMovingType_p = playerMovingType.Stop;
					canMoving = true;	
				}else if (playerPosition_p == playerPosition.After&&this.gameObject.transform.position.z==-1.0f) {
					playerMovingType_p = playerMovingType.Stop;
					canMoving = true;	
				}
			}
		}
	}
}