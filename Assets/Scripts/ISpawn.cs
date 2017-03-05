using UnityEngine;
using System.Collections;

public interface ISpawn {

    /// <summary>
    /// 発生イベント
    /// </summary>
    void OnSpawn();

    /// <summary>
    /// 消滅イベント
    /// </summary>
    void OnDispawn();
}
