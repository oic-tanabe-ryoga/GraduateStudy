using UnityEngine;
using System.Collections;

//　ゲームプログラマー３年制コース　田邉崚雅
//　グローバル変数管理クラス
public class GlobalVariable : MonoBehaviour {
	static public bool sceneMoveUsabale;

	void Awake(){
		IsInitialization ();
	}
	void IsInitialization(){
		sceneMoveUsabale = true;
	}

}
