//2年 吉田 龍矢
//敵に関してのクラス
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public Vector3 enemy;
    public Vector3 playerPos;
    public int enemySpeed = 2;

    // Use this for initialization
    void Start () {

        enemy = transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {

        IsEnemyMove();

    }

    public void IsEnemyMove(){

        playerPos = player.transform.position;
        float leftMaxAccess = playerPos.x + 2;
        float rightMaxAccess = playerPos.x - 2;

        if (playerPos.x < enemy.x & leftMaxAccess < enemy.x){
                enemy.x -= enemySpeed * Time.deltaTime;
            } else if(playerPos.x > enemy.x & rightMaxAccess > enemy.x) {
                enemy.x += enemySpeed * Time.deltaTime;
            Debug.Log("hidari");
            }
            transform.position = enemy;

        if (playerPos.z != enemy.z & leftMaxAccess > enemy.x &rightMaxAccess < enemy.x){
            Debug.Log("Z座標をPlayerに合わせます");
            if (playerPos.z > enemy.z){
                enemy.z += 1;
                Debug.Log("Z:up");
            } else {
                enemy.z -= 1;
                Debug.Log("Z;down");
            }
        }
    }
}
