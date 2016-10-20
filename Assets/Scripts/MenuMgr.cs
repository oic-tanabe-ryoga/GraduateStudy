
//　ゲームプログラマー３年制コース　田邉崚雅
//　メニュー画面管理クラス

using UnityEngine;
using System.Collections;
using System;

public class MenuMgr : MonoBehaviour {
	private enum MenuTiming{
		ProcessStart,
		ProcessNow,
		ProcessEnd,
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

	void Start () {
		MenuInitialize ();
	}
	
	void Update () {
		switch (menuTiming_p) {
		case MenuTiming.ProcessStart:
			menuTiming_p = MenuTiming.ProcessNow;
			break;
		case MenuTiming.ProcessNow:
			if (canInputUsabale == true) {
				MenuInput ();
			} else {
				MenuTimeControl ();
				ReturnInitilize ();
			}
			TestText ();
			break;
		case MenuTiming.ProcessEnd:
			//SystemMgr.TrueBack ();
			SystemMgr.sceneMoveUsabale = true;
			break;
		}
	}

	/// <summary>
	/// タイトル初期化
	/// </summary>
	void MenuInitialize (){
		menuTiming_p = MenuTiming.ProcessStart;
		menuSelectType_g = MenuSelectType.Main;
		canInputUsabale = true;
		SystemMgr.loadBackBoradUsabale = false;
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
		if (InputMgr.fire6 == true || Input.GetKeyDown (KeyCode.Space)) {
			menuTiming_p = MenuTiming.ProcessEnd;
			SystemMgr.loadBackBoradUsabale = true;
		}
	}

	/// <summary>
	/// メニューテスト用表示
	/// </summary>
	void TestText(){
		this.GetComponent<GUIText>().text = "TestText"+menuSelectType_g;
	}

}