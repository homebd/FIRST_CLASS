using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] Prefabs;

    private List<GameObject>[] _pools;

    private void Awake() {
        _pools = new List<GameObject>[Prefabs.Length];

        for (int i = 0; i < _pools.Length; i++) {
            _pools[i] = new List<GameObject>();
        }
    }

    public GameObject GetItemWithIndex(int index) {
        GameObject select = null;

        foreach (var item in _pools[index]) {
            if(!item.activeSelf) {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select) {
            select = Instantiate(Prefabs[index], transform);
            _pools[index].Add(select);
        }

        return select;
    }
}
