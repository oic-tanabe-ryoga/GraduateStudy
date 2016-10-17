
//　ゲームプログラマー３年制コース　田邉崚雅
//　テスト用プレイヤー移動クラス

using UnityEngine;
using System.Collections;

public class TestPlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (InputMgr.vertical!=0.0f) {
			transform.position += transform.forward * InputMgr.vertical*Time.deltaTime;
		}
		if (InputMgr.horizontal!=0.0f) {
			transform.position += transform.right * InputMgr.horizontal*Time.deltaTime;
		}
	}
}