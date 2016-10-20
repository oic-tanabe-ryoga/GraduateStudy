
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
	private float loadTime	=	0.0f;
	public enum SystemTiming{
		ProcessStart,
		ProcessNow,
		ProcessEnd,
	}public static SystemTiming systemTiming_g;
	public static bool sceneMoveUsabale;
	public static bool loadBackBoradUsabale;
	public GameObject LoadView;
		
	void Awake () {
		IsInitialization ();
	}

	void Update () {
		switch (systemTiming_g) {
		case SystemTiming.ProcessStart:
			ProcessStart ();
			break;
		case SystemTiming.ProcessNow:
			loadTime += Time.deltaTime;
			if (loadTime >= 3.0f) {
				if (sceneMoveUsabale == true) {
					IsSceneManagement ();
					sceneMoveUsabale = false;
				}
				loadTime = 0.0f;
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
		var newLoadView = Instantiate (LoadView,new Vector3(0, 0, 0), Quaternion.identity);
		newLoadView.name = "LoadView";
		loadBackBoradUsabale = false;
		loadTime = 0.0f;
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
					SceneManager.LoadScene ("StageSelect", LoadSceneMode.Additive);
					sceneNo_p = SceneNo.StageSelect;
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
			SceneManager.UnloadScene ("StageSelect");
			switch (StageSelectMgr.selectingClass_g) {
			case StageSelectMgr.SelectingClass.Sexual:
				SceneManager.LoadScene ("Menu", LoadSceneMode.Additive);
				sceneNo_p = SceneNo.Menu;
				break;
			case StageSelectMgr.SelectingClass.Stage:
				SceneManager.LoadScene ("Main", LoadSceneMode.Additive);
				sceneNo_p = SceneNo.Main;
				break;
			}
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
		}
	}
}