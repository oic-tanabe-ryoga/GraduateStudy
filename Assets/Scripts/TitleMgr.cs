
//　ゲームプログラマー３年制コース　田邉崚雅
//　タイトル画面管理クラス

using UnityEngine;
using System.Collections;
using System;

public class TitleMgr : MonoBehaviour {
	private enum TitleTiming{
		ProcessStart,
		ProcessNow,
		ProcessEnd,
	}TitleTiming titleTiming_p;
	private enum TitleSelectType{
		Start,
		Continue,
		End,
	}TitleSelectType titleSelectType_p;
	private bool canInputUsabale;
	private bool canSaving;
	private TimeSpan allowTime=new TimeSpan(0,0,1);
	private TimeSpan pastTime;
	private DateTime reloadTime;
	public static int testSaveData;

	void Start () {
		TitleInitialize ();
		testSaveData=GameData.captureNo;
	}
	void Update () {
		switch (titleTiming_p) {
		case TitleTiming.ProcessStart:
			titleTiming_p = TitleTiming.ProcessNow;
			break;

		case TitleTiming.ProcessNow:
			if (canInputUsabale == true) {
				TitleInput ();
			} else {
				TitleTimeControl ();
				ReturnInitilize ();
			}
			TestText ();
			break;

		case TitleTiming.ProcessEnd:
			if (canSaving == true) {
				canSaving = false;
				SetPlayerData ();
			}
			SystemMgr.sceneMoveUsabale = true;
			break;
		}
	}

	/// <summary>
	/// タイトル初期化
	/// </summary>
	void TitleInitialize (){
		titleTiming_p = TitleTiming.ProcessStart;
		titleSelectType_p = TitleSelectType.Start;
		canInputUsabale = true;
		canSaving = true;
		SystemMgr.loadBackBoradUsabale = false;
	}

	/// <summary>
	/// 連打防止
	/// </summary>
	void TitleTimeControl(){
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
	void TitleInput(){
		if (InputMgr.vertical <= -0.5f) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (titleSelectType_p) {
			case TitleSelectType.Start:
				titleSelectType_p = TitleSelectType.Continue;
				break;
			case TitleSelectType.Continue:
				titleSelectType_p = TitleSelectType.End;
				break;
			case TitleSelectType.End:
				titleSelectType_p = TitleSelectType.Start;
				break;
			}
		} 
		if (InputMgr.vertical >= 0.5f) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (titleSelectType_p) {
			case TitleSelectType.Start:
				titleSelectType_p = TitleSelectType.End;
				break;
			case TitleSelectType.Continue:
				titleSelectType_p = TitleSelectType.Start;
				break;
			case TitleSelectType.End:
				titleSelectType_p = TitleSelectType.Continue;
				break;
			}
		}
		if (InputMgr.fire6 == true || Input.GetKeyDown (KeyCode.Space)) {
			if (titleSelectType_p == TitleSelectType.End) {
				SystemMgr.systemTiming_g = SystemMgr.SystemTiming.ProcessEnd;
			} else {
				titleTiming_p = TitleTiming.ProcessEnd;
			}
			SystemMgr.loadBackBoradUsabale = true;
		}
		TestSaveData ();
	}

	/// <summary>
	/// プレイヤーデータのセット
	/// </summary>
	void SetPlayerData(){
		switch (titleSelectType_p) {
		case TitleSelectType.Start:
			GameData.Reset ();
			Debug.Log ("データ初期化");
			break;
		case TitleSelectType.Continue:
			GameData.captureNo = TitleMgr.testSaveData;
			GameData.Save ();
			Debug.Log ("データロード");
			break;
		}
	}

	/// <summary>
	/// テスト用
	/// </summary>
	void TestText(){
		this.GetComponent<GUIText>().text = "TestText"+titleSelectType_p+"Test"+testSaveData;
	}
	void TestSaveData(){
		if (InputMgr.fire8)
			testSaveData++;
	}
}