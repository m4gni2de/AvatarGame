using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; set; }

    public List<GamePlayer> Players = new List<GamePlayer>();
    public Gameboard GameBoard;
    public GameType gameType;
    public GameObject tileBaseTemplate;

    public GamePlayer CurrentPlayer = null;
    public TurnManager turnManager;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        gameType = GameType.Standard;
        turnManager.StartSetUp();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayers()
    {
        GamePlayer player1 = new GamePlayer(0, "Bottom Player");
        Players.Add(player1);
        GamePlayer player2 = new GamePlayer(1, "Top Player");
        Players.Add(player2);

        SetCurrentPlayer(player1);
        turnManager.NextSetUp();
    }
    public void SetCurrentPlayer(GamePlayer player)
    {
        CurrentPlayer = player;
    }
    public void StartGame()
    {

        GameBoard.TileSelectMenu.CloseMenu();
        SetCurrentPlayer(Players[0]);
    }

    public void CharacterSelect()
    {
        GameBoard.TileSelectMenu.LoadCharacterSelect(CurrentPlayer);
    }
    public void AccentSelect()
    {
        GameBoard.TileSelectMenu.LoadAccentSelect(CurrentPlayer);
    }
    public void SetPlayerTiles(int index, List<TileObject> chosenTiles, TileType ty)
    {
        if (ty == TileType.Accent)
        {
            Players[index].SetSelectedAccentTiles(chosenTiles);
        }
        if (ty == TileType.Character)
        {
            Players[index].SetCharacter(chosenTiles[0]);
        }
        
        PlayerLocation location = Players[index].pLocation;
        GameBoard.SummonTilesToHand(CurrentPlayer.pIndex, location, chosenTiles);

        turnManager.NextSetUp();
    }
}

    
