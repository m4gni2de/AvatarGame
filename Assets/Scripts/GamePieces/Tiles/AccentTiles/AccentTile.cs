using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AccentTile : Tile
{
   
}

[System.Serializable]
public class BoilTile : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetAccentTile(1, 0);
    }
}

[System.Serializable]
public class BridgeTile : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetAccentTile(2, 0);
    }
}

[System.Serializable]
public class LotusTile : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetAccentTile(1, 0);
    }
}

[System.Serializable]
public class BearTile : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetAccentTile(2, 2);
    }
}

[System.Serializable]
public class RockTile : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetAccentTile(2, 0);
    }
}

[System.Serializable]
public class WheelTile : Tile
{
    public override void LoadTile(string name)
    {
        base.LoadTile(name);
        SetAccentTile(1, 0);
    }
}
