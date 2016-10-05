
//　ゲームプログラマー３年制コース　田邉崚雅
//　システムマネージャー管理クラス

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SystemMgr : MonoBehaviour {

	private enum sceneNo{
		Title,
		Menu,
		Strengthen,
		Main,
		MultiMain,
		StageSelect,
		Clear,
		Over,
		Loading,
	}sceneNo sceneNo_p;

	void Awake () {
		IsInitialization ();
	}

	void Update () {
		if (GlobalVariable.sceneMoveUsabale == true) {
			IsSceneManagement ();
			GlobalVariable.sceneMoveUsabale = false;
		}
		TestSceneMgr ();
	}

	/// <summary>
	/// 初期化
	/// </summary>
	void IsInitialization(){
		sceneNo_p = sceneNo.Title;
	}

	/// <summary>
	/// シーン管理
	/// </summary>
	void IsSceneManagement(){
		switch (sceneNo_p) {
		case sceneNo.Title:
			SceneManager.LoadScene ("Title", LoadSceneMode.Additive);
			break;
		case sceneNo.Loading:
			SceneManager.LoadScene ("Loading",LoadSceneMode.Additive);
			break;
		case sceneNo.Menu:
			SceneManager.LoadScene ("Menu",LoadSceneMode.Additive);
			break;
		case sceneNo.Strengthen:
			SceneManager.LoadScene ("Strengthen",LoadSceneMode.Additive);
			break;
		case sceneNo.Main:
			SceneManager.LoadScene ("Main",LoadSceneMode.Additive);
			break;
		case sceneNo.MultiMain:
			SceneManager.LoadScene ("MultiMain",LoadSceneMode.Additive);
			break;
		case sceneNo.StageSelect:
			SceneManager.LoadScene ("StageSelect",LoadSceneMode.Additive);
			break;
		case sceneNo.Clear:
			SceneManager.LoadScene ("Clear",LoadSceneMode.Additive);
			break;
		case sceneNo.Over:
			SceneManager.LoadScene ("Over",LoadSceneMode.Additive);
			break;
		}
	}
	void TestSceneMgr(){
		if (InputMgr.fire6==true||Input.GetKeyDown(KeyCode.Space)) {
			switch (sceneNo_p) {
			case sceneNo.Title:
				if (TitleMgr.titleSelectType_g == TitleMgr.TitleSelectType.Start ||
				   TitleMgr.titleSelectType_g == TitleMgr.TitleSelectType.Continue)
					sceneNo_p = sceneNo.Menu;
				SceneManager.UnloadScene ("Title");
				break;
			case sceneNo.Loading:
				SceneManager.UnloadScene ("Loading");
				break;
			case sceneNo.Menu:
				if (MenuMgr.menuSelectType_g == MenuMgr.MenuSelectType.Main) {
					sceneNo_p = sceneNo.Main;
				} else if (MenuMgr.menuSelectType_g == MenuMgr.MenuSelectType.Multi) {
					sceneNo_p = sceneNo.MultiMain;
				} else if (MenuMgr.menuSelectType_g == MenuMgr.MenuSelectType.CharStrengthen) {
					sceneNo_p = sceneNo.Strengthen;
				} else if (MenuMgr.menuSelectType_g == MenuMgr.MenuSelectType.Title) {
					sceneNo_p = sceneNo.Title;
				}
				SceneManager.UnloadScene ("Menu");
				break;
			case sceneNo.Strengthen:
				sceneNo_p = sceneNo.Menu;
				SceneManager.UnloadScene ("Strengthen");
				break;
			case sceneNo.Main:
				sceneNo_p = sceneNo.StageSelect;
				SceneManager.UnloadScene ("Main");
				break;
			case sceneNo.MultiMain:
				sceneNo_p = sceneNo.Over;
				SceneManager.UnloadScene ("MultiMain");
				break;
			case sceneNo.StageSelect:
				sceneNo_p = sceneNo.Clear;
				SceneManager.UnloadScene ("StageSelect");
				break;
			case sceneNo.Clear:
				sceneNo_p = sceneNo.Menu;
				SceneManager.UnloadScene ("Clear");
				break;
			case sceneNo.Over:
				sceneNo_p = sceneNo.Menu;
				SceneManager.UnloadScene ("Over");
				break;
			}
				GlobalVariable.sceneMoveUsabale = true;
		}
	}
}