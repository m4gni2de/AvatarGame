using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public Tile tile = null;
    public SpriteRenderer mainSprite;
    public bool isSelected = false;


    public void LoadTile(string name)
    {
        tile = TileData.GetTile(name);

        if (tile != null)
        {
            tile.LoadTile(name);
            StartCoroutine(SetSprite());
        }
    }

    private IEnumerator SetSprite()
    {
        do
        {
            yield return new WaitForEndOfFrame();
        } while (true && tile.tileSprite == null);

        mainSprite.sprite = tile.tileSprite;
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSelected(bool select)
    {
        isSelected = select;

        if (isSelected)
        {
            mainSprite.color = Color.green;
        }
        else
        {
            mainSprite.color = Color.white;
        }
    }
}
