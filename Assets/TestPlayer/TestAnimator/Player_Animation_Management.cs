
//　ゲームプログラマー３年制コース　吉田龍矢
//　プレイヤーのアニメーション管理クラス


using UnityEngine;
using System.Collections;

public class Player_Animation_Management : MonoBehaviour {


	TestPlayerMove playerAnimation;

	//メンバー変数
	[SerializeField]
	private bool playerStand;
	[SerializeField]
	private bool playerMoving;
	[SerializeField]
	private bool playerHit;
	[SerializeField]
	private bool playerCreate;
	[SerializeField]
	private bool playerAttack;

	//プロパティ
	public bool playerStand_Pr
	{
		set { this.playerStand = false; }
		get { return this.playerStand; }
	}

	public bool playerMoving_Pr 
	{
		set { this.playerMoving = false; }
		get { return this.playerMoving; }
	}

	public bool playerHit_Pr
	{
		set { this.playerHit = false; }
		get { return this.playerHit; }
	}

	public bool playerCreate_Pr
	{
		set { this.playerCreate = false; }
		get { return this.playerCreate; }
	}

	public bool playerAttack_Pr
	{
		set { this.playerAttack = false; }
		get { return this.playerAttack; }
	}
		


	// Use this for initialization
	void Start () {
		playerAnimation = GetComponent<TestPlayerMove> ();
	}

	
	// Update is called once per frame
	void Update () {
		/// <summary>
		/// playerStatus_pを参照して、それに応じてAnimatorのパラメーターを管理する。
		/// </summary>
		switch(playerAnimation.playerStatus_p){

		case TestPlayerMove.playerStatus.Stand:
			playerStand = true;
			playerMoving = false;
			playerHit = false;
			playerAttack = false;
			AnimatorSet ();
			break;

		case TestPlayerMove.playerStatus.Moving:
			playerMoving = true;
			playerStand = false;
			playerHit = false;
			playerAttack = false;
			AnimatorSet ();
			break;

		case TestPlayerMove.playerStatus.Hit:
			playerHit = true;
			playerStand = false;
			playerMoving = false;
			playerAttack = false;
			AnimatorSet ();
			break;

		case TestPlayerMove.playerStatus.Create:
			playerCreate = true;
			break;

		case TestPlayerMove.playerStatus.Attack:
			playerAttack = true;
			playerStand = false;
			playerMoving = false;
			AnimatorSet ();
			break;

		}
	}

	/// <summary>
	/// Animatorのパラメーターにメンバー変数を反映させるメソッド。
	/// </summary>
	public void AnimatorSet(){
		GetComponent<Animator> ().SetBool ("PlayerStand", playerStand);
		GetComponent<Animator> ().SetBool ("PlayerMoving", playerMoving);
		GetComponent<Animator> ().SetBool ("PlayerHit", playerHit);
		GetComponent<Animator> ().SetBool ("PlayerAttack", playerAttack);
	}
}
