using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterTile : Tile
{

}

[System.Serializable]
public class Iroh : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(4, 3, 3);
    }
}

[System.Serializable]
public class Zuko : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(4, 2, 3);
    }
}

[System.Serializable]
public class Katara : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(2, 2, 3);
    }
}

[System.Serializable]
public class Pakku : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(2, 2, 2);
    }
}

[System.Serializable]
public class Toph : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(3, 2, 3);
    }
}


[System.Serializable]
public class Bumi : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(3, 2, 2);
    }
}

[System.Serializable]
public class Aang : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(1, 2, 4);
    }
}

[System.Serializable]
public class Gyatso : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetCharacterTile(1, 2, 3);
    }
}
