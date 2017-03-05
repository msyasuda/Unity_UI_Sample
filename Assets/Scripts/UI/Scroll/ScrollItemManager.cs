using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollItemManager : MonoBehaviour {
	[SerializeField]
	RectTransform ItemBase;

	[SerializeField]
	LinkedList<RectTransform> ItemList = new LinkedList<RectTransform> ();

	[SerializeField]
	int visibleItemCount;

	[System.Serializable]
	public class OnItemChanged : UnityEngine.Events.UnityEvent<int, GameObject> {}

	public OnItemChanged onItemChanged = new OnItemChanged ();

	protected float diffPreFramePosition = 0;

	protected int currentItemIndex = 0;

	private int itemCount = 0;

	private int listCount = 20;

	private RectTransform _rectTransform;
	protected RectTransform rectTransform {
		get {
			if (_rectTransform == null) {
				_rectTransform = GetComponent<RectTransform> ();
				_rectTransform.sizeDelta = new Vector2 (0f, 80 * listCount);
			}
			return _rectTransform;
		}
	}

	private float anchoredPosition
	{
		get {
			return -rectTransform.anchoredPosition.y;
		}
	}

	private float _itemScale = -1;
	public float itemScale {
		get {
			if(ItemBase != null && _itemScale == -1) {
				_itemScale = ItemBase.sizeDelta.y;
			}
			return _itemScale;
		}
	}

	// Use this for initialization
	void Start () {			
		if (listCount > visibleItemCount) {
			itemCount = visibleItemCount + 1;
		}
			
		for (int i = 0; i < itemCount; i++) {
			var item = GameObject.Instantiate (ItemBase) as RectTransform;
			item.SetParent (transform, false);
			item.anchoredPosition = new Vector2(0, -itemScale * i);
			item.gameObject.SetActive (true);
			ItemList.AddLast (item);
		}	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnScrolled()
	{
		while(anchoredPosition - diffPreFramePosition  < -itemScale) {
			if (((currentItemIndex + 1) + visibleItemCount) == listCount) {
				break;
			} 
			diffPreFramePosition -= itemScale;

			var item = ItemList.First.Value;
			ItemList.RemoveFirst ();
			ItemList.AddLast (item);

			var pos = itemScale * itemCount + itemScale * currentItemIndex;
			item.anchoredPosition = new Vector2(0, -pos);

			// onUpdateItem.Invoke(currentItemNo + 5, item.gameObject);
			onItemChanged.Invoke(currentItemIndex + visibleItemCount, item.gameObject);

			currentItemIndex++;
			Debug.LogWarning ("no : " + currentItemIndex);
		}
		while(anchoredPosition - diffPreFramePosition  > 0) {
			if ( (currentItemIndex - 1) < 0) {
				break;
			}
			diffPreFramePosition += itemScale;

			var item = ItemList.Last.Value;
			ItemList.RemoveLast ();
			ItemList.AddFirst (item);

			currentItemIndex--;

			var pos = itemScale * currentItemIndex;
			item.anchoredPosition = new Vector2(0, -pos);

			onItemChanged.Invoke (currentItemIndex, item.gameObject);
			// onUpdateItem.Invoke(currentItemNo + 5, item.gameObject);


			Debug.LogWarning ("no : " + currentItemIndex);
		}		
	}

	public void PushItem (GameObject Node) {
		if (Node == null) {
			Debug.LogError ("Node is null!!");
			return;
		}
	}
}
