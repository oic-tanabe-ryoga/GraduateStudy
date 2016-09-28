using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class GameData : SingletonMonoBehaviour<GameData>{

	//セーブデータ
	class SaveData: SavableSingleton<SaveData>{

		public int playerLife;
		public int playerAttack;
		public int playerDiffence;
		public int captureNo;

		public SaveData(){
			playerLife = 10;
			playerAttack = 10;
			playerDiffence = 10;
			captureNo = 0;
		}
	}
	public static void Save(){
		SaveData.Save ();
	}
	public static void Reset(){
		SaveData.Reset ();
	}
		
	public static int playerLife{
		get{return SaveData.Instance.playerLife;}
		set{ SaveData.Instance.playerLife = value; }
	}
	public static int playerAttack{
		get{return SaveData.Instance.playerAttack;}
		set{ SaveData.Instance.playerAttack = value; }
	}
	public static int playerDiffence{
		get{return SaveData.Instance.playerDiffence;}
		set{ SaveData.Instance.playerDiffence = value; }
	}
	public static int captureNo{
		get{return SaveData.Instance.captureNo;}
		set{ SaveData.Instance.captureNo = value; }
	}


	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}

		DontDestroyOnLoad(this.gameObject);
	}    


	void Start(){
	}

}