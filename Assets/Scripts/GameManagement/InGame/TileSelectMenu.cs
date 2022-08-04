using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileSelectMenu : MonoBehaviour
{
    public GamePlayer ActivePlayer = null;
    public GameObject tileContent;
    public List<TileObject> availableTiles = new List<TileObject>();
    public List<TileObject> chosenTiles = new List<TileObject>();
    Vector2 mousePos2D;
    float touchTime;

    public int maxCount = 0;

    public Button confirmTileButton;
    public TileType selectingType;

    public int CurrentCount { get { return chosenTiles.Count; } }

    void ResetMenu()
    {
        for (int i = 0; i < availableTiles.Count; i++)
        {
            Destroy(availableTiles[i].gameObject);
        }
        availableTiles.Clear();
        chosenTiles.Clear();
        ActivePlayer = null;
        confirmTileButton.interactable = false;
    }
    public void LoadAccentSelect(GamePlayer player)
    {
        ResetMenu();
        selectingType = TileType.Accent;
        gameObject.SetActive(true);
        ActivePlayer = player;
        SetMaxCount(4);

        List<string> tiles = GameRules.GetStartingAccentTiles(GameEvents.Instance.gameType);

        for (int i = 0; i < tiles.Count; i++)
        {
            GameObject x = Instantiate(GameEvents.Instance.tileBaseTemplate, tileContent.transform);
            x.GetComponent<TileObject>().LoadTile(tiles[i]);
            x.tag = "PregameTile";
            availableTiles.Add(x.GetComponent<TileObject>());
        }
    }
    public void LoadCharacterSelect(GamePlayer player)
    {
        ResetMenu();
        selectingType = TileType.Character;
        gameObject.SetActive(true);
        ActivePlayer = player;
        SetMaxCount(1);

        List<string> tiles = GameRules.GetCharacterTiles(GameEvents.Instance.gameType);

        for (int i = 0; i < tiles.Count; i++)
        {
            GameObject x = Instantiate(GameEvents.Instance.tileBaseTemplate, tileContent.transform);
            x.GetComponent<TileObject>().LoadTile(tiles[i]);
            x.tag = "PregameTile";
            availableTiles.Add(x.GetComponent<TileObject>());
        }
    }
    public void SetMaxCount(int count)
    {
        maxCount = count;
    }
   

    private void Update()
    {
        TouchControls();
    }

    public void ConfirmTileChoices()
    {
        GameEvents.Instance.SetPlayerTiles(ActivePlayer.pIndex, chosenTiles, selectingType);
        
    }

    public void CloseMenu()
    {
        ResetMenu();
        gameObject.SetActive(false);
    }
    
    #region Touch Controls
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    void TouchControls()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);

        if (Input.GetMouseButtonDown(0))
        {
            //if (!IsPointerOverUIObject())
            //{
            //    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 0f);
            //    if (hit.collider != null)
            //    {
            //        touchTime = Time.time;
            //        if (hit.collider.gameObject.CompareTag("PregameTile"))
            //        {
            //            hit.collider.gameObject.GetComponent<TileObject>();
            //        }

            //    }


            //}
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                touchTime = Time.time;
                if (hit.collider.gameObject.CompareTag("PregameTile"))
                {

                    SelectTile(hit.collider.gameObject.GetComponent<TileObject>());
                }

            }

        }
    }

    private void SelectTile(TileObject tile)
    {
        if (!chosenTiles.Contains(tile) && CurrentCount < 4)
        {
            chosenTiles.Add(tile);
            tile.ToggleSelected(true);
        }
        else
        {
            chosenTiles.Remove(tile);
            tile.ToggleSelected(false);
        }

        confirmTileButton.interactable = CurrentCount > (maxCount - 1) && CurrentCount < (maxCount + 1);
    }

    #endregion
}
