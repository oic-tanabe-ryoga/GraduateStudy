
//　ゲームプログラマー３年制コース　田邉崚雅
//　ビュー統括クラス

using UnityEngine;
using System.Collections;

public class ViewMgr : MonoBehaviour {
	private EnemyMoveTest[] TestObject=new EnemyMoveTest[10];
	private bool CanSearch = true;
	public int charNo=0;
	void Awake(){
		charNo = 0;
	}

	void Start () {
		foreach (Transform child in transform) {
			Debug.Log ("CHILD" + child.name);
			charNo++;
			if (child.tag=="Player1"){
				//TestObject [charNo] = GameObject.Find (child.name).GetComponent<TestPlayerMove> ();
			} else if(child.tag=="Player2"){
			}
			else {
				TestObject [charNo] = GameObject.Find (child.name).GetComponentInChildren<EnemyMoveTest>();
			}
		}
	}

	void Update(){
		for (int i = 1; i < this.gameObject.transform.childCount-1; i++) {
			/*if (TestObject [i].gameObject.transform.position.z < TestObject [i+1].gameObject.transform.position.z) {
				TestObject [0] = TestObject [i];
				TestObject [i] = TestObject [i+1];
				TestObject [i+1] = TestObject [0];
			}*/
		}
	}

	void OnRenderObject(){
		for (int i = 2; i < this.gameObject.transform.childCount+1; i++) {
			//TestObject [i].Rending();
			TestObject[i].Test();
			Debug.Log (TestObject [i].TestMgrCount);
		}
	}
}
