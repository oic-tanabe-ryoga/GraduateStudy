using UnityEngine;
using System.Collections;

public class Boy1 : Player1 {

	// Use this for initialization
	void Start () {
		playerPosition = transform.position;
		playerMoveSpeed = new Vector3(2,0,2);
		playerHitPoint = 10;
		playerAttackDamage = 2;
		aboveOrBelowUsable = false;
		lineMax = playerMoveSpeed.z * 2;
		lineMin = 0;
	}
	void Update () {
		switch (playerRoutineNo){
		case (int)state.PlayerDevised:
			Debug.Log("プレイヤールーチン起動してます。");
			CanPlayerDevised ();
			if (CanPlayerDevised () == 1) {
				playerRoutineNo = (int)state.PlayerMove;
			} else if (CanPlayerDevised () == 2) {
				playerRoutineNo = (int)state.PlayerAttack;
			} 
			break;

		case (int)state.PlayerMove:
			IsPlayerMove();
			break;

		case (int)state.PlayerAttack:
			IsPlayerAttack();
			if(IsPlayerAttack() == 0) { playerRoutineNo = (int)state.PlayerMove; }
			break;
		}
	}

}
