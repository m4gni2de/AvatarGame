using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SetUpPhase
{
    BoardSetUp,
    PlayerSetUp,
    CharacterSelect,
    AccentSelect,
}
public enum GamePhase
{
    DrawPhase,
}
public class TurnManager : MonoBehaviour
{
    public SetUpPhase setUpPhase = SetUpPhase.BoardSetUp;
    public GamePhase currentPhase = GamePhase.DrawPhase;
    public int currentTurn = 0;
    int maxPhases = 3;
    int maxSetUp = 3;


    public void StartTurn()
    {
        currentPhase = 0;
    }
    public void NextPhase()
    {
        int index = (int)currentPhase;
        if (index + 1 > maxPhases)
        {
            currentTurn += 1;
            StartTurn();
        }
    }
    public void StartSetUp()
    {
        DoSetUpPhase();
        
    }
    private void DoSetUpPhase()
    {
        switch (setUpPhase)
        {
            case SetUpPhase.BoardSetUp:
                GameEvents.Instance.GameBoard.BoardSet();
                NextSetUp();
                break;
            case SetUpPhase.PlayerSetUp:
                GameEvents.Instance.SetPlayers();
                break;
            case SetUpPhase.CharacterSelect:
                GameEvents.Instance.CharacterSelect();
                //NextSetUp();
                break;
            case SetUpPhase.AccentSelect:
                GameEvents.Instance.AccentSelect();
                //NextSetUp();
                break;
            default:
                break;
        }
    }
    public void NextSetUp()
    {
        int index = (int)setUpPhase;

        if (index == 0 || index == 1)
        {
            setUpPhase = (SetUpPhase)index + 1;
            DoSetUpPhase();
        }
        else if (index == 2)
        {
            if (GameEvents.Instance.CurrentPlayer.pIndex >= GameEvents.Instance.Players.Count - 1)
            {
                setUpPhase = (SetUpPhase)index + 1;
                GameEvents.Instance.SetCurrentPlayer(GameEvents.Instance.Players[0]);
            }
            else
            {
                GameEvents.Instance.SetCurrentPlayer(GameEvents.Instance.Players[GameEvents.Instance.CurrentPlayer.pIndex + 1]);
            }

            DoSetUpPhase();
        }
        else
        {
            if (GameEvents.Instance.CurrentPlayer.pIndex >= GameEvents.Instance.Players.Count - 1)
            {
                StartGame();
            }
            else
            {
                GameEvents.Instance.SetCurrentPlayer(GameEvents.Instance.Players[GameEvents.Instance.CurrentPlayer.pIndex + 1]);
                DoSetUpPhase();
            }
        }
        
    }

    public void StartGame()
    {
        GameEvents.Instance.StartGame();
    }
}
