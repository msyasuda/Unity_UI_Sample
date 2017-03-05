using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListViewManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnItemChanged(int index,  RectTransform item) {
		if (item == null) {
			return;
		}

		// アイテム変更
		item.GetComponentInChildren<Text> ().text = "peropero";
	}

	void SwitchType(int type) {
	}

	void Refresh() {
		
	}
}
