
//　ゲームプログラマー３年制コース　田邉崚雅
//　プレイヤー強化シーンクラス

using UnityEngine;
using System.Collections;
using System;

public class StrengthMgr : MonoBehaviour {
	private int maleHP;
	private int maleAT;
	private int maleDF;
	private int maleFG;
	private int femaleHP;
	private int femaleAT;
	private int femaleDF;
	private int femaleFG;
	private int addStatus;

	private bool canInputUsabale;
	private bool canSaving;
	private TimeSpan allowTime = new TimeSpan (0, 0, 1);
	private TimeSpan pastTime;
	private DateTime reloadTime;


	private enum StrengthTiming{
		ProcessingStart,
		ProcessingNow,
		ProcessingEnd,
	}StrengthTiming strengthTiming_p;
	private enum StatusType{
		HP,
		AT,
		DF,
		FG,
	} StatusType statusType_p;
	private enum SexualType{
		Male,
		Female,
		ProcessingEnd,
	}SexualType sexualType_p;
	private enum SelectingClass{
		Sexual,
		Status,
		AddControl,
	}SelectingClass selectingClass_p;
	void Awake(){
		SetPlayerStatus ();
	}
	void Start () {
		StrengthInitialize ();
	}

	void Update () {
		switch (strengthTiming_p) {
		case StrengthTiming.ProcessingStart:
			strengthTiming_p = StrengthTiming.ProcessingNow;
			break;
		case StrengthTiming.ProcessingNow:
			if (canInputUsabale == true) {
				switch (selectingClass_p) {
				case SelectingClass.Sexual:
					SelectingSexual ();
					break;
				case SelectingClass.Status:
					SelectingStatus ();
					break;
				case SelectingClass.AddControl:
					if (InputMgr.fire7 == true) {
						StrengthgCalculation ();
					}
					break;
				}
			} else {
				StrengthTimeControl ();
				ReturnInitilize ();
			}
			if (canSaving == false)
				canSaving = true;
			InputType ();
			TestText ();
			break;
		case StrengthTiming.ProcessingEnd:
			if (canSaving == true) {
				SavingStrength ();
				canSaving = false;
			}
			SystemMgr.sceneMoveUsabale = true;
			SystemMgr.loadBackBoradUsabale = true;
			break;
		}
	}

