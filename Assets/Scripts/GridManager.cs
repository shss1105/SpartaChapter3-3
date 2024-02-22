using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    // 그리드 너비, 높이
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private Tile _grassTile, _mountainTile;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;
    private void Start()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        GenerateGrid();
    }
    void GenerateGrid() // 그리드 생성
    {
        for(int x = 0; x < _width; x++)
        {
            for(int y = 0; y < _height; y++)
            {
                Tile randomTile = Random.Range(0,6) == 3 ? _mountainTile : _grassTile;
                Tile spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile{x}{y}";

                spawnedTile.Init(x,y);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_height/2 - 0.5f, - 10);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos, out Tile tile)) return tile;
        return null;
    }
}
