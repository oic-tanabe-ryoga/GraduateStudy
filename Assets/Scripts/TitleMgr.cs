using UnityEngine;
using System.Collections;

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
	}public static TitleSelectType titleSelectType_g;

	private bool canInputUsabale;

	void Start () {
		TitleInitialize ();
	}
	
	void Update () {
		switch (titleTiming_p) {
		case TitleTiming.ProcessingStart:
			TitleStartSet ();
			break;

		case TitleTiming.ProcessingNow:
			if (canInputUsabale == true) {
				TitleInput ();
			} else {
				Invoke ("TitleTimeControl", 1.0f);
			}
			TestText ();
			break;

		case TitleTiming.ProcessingEnd:
			break;
		}
	}

	void TitleInitialize (){
		titleTiming_p = TitleTiming.ProcessingStart;
		titleSelectType_g = TitleSelectType.Start;
		canInputUsabale = true;
	}
	void TitleStartSet(){
		titleSelectType_g = TitleSelectType.Start;
		titleTiming_p = TitleTiming.ProcessingNow;
	}
	void TitleTimeControl(){
		canInputUsabale = true;
	}
	void TitleInput(){
		if (InputMgr.vertical <= -0.5f || InputMgr.vertical >=0.5f) {
			canInputUsabale = false;
			switch (titleSelectType_g) {
			case TitleSelectType.Start:
				titleSelectType_g = TitleSelectType.Continue;
				break;
			case TitleSelectType.Continue:
				titleSelectType_g = TitleSelectType.Start;
				break;
			}
		}
	}
	void TestText(){
		this.GetComponent<GUIText>().text = "TestText"+titleSelectType_g;
	}
}
