using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Tile
{
    public string tileName;
    public int tileOwner;
    public int maxHp, currentHp;
    public Element tileElement;
    public TileType tileType;
    public int movementMax;
    public Sprite tileSprite;

    public virtual void LoadTile(string name)
    {
        tileName = name;
    }

    public void SetOwner(int index)
    {
        tileOwner = index;
    }

    public async void SetAccentTile(int hp, int moveMax)
    {
        tileType = TileType.Accent;
        tileElement = Element.none;
        maxHp = hp;
        currentHp = hp;
        movementMax = moveMax;

        string key = tileName + (tileOwner + 1);
        tileSprite = await TileData.GetTileSprite(key);
    }

    public async void SetCharacterTile(int element, int hp, int moveMax)
    {
        tileType = TileType.Character;
        tileElement = (Element)element;
        maxHp = hp;
        currentHp = hp;
        movementMax = moveMax;
        string key = tileName + (tileOwner + 1);
        tileSprite = await TileData.GetTileSprite(key);
    }
    
}
