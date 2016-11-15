using UnityEngine;
using System.Collections;

public class EnemyMgr : MonoBehaviour {
	public GameObject[] enemyArray;
	private GameObject enemyObj;
	//エネミー最大表示数
	public int enemyCountMax=10;
	private int enemyCount=0;
	//エネミー数
	private int enemyLastNo;
	//表示されているエネミーの中で最も割り振られている番号が高いものを入れる
	private int enemyNowNo;
	private GameObject viewMgr;


	void Awake () {
		EnemyMgrInitialize ();
		SetEnemy ();
	}
	
	void Update () {
		EnemyCreate ();
	}
	void EnemyMgrInitialize(){
		enemyLastNo = enemyArray.Length;
		enemyNowNo = 0;
		enemyCount = 0;
		viewMgr = GameObject.Find("ViewMgr");
	}
	void SetEnemy(){
		for (enemyCount = 0; enemyCount < enemyCountMax &&
			enemyCount < enemyLastNo; enemyCount++,enemyNowNo++) {
			enemyObj = Instantiate(enemyArray [enemyCount]);
			enemyObj.transform.parent = viewMgr.gameObject.transform;
			enemyObj.name = ("enemyNo"+enemyNowNo);
		}
	}
	public void EnemyBreak(){
		enemyCount--;
	}
	void EnemyCreate(){
		if (enemyCount < enemyCountMax && enemyNowNo < enemyLastNo) {
			enemyObj = Instantiate(enemyArray [enemyNowNo]);
			enemyObj.transform.parent = viewMgr.gameObject.transform;
			enemyObj.name = ("enemyNo"+enemyNowNo);
			enemyCount++;
			enemyNowNo++;
		}
	}
}
