using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSceneBase : MonoBehaviour {
	/// <summary>
	/// アイテム変更関数
	/// </summary>
	/// <param name="index">Index.</param>
	/// <param name="obj">Object.</param>
	protected void OnUpdateItem (int index, GameObject obj);
}
