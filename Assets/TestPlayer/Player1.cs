using UnityEngine;
using System.Collections;

// GP3年制 2年 15番 吉田龍矢
// プレイヤールーチン

public class Player1 : MonoBehaviour {

    public enum state : int
    {
		PlayerDevised = 1,
        PlayerMove = 2,
        PlayerAttack = 3
    }
    public int playerRoutineNo = (int)state.PlayerDevised;

	public enum playerButtonType : int
	{
		playerMoveButton = 1,
		playerAttackButton = 2
	}	

	public Vector3 playerPosition;



	protected Vector3 playerMoveSpeed;
	protected float coordinateRegulation;
	protected float moveCoordinate;
	protected int aboveOrBelow;
	protected int playerHitPoint;
	protected int playerAttackDamage;
	protected bool aboveOrBelowUsable;

	public float lineMax;
	public float lineMin;

	/// <summary>
	/// プレイヤー判断を待つプログラム
	/// </summary>
	/// <returns>戻り値:1 → state.playerMove
	///                 2 → state.playerAttack
	/// </returns>押されたボタンによって、ほかのcaseにとぶための戻り値
	/// <param name="buttonSelect">なし</param>voidではエラーが起きたので,これを使用している。
	public int CanPlayerDevised()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			return 1;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			return 1;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			return 1;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			return 1;
		} else if (Input.GetKey (KeyCode.Q)) {
			return 2;
		}
		return 0; 	
	}

	/// <summary>
	/// プレイヤーの移動処理をするプログラム
	/// </summary>
	/// <returns>戻り値</returns>
	/// <param name="引数名">引数</param>
	public int IsPlayerMove()
    {
		if (aboveOrBelowUsable == false) {
			if (Input.GetKeyDown (KeyCode.UpArrow) & playerPosition.z < lineMax) {
				aboveOrBelow = 1;
				aboveOrBelowUsable = true;
				moveCoordinate = playerPosition.z + playerMoveSpeed.z;
			} else if (Input.GetKeyDown (KeyCode.DownArrow) & playerPosition.z > lineMin) {
				aboveOrBelow = 2;
				aboveOrBelowUsable = true;
				moveCoordinate = playerPosition.z - playerMoveSpeed.z;
			} else {
				aboveOrBelow = 0;
			}
		}

		switch(aboveOrBelow){

		case 0:
			aboveOrBelowUsable = false;
			break;

		case 1:
				playerPosition.z += playerMoveSpeed.z * Time.deltaTime;
			if (moveCoordinate <= playerPosition.z) {
				playerPosition.z += moveCoordinate - playerPosition.z;
				aboveOrBelow = 0;
			}
			transform.position = playerPosition;
			break;

		case 2:
			playerPosition.z -= playerMoveSpeed.z * Time.deltaTime;
			if (moveCoordinate >= playerPosition.z) {
				playerPosition.z += moveCoordinate - playerPosition.z;
				aboveOrBelow = 0;
			}
			transform.position = playerPosition;
			break;

		}


		if (Input.GetKey (KeyCode.RightArrow)) {
			playerPosition.x += playerMoveSpeed.x * Time.deltaTime;
			transform.position = playerPosition;
			Debug.Log ("移動中");
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			playerPosition.x -= playerMoveSpeed.x * Time.deltaTime;
			transform.position = playerPosition;
			Debug.Log ("移動中");
		}
		return 0;
	}

	/// <summary>
	/// 関数の説明
	/// </summary>
	/// <returns>戻り値</returns>
	/// <param name="引数名">引数</param>
	public int IsPlayerAttack()
    {
        return 0;
    }
}
