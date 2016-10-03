using UnityEngine;
using System.Collections;
using System;

//　ゲームプログラマー３年制コース　田邉崚雅
//　タイトル画面管理クラス
public class TitleMgr : MonoBehaviour {
	private enum TitleTiming{
		ProcessingStart,
		ProcessingNow,
		ProcessingEnd,
	}TitleTiming titleTiming_p;
	public enum TitleSelectType{
		Start,
		Continue,
		End,
	}public static TitleSelectType titleSelectType_g;
	private bool canInputUsabale;
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
		case TitleTiming.ProcessingStart:
			titleTiming_p = TitleTiming.ProcessingNow;
			break;

		case TitleTiming.ProcessingNow:
			if (canInputUsabale == true) {
				TitleInput ();
			} else {
				TitleTimeControl ();
				ReturnInitilize ();
			}
			TestText ();
			break;

		case TitleTiming.ProcessingEnd:
			break;
		}
	}

	/// <summary>
	/// タイトル初期化
	/// </summary>
	void TitleInitialize (){
		titleTiming_p = TitleTiming.ProcessingStart;
		titleSelectType_g = TitleSelectType.Start;
		canInputUsabale = true;
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
			switch (titleSelectType_g) {
			case TitleSelectType.Start:
				titleSelectType_g = TitleSelectType.Continue;
				break;
			case TitleSelectType.Continue:
				titleSelectType_g = TitleSelectType.End;
				break;
			case TitleSelectType.End:
				titleSelectType_g = TitleSelectType.Start;
				break;
			}
		}
		if (InputMgr.vertical >= 0.5f) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (titleSelectType_g) {
			case TitleSelectType.Start:
				titleSelectType_g = TitleSelectType.End;
				break;
			case TitleSelectType.Continue:
				titleSelectType_g = TitleSelectType.Start;
				break;
			case TitleSelectType.End:
				titleSelectType_g = TitleSelectType.Continue;
				break;
			}
		}
		TestSaveData ();
	}
	void TestText(){
		this.GetComponent<GUIText>().text = "TestText"+titleSelectType_g+"Test"+testSaveData;
	}
	void TestSaveData(){
		if (InputMgr.fire8)
			testSaveData++;
	}
}
