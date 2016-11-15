
//　ゲームプログラマー３年制コース　田邉崚雅
//　シングルプレイメインマネージャ

using UnityEngine;
using System.Collections;
using System;

public class SinglePlayMgr : MonoBehaviour {

	private enum MainTiming{
		ProcessStart,
		ProcessNow,
		ProcessEnd,
	}MainTiming mainTiming_p;
	public enum SingleType{
		None,
		Clear,
		Over,
	}public static SingleType singleType_g;
	private bool canInputUsabale;
	public GameObject[] stage;
	private GameObject stageObj;
	private int stageNo=0;
	private TimeSpan allowTime=new TimeSpan(0,0,1);
	private TimeSpan pastTime;
	private DateTime reloadTime;
	private GameObject enemyMgr;

	void Awake(){
		stageNo = (int)StageSelectMgr.stageSelectType_g;
	}

	void Start () {
		stageObj=Instantiate (stage [stageNo]);
		stageObj.transform.parent = this.gameObject.transform;
		SingleInitialize ();
		singleType_g = SingleType.None;
		enemyMgr = GameObject.Find("EnemyMgr");
	}
	
	void Update () {
		switch (mainTiming_p) {
		case MainTiming.ProcessStart:
			mainTiming_p = MainTiming.ProcessNow;
			break;
		case MainTiming.ProcessNow:
			if (canInputUsabale == true) {
				TestScene ();
				//SingleInput ();
			} else {
				SingleTimeControl ();
				ReturnInitilize ();
			}
			break;
		case MainTiming.ProcessEnd:
			SystemMgr.sceneMoveUsabale = true;
			break;
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void SingleInitialize (){
		mainTiming_p = MainTiming.ProcessStart;
		canInputUsabale = true;
		SystemMgr.loadBackBoradUsabale = false;
	}

	/// <summary>
	/// テストシーン移行
	/// </summary>
	void TestScene(){
		if (InputMgr.fire6 == true || Input.GetKeyDown (KeyCode.Space)) {
			mainTiming_p = MainTiming.ProcessEnd;
			SystemMgr.loadBackBoradUsabale = true;
			singleType_g = SingleType.Clear;
		} else if (InputMgr.fire7 == true) {
			mainTiming_p = MainTiming.ProcessEnd;
			SystemMgr.loadBackBoradUsabale = true;
			singleType_g = SingleType.Over;
		} else if (InputMgr.fire5 == true) {
			enemyMgr.GetComponent<EnemyMgr> ().EnemyBreak();
		}
	}

	/// <summary>
	/// 連打防止
	/// </summary>
	void SingleTimeControl(){
		pastTime = DateTime.Now - this.reloadTime;
		if(pastTime > allowTime){
			canInputUsabale = true;
		}
	}

	/// <summary>
	/// 元の位置に戻ったときに初期化
	/// </summary>
	void ReturnInitilize(){
		if (InputMgr.vertical == 0.0f) {
			canInputUsabale = true;
		}
	}

	/// <summary>
	/// タイトル選択肢移動
	/// </summary>
	void SingleInput(){
	}
}
