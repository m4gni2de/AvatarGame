using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpaceType
{
    None,
    Nation,
    Garden,
    Balance
}
public class BoardSpace : MonoBehaviour
{
    public int tileIndex;
    public SpaceType spaceType;
    public Vector2 coords;
    public Image sp;

    public Tile tileOn = null;

   public void SetSpace(int index, int x, int y)
    {
        tileIndex = index;
        coords = new Vector2(x, y);
        name = "(" + coords.x + "," + coords.y + ")";
        spaceType = SpaceInfo.GetSpaceType(this);
        sp.color = SpaceInfo.GetSpaceColor(this);
    }
}