	/// <summary>
	/// プレイヤーの初期値セット
	/// </summary>
	void SetPlayerStatus(){
		maleHP = GameData.malePlayerLife;
		maleAT = GameData.malePlayerAttack;
		maleDF = GameData.malePlayerDiffence;
		maleFG = GameData.malePlayerFinisherGauge;
		femaleHP = GameData.femalePlayerLife;
		femaleAT = GameData.femalePlayerAttack;
		femaleDF = GameData.femalePlayerDiffence;
		femaleFG = GameData.femalePlayerFinisherGauge;
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void StrengthInitialize(){
		strengthTiming_p = StrengthTiming.ProcessingStart;
		selectingClass_p = SelectingClass.Sexual;
		sexualType_p = SexualType.Male;
		statusType_p = StatusType.HP;
		canInputUsabale = true;
		canSaving = true;
		addStatus = 0;
		SystemMgr.loadBackBoradUsabale = false;
	}

	/// <summary>
	/// 強化終了時の初期化
	/// </summary>
	void ResetAddStatus(){
		addStatus = 0;
	}

	/// <summary>
	/// 強化値セーブ
	/// </summary>
	void SavingStrength(){
		GameData.malePlayerLife				=	maleHP;
		GameData.malePlayerAttack			=	maleAT;
		GameData.malePlayerDiffence			=	maleDF;
		GameData.malePlayerFinisherGauge	=	maleFG;
		GameData.femalePlayerLife			=	femaleHP;
		GameData.femalePlayerAttack 		=	femaleAT;
		GameData.femalePlayerDiffence 		=	femaleDF;
		GameData.femalePlayerFinisherGauge	=	femaleFG;
		GameData.Save ();
		Debug.Log ("セーブしました");
	}

	/// <summary>
	/// 性別判定
	/// </summary>
	void SelectingSexual(){
		if (InputMgr.vertical <= -0.5f) {
			Debug.Log ("Vertical");
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (sexualType_p) {
			case SexualType.Male:
				sexualType_p = SexualType.Female;
				break;
			case SexualType.Female:
				sexualType_p = SexualType.ProcessingEnd;
				break;
			case SexualType.ProcessingEnd:
				sexualType_p = SexualType.Male;
				break;
			}
		}
		if (InputMgr.vertical >= 0.5f) {
			Debug.Log ("Vertical");
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (sexualType_p) {
			case SexualType.Male:
				sexualType_p = SexualType.ProcessingEnd;
				break;
			case SexualType.Female:
				sexualType_p = SexualType.Male;
				break;
			case SexualType.ProcessingEnd:
				sexualType_p = SexualType.Female;
				break;
			}
		}
	}
		
	/// <summary>
	/// 能力判定
	/// </summary>
	void SelectingStatus(){
		if (InputMgr.vertical <= -0.5f) {
			Debug.Log ("Vertical");
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (statusType_p) {
			case StatusType.HP:
				statusType_p = StatusType.AT;
				break;
			case StatusType.AT:
				statusType_p = StatusType.DF;
				break;
			case StatusType.DF:
				statusType_p = StatusType.FG;
				break;
			case StatusType.FG:
				statusType_p = StatusType.HP;
				break;
			}
		}
		if (InputMgr.vertical >= 0.5f) {
			Debug.Log ("Vertical");
			canInputUsabale = false;
			this.reloadTime = DateTime.Now;
			switch (statusType_p) {
			case StatusType.HP:
				statusType_p = StatusType.FG;
				break;
			case StatusType.AT:
				statusType_p = StatusType.HP;
				break;
			case StatusType.DF:
				statusType_p = StatusType.AT;
				break;
			case StatusType.FG:
				statusType_p = StatusType.DF;
				break;
			}
		}
	}

	/// <summary>
	/// 能力強化
	/// </summary>
	void AddStatus(){
		if (sexualType_p == SexualType.Male) {
			switch (statusType_p) {
			case StatusType.HP:
				maleHP+=addStatus;
				break;
			case StatusType.AT:
				maleAT+=addStatus;
				break;
			case StatusType.DF:
				maleDF+=addStatus;
				break;
			case StatusType.FG:
				maleFG+=addStatus;
				break;
			}
		} else if (sexualType_p == SexualType.Female) {
			switch (statusType_p) {
			case StatusType.HP:
				femaleHP+=addStatus;
				break;
			case StatusType.AT:
				femaleAT+=addStatus;
				break;
			case StatusType.DF:
				femaleDF+=addStatus;
				break;
			case StatusType.FG:
				femaleFG+=addStatus;
				break;
			}
		}
	}

	/// <summary>
	/// 強化計算
	/// </summary>
	void StrengthgCalculation(){
		addStatus++;
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
	/// 連打防止
	/// </summary>
	void StrengthTimeControl(){
		pastTime = DateTime.Now - this.reloadTime;
		if(pastTime > allowTime){
			canInputUsabale = true;
		}
	}
	/// <summary>
	/// 入力操作
	/// </summary>
	void InputType(){
		if (InputMgr.fire6 == true || Input.GetKeyDown (KeyCode.Space)) {
			switch(selectingClass_p){
			case SelectingClass.Sexual:
				if(sexualType_p!=SexualType.ProcessingEnd){
				selectingClass_p = SelectingClass.Status;
				}else{
					strengthTiming_p = StrengthTiming.ProcessingEnd;
				}
				break;
			case SelectingClass.Status:
				selectingClass_p = SelectingClass.AddControl;
				break;
			case SelectingClass.AddControl:
				if (canSaving==true) {
					AddStatus ();
					SavingStrength ();
					ResetAddStatus ();
					canSaving = false;
				}
				selectingClass_p = SelectingClass.Sexual;
				break;
			}
		}
		else if (InputMgr.fire5 == true || Input.GetKeyDown (KeyCode.Escape)) {
			switch(selectingClass_p){
			case SelectingClass.Sexual:
				strengthTiming_p = StrengthTiming.ProcessingEnd;
				break;
			case SelectingClass.Status:
				selectingClass_p = SelectingClass.Sexual;
				break;
			case SelectingClass.AddControl:
				ResetAddStatus ();
				selectingClass_p = SelectingClass.Status;
				break;
			}
		}
	}
	/// <summary>
	/// メニューテスト用表示
	/// </summary>
	void TestText(){
		this.GetComponent<GUIText>().text = "SelectingClass"+selectingClass_p+"\n"+
		"SexualType: "+sexualType_p+"\n"+"Status: "+statusType_p+"\n"+"AddValue: "+addStatus+"\n"+
		"maleHP = GameData.malePlayerLife"+maleHP+"="+GameData.malePlayerLife+"\n"+
		"maleAT = GameData.malePlayerAttack"+maleAT+"="+GameData.malePlayerAttack+"\n"+
		"maleDF = GameData.malePlayerDiffence"+maleDF+"="+GameData.malePlayerDiffence+"\n"+
		"maleFG = GameData.malePlayerFinisherGauge"+maleFG+"="+GameData.malePlayerFinisherGauge+"\n"+
		"femaleHP = GameData.femalePlayerLife"+femaleHP+"="+GameData.femalePlayerLife+"\n"+
		"femaleAT = GameData.femalePlayerAttack"+femaleAT+"="+GameData.femalePlayerAttack+"\n"+
		"femaleDF = GameData.femalePlayerDiffence"+femaleDF+"="+GameData.femalePlayerDiffence+"\n"+
		"femaleFG = GameData.femalePlayerFinisherGauge"+femaleFG+"="+GameData.femalePlayerFinisherGauge+"\n";
	}
}