
//　ゲームプログラマー３年制コース　田邉崚雅
//　ステージセレクト画面管理クラス

using UnityEngine;
using System.Collections;
using System;

public class StageSelectMgr : MonoBehaviour {
	private enum SelectTiming{
		ProcessStart,
		ProcessNow,
		ProcessEnd,
	}SelectTiming selectTiming_p;
	public enum SelectingClass{
		Sexual,
		Stage,
	}public static SelectingClass selectingClass_g;
	public enum StageSelectType{
		Stage_1,
		Stage_2,
		Stage_3,
	}public static StageSelectType stageSelectType_g;
	public enum SelectSexual{
		Title,
		male,
		female,
	}public static SelectSexual selectSexual_g;
	private int clearStageNo;
	private bool canInputUsabale;
	private TimeSpan allowTime=new TimeSpan(0,0,1);
	private TimeSpan pastTime;
	private DateTime reloadTime;

	void Start () {
		StageInitialize ();
	}

	void Update () {
		switch (selectTiming_p) {
		case SelectTiming.ProcessStart:
			selectTiming_p = SelectTiming.ProcessNow;
			break;
		case SelectTiming.ProcessNow:
			if (canInputUsabale == true) {
				StageInput ();
				switch(selectingClass_g){
				case SelectingClass.Sexual:
					break;
				case SelectingClass.Stage:
					break;
				}
			} else {
				StageTimeControl ();
				ReturnInitilize ();
			}
			TestText ();
			break;
		case SelectTiming.ProcessEnd:
			SystemMgr.sceneMoveUsabale = true;
			SystemMgr.loadBackBoradUsabale = true;
			break;
		}
	}

	void StageInitialize(){
		clearStageNo=GameData.captureNo;
		selectingClass_g = SelectingClass.Sexual;
		selectTiming_p = SelectTiming.ProcessStart;
		stageSelectType_g = StageSelectType.Stage_1;
		SystemMgr.loadBackBoradUsabale = false;
	}
	/// <summary>
	/// 性別判定
	/// </summary>
	void StageInput(){
		if (InputMgr.vertical <= -0.5f) {
			Debug.Log ("vertical");
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (selectingClass_g) {
			case SelectingClass.Sexual:
				if (selectSexual_g == SelectSexual.male)
					selectSexual_g = SelectSexual.female;
				else if (selectSexual_g == SelectSexual.female)
					selectSexual_g = SelectSexual.Title;
				else if (selectSexual_g == SelectSexual.Title)
					selectSexual_g = SelectSexual.male;
				break;
			case SelectingClass.Stage:
				if ((int)stageSelectType_g == clearStageNo)
					stageSelectType_g = (StageSelectType)clearStageNo;
				else if(stageSelectType_g ==StageSelectType.Stage_3)
					stageSelectType_g = StageSelectType.Stage_3;
				else
					stageSelectType_g++;
				break;
			}
		}
		else if (InputMgr.vertical >= 0.5f) {
			Debug.Log ("Vertical");
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (selectingClass_g) {
			case SelectingClass.Sexual:
				if (selectSexual_g == SelectSexual.male)
					selectSexual_g = SelectSexual.Title;
				else if (selectSexual_g == SelectSexual.female)
					selectSexual_g = SelectSexual.male;
				else if (selectSexual_g == SelectSexual.Title)
					selectSexual_g = SelectSexual.female;
				break;
			case SelectingClass.Stage:
				if (stageSelectType_g == StageSelectType.Stage_1)
					stageSelectType_g = StageSelectType.Stage_1;
				else
					stageSelectType_g--;
				break;
			}
		}
		else if (InputMgr.fire6 == true || Input.GetKeyDown (KeyCode.Space)) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch(selectingClass_g){
			case SelectingClass.Sexual:
				if (selectSexual_g == SelectSexual.Title) {
					selectTiming_p = SelectTiming.ProcessEnd;
					break;
				}
				selectingClass_g = SelectingClass.Stage;
				break;
			case SelectingClass.Stage:
				selectTiming_p = SelectTiming.ProcessEnd;
				break;
			}
		}
		else if (InputMgr.fire5 == true || Input.GetKeyDown (KeyCode.Escape)) {
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch(selectingClass_g){
			case SelectingClass.Sexual:
				selectTiming_p = SelectTiming.ProcessEnd;
				break;
			case SelectingClass.Stage:
				selectingClass_g = SelectingClass.Sexual;
				break;
			}
		}
	}
	/// <summary>
	/// 連打防止
	/// </summary>
	void StageTimeControl(){
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
	void TestText(){
		this.GetComponent<GUIText>().text = "Select"+selectingClass_g+"\n"+
			"SexualType"+selectSexual_g+"\n"+
			"Stage"+stageSelectType_g;
	}
}