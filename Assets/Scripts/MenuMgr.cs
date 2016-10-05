
//　ゲームプログラマー３年制コース　田邉崚雅
//　メニュー画面管理クラス

using UnityEngine;
using System.Collections;
using System;

public class MenuMgr : MonoBehaviour {
	private enum MenuTiming{
		ProcessingStart,
		ProcessingNow,
		ProcessingEnd,
	}MenuTiming menuTiming_p;
	public enum MenuSelectType{
		Main,
		Multi,
		CharStrengthen,
		Title,
	}public static MenuSelectType menuSelectType_g;

	private bool canInputUsabale;
	private TimeSpan allowTime=new TimeSpan(0,0,1);
	private TimeSpan pastTime;
	private DateTime reloadTime;


	void Awake(){
		SetPlayerData ();
	}

	void Start () {
		MenuInitialize ();
		menuTiming_p = MenuTiming.ProcessingStart;
	}
	
	void Update () {
		switch (menuTiming_p) {
		case MenuTiming.ProcessingStart:
			menuTiming_p = MenuTiming.ProcessingNow;
			break;
		case MenuTiming.ProcessingNow:
			if (canInputUsabale == true) {
				MenuInput ();
			} else {
				MenuTimeControl ();
				ReturnInitilize ();
			}
			TestText ();
			break;
		case MenuTiming.ProcessingEnd:
			break;
		}
	}


	/// <summary>
	/// プレイヤーデータのセット
	/// </summary>
	void SetPlayerData(){
		switch (TitleMgr.titleSelectType_g) {
		case TitleMgr.TitleSelectType.Start:
			GameData.Reset ();
			Debug.Log ("データ初期化");
			break;
		case TitleMgr.TitleSelectType.Continue:
			GameData.captureNo = TitleMgr.testSaveData;
			GameData.Save ();
			Debug.Log ("データロード");
			break;
		}
	}

	/// <summary>
	/// タイトル初期化
	/// </summary>
	void MenuInitialize (){
		menuTiming_p = MenuTiming.ProcessingStart;
		menuSelectType_g = MenuSelectType.Main;
		canInputUsabale = true;
	}

	/// <summary>
	/// 連打防止
	/// </summary>
	void MenuTimeControl(){
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
	/// メニューの移動形式
	/// </summary>
	void MenuInput(){
		if (InputMgr.vertical <= -0.5f) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (menuSelectType_g) {
			case MenuSelectType.Main:
				menuSelectType_g = MenuSelectType.Multi;
				break;
			case MenuSelectType.Multi:
				menuSelectType_g = MenuSelectType.CharStrengthen;
				break;
			case MenuSelectType.CharStrengthen:
				menuSelectType_g = MenuSelectType.Title;
				break;
			case MenuSelectType.Title:
				menuSelectType_g = MenuSelectType.Main;
				break;
			}
		}
		if (InputMgr.vertical >= 0.5f) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (menuSelectType_g) {
			case MenuSelectType.Main:
				menuSelectType_g = MenuSelectType.Title;
				break;
			case MenuSelectType.Multi:
				menuSelectType_g = MenuSelectType.Main;
				break;
			case MenuSelectType.CharStrengthen:
				menuSelectType_g = MenuSelectType.Multi;
				break;
			case MenuSelectType.Title:
				menuSelectType_g = MenuSelectType.CharStrengthen;
				break;
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	void TestText(){
		this.GetComponent<GUIText>().text = "TestText"+menuSelectType_g;
	}

}