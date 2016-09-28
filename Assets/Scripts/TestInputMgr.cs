using UnityEngine;
using System.Collections;

public class TestInputMgr : MonoBehaviour {
	private enum InputType{
		TypeA,
		TypeB,
	}
	[SerializeField]
	private InputType InputType_p=InputType.TypeA;

	private string lb = "\n";
		
	void Update () {
		if (InputType_p == InputType.TypeA) {
			InputTypeAText ();
		} else if (InputType_p == InputType.TypeB) {
			InputTypeBText ();
		}
	}

	void InputTypeAText(){
		this.GetComponent<GUIText>().text = "<<  GetMouseButton  >>" + lb;

		this.GetComponent<GUIText>().text += "Left : " + InputMgr.mouseLeftButton + lb;
		this.GetComponent<GUIText>().text += "Right : " + InputMgr.mouseRightButton + lb;
		this.GetComponent<GUIText>().text += "Wheel : " + InputMgr.mouseWheelButton + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetMouseButtonDown  >>" + lb;

		this.GetComponent<GUIText>().text += "Left : " + InputMgr.mouseLeftButtonDown + lb;
		this.GetComponent<GUIText>().text += "Right : " + InputMgr.mouseRightButtonDown + lb;
		this.GetComponent<GUIText>().text += "Wheel : " + InputMgr.mouseWheelButtonDown + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetMouseButtonUp  >>" + lb;

		this.GetComponent<GUIText>().text += "Left : " + InputMgr.mouseLeftButtonUp + lb;
		this.GetComponent<GUIText>().text += "Right : " + InputMgr.mouseRightButtonUp + lb;
		this.GetComponent<GUIText>().text += "Wheel : " + InputMgr.mouseWheelButtonUp + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetKey,Down,Up  >>" + lb;

		this.GetComponent<GUIText>().text += "'W' : " + InputMgr.wKey + lb;
		this.GetComponent<GUIText>().text += "'A' : " + InputMgr.aKey + lb;
		this.GetComponent<GUIText>().text += "'S' : " + InputMgr.sKey + lb;
		this.GetComponent<GUIText>().text += "'D' : " + InputMgr.dKey + lb +lb;

		this.GetComponent<GUIText>().text += "<<  GetButton  >>" + lb;

		this.GetComponent<GUIText>().text += "Fire1 = MouseLeft or LeftCtrl : " + InputMgr.fire1 + lb;
		this.GetComponent<GUIText>().text += "Fire2 = MouseLeft or LeftAlt : " + InputMgr.fire2 + lb;
		this.GetComponent<GUIText>().text += "Fire3 = MouseLeft or LeftCmd :  : " + InputMgr.fire3 + lb;
		this.GetComponent<GUIText>().text += "Fire3 = MouseLeft or LeftCmd :  : " + InputMgr.fire4 + lb;

	}
	void InputTypeBText(){
		this.GetComponent<GUIText>().text = "<<  GetAxis(MouseWheel)  >>" + lb;
		this.GetComponent<GUIText>().text += "Scroll : " + InputMgr.mouseWheelScroll + lb + lb;

		this.GetComponent<GUIText>().text += "<<  MousePosition(MouseWheel)  >>" + lb;

		this.GetComponent<GUIText>().text += "MousePos : " + InputMgr.mousePosition + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetAxis(MouseX,Y)  >>" + lb;

		this.GetComponent<GUIText>().text += "MouseX : " + InputMgr.mouseX + lb;
		this.GetComponent<GUIText>().text += "MouseY : " + InputMgr.mouseY + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetAxisRaw(MouseX,Y)  >>" + lb;

		this.GetComponent<GUIText>().text += "MouseX-Raw: " + InputMgr.mouseXraw + lb;
		this.GetComponent<GUIText>().text += "MouseY-Raw: " + InputMgr.mouseYraw + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetAxis(Horizontal,Vertical)  >>" + lb;

		this.GetComponent<GUIText>().text += "Horizontal : " + InputMgr.horizontal + lb;
		this.GetComponent<GUIText>().text += "Vertical : " + InputMgr.vertical + lb + lb;

		this.GetComponent<GUIText>().text += "<<  GetAxisRaw(Horizontal,Vertical)  >>" + lb;

		this.GetComponent<GUIText>().text += "Horizontal Raw: " + InputMgr.horizontalRaw + lb;
		this.GetComponent<GUIText>().text += "Vertical Raw: " + InputMgr.verticalRaw + lb;

	}
}
