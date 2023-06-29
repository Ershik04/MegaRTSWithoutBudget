using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _templates;
    [SerializeField]
    private int[] _generationChanses;
    [SerializeField]
    private float _tileSize;

    private void Start()
    {
        int i = Random.Range(0, 100);
        int templateNumber = Random.Range(0, _templates.Length);
        if (i <= _generationChanses[templateNumber])
        {
            float xposition = Random.Range(-_tileSize, _tileSize);
            float zposition = Random.Range(-_tileSize, _tileSize);
            Vector3 position = new Vector3(xposition += gameObject.transform.position.x, 0, zposition += gameObject.transform.position.z);
            Instantiate(_templates[Random.Range(0, _templates.Length)], position, gameObject.transform.rotation);
        }
    }
}
