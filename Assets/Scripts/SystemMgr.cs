using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//　ゲームプログラマー３年制コース　田邉崚雅
//　システムマネージャー管理クラス
public class SystemMgr : MonoBehaviour {

	private enum sceneNo{
		Title,
		Loading,
		Menu,
		Strengthen,
		Main,
		MultiMain,
		StageSelect,
		Clear,
		Over,
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
				SceneManager.UnloadScene ("Title");
				break;
			case sceneNo.Loading:
				SceneManager.UnloadScene ("Loading");
				break;
			case sceneNo.Menu:
				SceneManager.UnloadScene ("Menu");
				break;
			case sceneNo.Strengthen:
				SceneManager.UnloadScene ("Strengthen");
				break;
			case sceneNo.Main:
				SceneManager.UnloadScene ("Main");
				break;
			case sceneNo.MultiMain:
				SceneManager.UnloadScene ("MultiMain");
				break;
			case sceneNo.StageSelect:
				SceneManager.UnloadScene ("StageSelect");
				break;
			case sceneNo.Clear:
				SceneManager.UnloadScene ("Clear");
				break;
			case sceneNo.Over:
				SceneManager.UnloadScene ("Over");
				break;
			}
				sceneNo_p++;
			if (sceneNo_p > sceneNo.Over) {
				sceneNo_p = sceneNo.Title;
			}
				GlobalVariable.sceneMoveUsabale = true;
		}
	}
}