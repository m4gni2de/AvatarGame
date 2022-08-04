using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard : MonoBehaviour
{
    public GameObject gameGrid;
    public GameObject tilePoint;
    public List<GameObject> tilePoints = new List<GameObject>();

    public int rows = 17;
    public int cols = 17;

    
    [Header("Player Top")]
    public GameObject playerTop;
    public GameObject pTopHand;

    [Header("Player Bottom")]
    public GameObject playerBottom;
    public GameObject pBottomHand;

    [Header("Menus")]
    public TileSelectMenu TileSelectMenu;

    int xMin = -8;
    int xMax = 8;
    int yMin = -8;
    int yMax = 8;

    public void BoardSet()
    {
        int xCount = xMin;
        int yCount = yMax;
        for (int i = 0; i < (rows * cols); i++)
        {
            GameObject x = Instantiate(tilePoint, gameGrid.transform);
            tilePoints.Add(x);
            x.GetComponent<BoardSpace>().SetSpace(i, xCount, yCount);
            xCount += 1;
            if (xCount > xMax)
            {
                xCount = xMin;
                yCount -= 1;
            }

            x.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void SummonTilesToHand(int owner, PlayerLocation location, List<TileObject> chosenTiles)
    {
        GameObject tileHand = pTopHand;
        if (location == PlayerLocation.Bottom)
        {
            tileHand = pBottomHand;
        }

        for (int i = 0; i < chosenTiles.Count; i++)
        {
            GameObject x = Instantiate(chosenTiles[i].gameObject, tileHand.transform);
            x.tag = "GameTile";
            x.GetComponent<TileObject>().ToggleSelected(false);
            x.GetComponent<TileObject>().tile.SetOwner(owner);
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
