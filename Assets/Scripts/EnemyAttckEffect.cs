using UnityEngine;
using System.Collections;

public class EnemyAttckEffect : MonoBehaviour {

	public enum EffectTime{
		ProccessStart,
		ProccessNow,
		ProccessEnd,
	}public EffectTime effectTime_g;

	void Start () {
		effectTime_g = EffectTime.ProccessStart;
	}
	
	// Update is called once per frame
	void Update () {
		switch (effectTime_g) {
		case EffectTime.ProccessStart:
			effectTime_g = EffectTime.ProccessNow;
			break;
		case EffectTime.ProccessNow:
			effectTime_g = EffectTime.ProccessEnd;
			break;
		case EffectTime.ProccessEnd:
			this.gameObject.transform.GetComponentInParent<EnemyMoveTest>().CanAttack();
			Destroy (this.gameObject);
			break;
		}
	}
}
