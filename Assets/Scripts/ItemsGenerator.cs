using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _template;
    [SerializeField]
    private int _generationChanse;
    [SerializeField]
    private float _tileSize;

    private void Start()
    {
        int i = Random.Range(0, 100);
        if (i <= _generationChanse)
        {
            float xposition = Random.Range(-_tileSize, _tileSize);
            float zposition = Random.Range(-_tileSize, _tileSize);
            Vector3 position = new Vector3(xposition += gameObject.transform.position.x, 0, zposition += gameObject.transform.position.z);
            Instantiate(_template, position, gameObject.transform.rotation);
        }
    }
}
