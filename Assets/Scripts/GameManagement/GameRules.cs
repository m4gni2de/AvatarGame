using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameRules
{
    public static List<string> AccentTileChoices = new List<string>();
    public static List<string> CharacterTileChoices = new List<string>();

    public static List<string> GetStartingAccentTiles(GameType gt)
    {
        AccentTileChoices.Clear();
        if (gt == GameType.Standard)
        {
            AccentTileChoices.Add("Boil");
            AccentTileChoices.Add("Boil");
            AccentTileChoices.Add("Bridge");
            AccentTileChoices.Add("Bridge");
            AccentTileChoices.Add("Lotus");
            AccentTileChoices.Add("Bear");
            AccentTileChoices.Add("Rock");
            AccentTileChoices.Add("Rock");
            AccentTileChoices.Add("Wheel");
            AccentTileChoices.Add("Weel");
        }

        return AccentTileChoices;
    }

    public static List<string> GetCharacterTiles(GameType gt)
    {
        CharacterTileChoices.Clear();
        if (gt == GameType.Standard)
        {
            CharacterTileChoices.Add("Iroh");
            CharacterTileChoices.Add("Zuko");
            CharacterTileChoices.Add("Katara");
            CharacterTileChoices.Add("Pakku");
            CharacterTileChoices.Add("Toph");
            CharacterTileChoices.Add("Bumi");
            CharacterTileChoices.Add("Aang");
            CharacterTileChoices.Add("Gyasto");
        }

        return CharacterTileChoices;
    }
}
