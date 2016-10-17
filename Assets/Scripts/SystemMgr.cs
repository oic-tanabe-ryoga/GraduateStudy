
//　ゲームプログラマー３年制コース　田邉崚雅
//　システムマネージャー管理クラス

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SystemMgr : MonoBehaviour {

	private enum SceneNo{
		Title,
		Menu,
		Strengthen,
		Main,
		MultiMain,
		StageSelect,
		Clear,
		Over,
		Loading,
	}SceneNo sceneNo_p;
	public enum SystemTiming{
		ProcessStart,
		ProcessNow,
		ProcessEnd,
	}public static SystemTiming systemTiming_g;
	public static bool sceneMoveUsabale;
		
	void Awake () {
		IsInitialization ();
	}

	void Update () {
		switch (systemTiming_g) {
		case SystemTiming.ProcessStart:
			ProcessStart ();
			break;
		case SystemTiming.ProcessNow:
			if (sceneMoveUsabale == true) {
				IsSceneManagement ();
				sceneMoveUsabale = false;
			}
			break;
		case SystemTiming.ProcessEnd:
			SceneManager.UnloadScene ("Title");
			break;
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void IsInitialization(){
		sceneNo_p = SceneNo.Title;
		systemTiming_g = SystemTiming.ProcessStart;
		sceneMoveUsabale = false;
	}

	/// <summary>
	/// 初期設定
	/// </summary>
	void ProcessStart(){
		systemTiming_g = SystemTiming.ProcessNow;
		SceneManager.LoadScene ("Title", LoadSceneMode.Additive);
	}
		
	/// <summary>
	/// シーン管理
	/// </summary>
	void IsSceneManagement(){
		switch (sceneNo_p) {
		case SceneNo.Title:
			SceneManager.UnloadScene ("Title");
			SceneManager.LoadScene ("Menu", LoadSceneMode.Additive);
			sceneNo_p = SceneNo.Menu;
			break;
		case SceneNo.Menu:
			SceneManager.UnloadScene ("Menu");
			switch (MenuMgr.menuSelectType_g) {
				case MenuMgr.MenuSelectType.Main:
					SceneManager.LoadScene ("Main", LoadSceneMode.Additive);
					sceneNo_p = SceneNo.Main;
					break;
				case MenuMgr.MenuSelectType.Multi:
					SceneManager.LoadScene ("MultiMain", LoadSceneMode.Additive);
					sceneNo_p = SceneNo.MultiMain;
					break;
				case MenuMgr.MenuSelectType.CharStrengthen:
					SceneManager.LoadScene ("Strengthen", LoadSceneMode.Additive);
					sceneNo_p = SceneNo.Strengthen;
					break;
				case MenuMgr.MenuSelectType.Title:
					SceneManager.LoadScene ("Title", LoadSceneMode.Additive);
					sceneNo_p = SceneNo.Title;
					break;
			}
			break;
		case SceneNo.Strengthen:
			SceneManager.UnloadScene ("Strengthen");
			SceneManager.LoadScene ("Menu", LoadSceneMode.Additive);
			sceneNo_p = SceneNo.Menu;
			break;
		case SceneNo.StageSelect:
			SceneManager.LoadScene ("StageSelect", LoadSceneMode.Additive);
			break;
		case SceneNo.Main:
			SceneManager.LoadScene ("Main", LoadSceneMode.Additive);
			break;
		case SceneNo.MultiMain:
			SceneManager.LoadScene ("MultiMain", LoadSceneMode.Additive);
			break;
		case SceneNo.Clear:
			SceneManager.LoadScene ("Clear", LoadSceneMode.Additive);
			break;
		case SceneNo.Over:
			SceneManager.LoadScene ("Over", LoadSceneMode.Additive);
			break;
		/*case SceneNo.Loading:
			SceneManager.LoadScene ("Loading", LoadSceneMode.Additive);
			break;
			*/
		}
	}
}