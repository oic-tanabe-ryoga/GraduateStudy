
//　ゲームプログラマー３年制コース　田邉崚雅
//　インプット管理クラス

using UnityEngine;
using System.Collections;

public class InputMgr : MonoBehaviour {
	public static bool mouseLeftButton;
	public static bool mouseRightButton;
	public static bool mouseWheelButton;
	public static bool mouseLeftButtonDown;
	public static bool mouseRightButtonDown;
	public static bool mouseWheelButtonDown;
	public static bool mouseLeftButtonUp;
	public static bool mouseRightButtonUp;
	public static bool mouseWheelButtonUp;
	public static bool wKey;
	public static bool aKey;
	public static bool sKey;
	public static bool dKey;
	public static bool fire1;
	public static bool fire2;
	public static bool fire3;
	public static bool fire4;
	public static bool fire5;
	public static bool fire6;
	public static bool fire7;
	public static bool fire8;
	public static Vector3 mousePosition;
	public static float mouseWheelScroll;
	public static float mouseX;
	public static float mouseY;
	public static float mouseXraw;
	public static float mouseYraw;
	public static float horizontal;
	public static float vertical;
	public static float horizontalRaw;
	public static float verticalRaw;

	void Update () {
		InputBottonTypeA ();
		InputBottonTypeB ();
	}

	/// <summary>
	/// キーボードやマウスその他キーパッドのボタンの入力用
	/// WASDキーやマウスのクリックその他キーパッドの右側のボタン入力に対応しています。
	/// </summary>
	void InputBottonTypeA(){

		//[1]ボタンが押されているかどうかを取得する
		mouseLeftButton = Input.GetMouseButton(0); 
		mouseRightButton = Input.GetMouseButton(1);
		mouseWheelButton = Input.GetMouseButton(2);
	
		//[2]ボタンが"1回"押されたかどうかを取得する
		mouseLeftButtonDown = Input.GetMouseButtonDown(0);
		mouseRightButtonDown = Input.GetMouseButtonDown(1);
		mouseWheelButtonDown = Input.GetMouseButtonDown(2);
	
		//[3]ボタンが"1回"離されたかどうかを取得する
		mouseLeftButtonUp = Input.GetMouseButtonUp(0);
		mouseRightButtonUp = Input.GetMouseButtonUp(1);
		mouseWheelButtonUp = Input.GetMouseButtonUp(2);
	
		//[4]キーボードの場合
		wKey = Input.GetKey(KeyCode.W);
		aKey = Input.GetKey(KeyCode.A);
		sKey = Input.GetKey(KeyCode.S);
		dKey = Input.GetKey(KeyCode.D);
	
		//[5]プロジェクトに当てられた入力設定での取得する
		//マウスとキーボードの両方を同じボタンに当てることができる
		//キーボードでは、"Fire1=(Left)Ctrl", "Fire2=(Left)Alt", "(Left)Cmd"となっている
		fire1 = Input.GetButton("Fire1");
		fire2 = Input.GetButton("Fire2");
		fire3 = Input.GetButton("Fire3");
		fire4 = Input.GetButton("Fire4");

		fire5 = Input.GetButtonDown("Fire1");
		fire6 = Input.GetButtonDown("Fire2");
		fire7 = Input.GetButtonDown("Fire3");
		fire8 = Input.GetButtonDown("Fire4");
	}

	/// <summary>
	/// キーボードやマウスその他キーパッドの移動用
	/// キーボードの矢印キーやマウス移動その他キーパッドのジョイスティックに対応しています。
	/// </summary>

	void InputBottonTypeB (){
		//[6]マウスホイールの回転を取得する
		mouseWheelScroll = Input.GetAxis("Mouse ScrollWheel");

		//[7]マウスの座標を取得する(左下が原点)
		mousePosition = Input.mousePosition;

		//[8]入力の変位を取得する
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");

		//[9]Rawの試験(mouse)では効果が見られず
		mouseXraw = Input.GetAxisRaw("Mouse X");
		mouseYraw = Input.GetAxisRaw("Mouse Y");

		//[10]入力の変位を取得する(Keyboard ver.)
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		//[11]Rawの試験(Smoothingされないので-1か1か0になる)
		horizontalRaw = Input.GetAxisRaw("Horizontal");
		verticalRaw = Input.GetAxisRaw("Vertical");
	}
}
