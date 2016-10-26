
//　ゲームプログラマー３年制コース　田邉崚雅
//　メニュー画面キャラ描画統括クラス

using UnityEngine;
using System.Collections;

public class MenuChar : MonoBehaviour {
	public GameObject[] charObjs;
	private GameObject charObj;
	private int charNo=0;
	private int randomNo=0;

	void Awake(){
		Initialize ();
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
	void Initialize(){
		charNo = charObjs.Length;
		if (charNo != 0) {
			randomNo = Random.Range (0, charNo);
			charObj = Instantiate (charObjs [randomNo]);
			charObj.transform.parent = this.gameObject.transform;
		}
		Debug.Log (charNo);
		Debug.Log (randomNo);
	}

}
