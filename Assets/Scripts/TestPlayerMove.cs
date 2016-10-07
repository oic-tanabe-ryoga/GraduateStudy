
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
			if (InputMgr.vertical > 0.3f)
				transform.position += transform.forward * 0.01f;
			else if (InputMgr.vertical < -0.3f)
				transform.position -= transform.forward * 0.01f;
			else {
			}
		}
		if (InputMgr.horizontal!=0.0f) {
			if (InputMgr.horizontal > 0.3f)
				transform.position += transform.right * 0.01f;
			else if (InputMgr.horizontal < -0.3f)
				transform.position -= transform.right * 0.01f;
			else {
			}
		}
	}
}