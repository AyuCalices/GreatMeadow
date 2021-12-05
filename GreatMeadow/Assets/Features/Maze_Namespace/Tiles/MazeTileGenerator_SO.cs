using System.Collections.Generic;
using UnityEngine;
using Utils.Variables_Namespace;

namespace Features.Maze_Namespace.Tiles
{
    [CreateAssetMenu]
    public class MazeTileGenerator_SO : TileGenerator_SO
    {
        public TileBehaviour InstantiateTileAt(Tile tile, Transform tileParent)
        {
            TileSprite_SO tileSprite = GetTileSpriteByDirections(tile.directions);

            TileBehaviour runtimeTile = Instantiate(tileSprite.tile, tileParent);
            runtimeTile.Initialize(tile);
            runtimeTile.transform.localPosition = (Vector2)tile.position;

            return runtimeTile;
        }
    }
}
