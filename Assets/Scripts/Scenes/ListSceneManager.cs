using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSceneManager : MonoBehaviour {

	private ListViewManager ListView = new ListViewManager ();

	// Use this for initialization
	void Start () {
		ScrollItemManager ScrollManager = FindObjectOfType<ScrollItemManager> ();

		if (ScrollManager == null) {
			Debug.LogError ("Can't find ScrollItemManager!");
		}

		ScrollManager.onItemChanged.AddListener (OnUpdateItem);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnUpdateItem(int index, GameObject obj) {
		Debug.LogError ("Item Change Index : " + index);
	}
}
