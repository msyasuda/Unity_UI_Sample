using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[SerializeField]
public class SpawnData
{
    GameObject pawnObject;
    Vector3 position;

    public GameObject PawnObject
    {
        get
        {
            return this.pawnObject;
        }
        set
        {
            this.pawnObject = value;
        }
    }

    public Vector3 Position
    {
        get
        {
            return this.position;
        }set
        {
            this.position = value;
        }
    }
}

public class SpawnPoint : MonoBehaviour
{
    /// <summary>
    /// ボーンオブジェクト
    /// </summary>
    [SerializeField]
    private List<SpawnData> pawnObject = new List<SpawnData>();

    /// <summary>
    /// ポーンオブジェクトプロパティ
    /// </summary>
    public List<SpawnData> PawnObject
    {
        get
        {
            return pawnObject;
        }
        set
        {
            this.pawnObject = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        this.CreatePawnObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreatePawnObject()
    {
        for (int i = 0; i < this.PawnObject.Count; ++i) {
            if (this.PawnObject[i] == null)
                return;

            Vector2 initPosition = Vector2.zero;
            GameObject.Instantiate(this.PawnObject[i].PawnObject, 
                this.PawnObject[i].Position, Quaternion.identity);
        }

        this.PawnObject.Clear();
    }
}
