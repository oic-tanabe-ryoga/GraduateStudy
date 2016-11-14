using UnityEngine;
using System.Collections;

public class EnemyParent : MonoBehaviour {
	public GameObject childPosition;
	void Start () {
		//childPosition = transform.FindChild ("Move").transform.position;
	}
	void Update(){
		this.transform.position = childPosition.transform.position;
	}
}
