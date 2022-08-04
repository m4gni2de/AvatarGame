using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInfo 
{
   public static SpaceType GetSpaceType(BoardSpace space)
    {
        float x = Mathf.Abs(space.coords.x);
        float y = Mathf.Abs(space.coords.y);
       

        if (x >= 7 || y >= 7)
        {
            if (x == 7 || y == 7)
            {
                if (x == 0 || y == 0)
                {
                    return SpaceType.Garden;
                }
            }
            else
            {
                if (x == 0 || y == 0 || x == 1 || y == 1)
                {
                    return SpaceType.Garden;
                }
            }
        }
       
        if (x == 4 && y == 8)
        {
            return SpaceType.None;
        }
        if (y == 4 && x == 8)
        {
            return SpaceType.None;
        }
        if (x + y > 7)
        {
            if (x + y < 13)
            {
                return SpaceType.Nation;
            }
            return SpaceType.None;
        }

        

        return SpaceType.Balance;
    }

    public static Color GetSpaceColor(BoardSpace space)
    {
       
        SpaceType st = space.spaceType;

        if (st == SpaceType.None)
        {
            return Color.clear;
        }
        if (st == SpaceType.Garden)
        {
            return new Color(0f, 1f, .1f, 1f);
        }
        if (st == SpaceType.Nation)
        {
            return new Color(0f, .38f, 1f, 1f);
        }

        return new Color(1f, .5f, 0f, 1f);
    }
}
