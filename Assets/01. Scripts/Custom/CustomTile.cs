using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "RandomTile", menuName = "CustomTile/Custom Random Tile")]
public class CustomRandomTile : TileBase
{
    public TileBase[] randomTiles;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if (randomTiles != null && randomTiles.Length > 0)
        {
            int index = Random.Range(0, randomTiles.Length);
            TileBase selectedTile = randomTiles[index];
            selectedTile.GetTileData(position, tilemap, ref tileData);
        }
    }
}