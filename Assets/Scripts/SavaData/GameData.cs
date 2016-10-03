using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class GameData : SingletonMonoBehaviour<GameData>{

	//セーブデータ
	class SaveData: SavableSingleton<SaveData>{

		public int malePlayerLife;
		public int malePlayerAttack;
		public int malePlayerDiffence;
		public int femalePlayerLife;
		public int femalePlayerAttack;
		public int femalePlayerDiffence;
		public int captureNo;//ステージクリア数

		public SaveData(){
			malePlayerLife = 10;
			malePlayerAttack = 10;
			malePlayerDiffence = 10;
			femalePlayerLife = 10;
			femalePlayerAttack = 10;
			femalePlayerDiffence = 10;
			captureNo = 0;
		}
	}
	public static void Save(){
		SaveData.Save ();
	}
	public static void Reset(){
		SaveData.Reset ();
		malePlayerLife = 10;
		malePlayerAttack = 10;
		malePlayerDiffence = 10;
		femalePlayerLife = 10;
		femalePlayerAttack = 10;
		femalePlayerDiffence = 10;
		captureNo = 0;
	}
		
	public static int malePlayerLife{
		get{return SaveData.Instance.malePlayerLife;}
		set{ SaveData.Instance.malePlayerLife = value; }
	}
	public static int malePlayerAttack{
		get{return SaveData.Instance.malePlayerAttack;}
		set{ SaveData.Instance.malePlayerAttack = value; }
	}
	public static int malePlayerDiffence{
		get{return SaveData.Instance.malePlayerDiffence;}
		set{ SaveData.Instance.malePlayerDiffence = value; }
	}
	public static int femalePlayerLife{
		get{return SaveData.Instance.femalePlayerLife;}
		set{ SaveData.Instance.femalePlayerLife = value; }
	}
	public static int femalePlayerAttack{
		get{return SaveData.Instance.femalePlayerAttack;}
		set{ SaveData.Instance.femalePlayerAttack = value; }
	}
	public static int femalePlayerDiffence{
		get{return SaveData.Instance.femalePlayerDiffence;}
		set{ SaveData.Instance.femalePlayerDiffence = value; }
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