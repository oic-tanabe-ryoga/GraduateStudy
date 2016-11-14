
//　ゲームプログラマー３年制コース　田邉崚雅
//　プレイヤーキャラ統括クラス

using UnityEngine;
using System.Collections;

public class PlayerMgr : MonoBehaviour {
	public GameObject[] playerArray;
	private GameObject playerObj;
	private GameObject viewMgr;
	private int playerNo;

	void Start () {
		PlayerInitialize ();
		SetPlayer ();
	}

	void PlayerInitialize(){
		viewMgr = GameObject.Find("ViewMgr");
		playerNo = (int)StageSelectMgr.selectSexual_g;
	}
	void SetPlayer(){
		playerObj = Instantiate(playerArray [playerNo]);
		playerObj.transform.parent = viewMgr.gameObject.transform;
		playerObj.name = ("playerNo"+playerNo);
	}
}
