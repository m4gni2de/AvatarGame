using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GamePlayer
{
    public string pName;
    public int pIndex;
    public Tile CharacterTile = null;
    public List<Tile> AccentTiles = new List<Tile>();
    public PlayerLocation pLocation;

    public GamePlayer(int index, string name)
    {
        pName = name;
        pIndex = index;
        pLocation = (PlayerLocation)index;
    }
    public void SetPlayer(int index, string name)
    {
        
    }

    public void SetCharacter(TileObject tile)
    {
        CharacterTile = tile.tile;
    }
    public void SetSelectedAccentTiles(List<TileObject> list)
    {
        AccentTiles.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            AccentTiles.Add(list[i].tile);
        }
    }
}
