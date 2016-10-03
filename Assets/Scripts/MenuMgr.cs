using UnityEngine;
using System.Collections;

//　ゲームプログラマー３年制コース　田邉崚雅
//　メニュー画面管理クラス
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

	void Awake(){
		SetPlayerData ();
	}

	void Start () {
		menuTiming_p = MenuTiming.ProcessingStart;
	}
	
	void Update () {
		switch (menuTiming_p) {
		case MenuTiming.ProcessingStart:
			menuTiming_p = MenuTiming.ProcessingNow;
			break;
		case MenuTiming.ProcessingNow:
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

}