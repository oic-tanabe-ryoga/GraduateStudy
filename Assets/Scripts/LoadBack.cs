using UnityEngine;
using System.Collections;

public class LoadBack : MonoBehaviour {
	
	void Update () {
		SetValiable ();
	}
	void SetValiable(){
		this.gameObject.GetComponent<Renderer> ().enabled = SystemMgr.loadBackBoradUsabale;
	}
}
