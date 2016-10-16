//2年　吉田　龍矢
//プレイヤーのAIについてのプログラム
using UnityEngine;
using System.Collections;

public class AIPlayer : MonoBehaviour {

    public enum state : int
    {
        AIPlayerMove = 1,
        AIPlayerAttack = 2
    }

    public GameObject mob;
    public int playerRoutineNo = (int)state.AIPlayerMove;
    public int playerMoveSpeed = 0;
    public int playerAttackDamage = 0;
    public Vector3 AIPlayerPosition;
    public Vector3 mobPos;

    void Start () {

        AIPlayerPosition = transform.position;

    }


	void Update () {
        switch (playerRoutineNo)
        {

            case (int)state.AIPlayerMove:
                IsMove();
                if(IsMove() == 1) {
                   Debug.Log(playerRoutineNo);
                   playerRoutineNo = (int)state.AIPlayerAttack;
                }
                break;

            case (int)state.AIPlayerAttack:
                Debug.Log(playerRoutineNo);
                break;
        }
	}

    public int IsMove()
    {
        mobPos = mob.transform.position;
        Debug.Log(mobPos);
        float leftMaxAccess = mobPos.x + 2;
        float rightMaxAccess = mobPos.x - 2;

        if (mobPos.x < AIPlayerPosition.x){
            AIPlayerPosition.x -= playerMoveSpeed * Time.deltaTime;
        }else{
            AIPlayerPosition.x += playerMoveSpeed * Time.deltaTime;
        }

        transform.position = AIPlayerPosition;
        return 0;
    }
}
