using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _grass;
    [SerializeField]
    private GameObject[] _tiles;
    [SerializeField]
    private float[] _generationChanses;
    [SerializeField]
    private int _tilesCount;
    [SerializeField]
    private int _tilesLinesCount;
    [SerializeField]
    private int _currentPosition;
    [SerializeField]
    private int _linesSize;

    private void Start()
    {
        for (int i = 0; i < _tilesLinesCount; i++)
        {
            _linesSize += 10;
            for (int a = 0; a < _tilesCount; a++)
            {
                int tile = Random.Range(0, _tiles.Length);
                float tileGenerateChanse = Random.Range(0, 100);
                if (tileGenerateChanse > _generationChanses[tile])
                {
                    tile = 0;
                }
                Vector3 position = new Vector3(_currentPosition, 0, _linesSize);
                Instantiate(_tiles[tile], position, _tiles[tile].transform.rotation);
                _currentPosition += 10;
            }
            _currentPosition = 0;
        }
    }
}
