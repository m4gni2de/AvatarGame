using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TileData 
{
    public static Tile GetTile(string name)
    {
        switch (name)
        {
            case "Boil":
                return new BoilTile();
            case "Bridge":
                return new BridgeTile();
            case "Lotus":
                return new LotusTile();
            case "Bear":
                return new BearTile();
            case "Rock":
                return new RockTile();
            case "Wheel":
                return new BoilTile();
            case "Iroh":
                return new Iroh();
            case "Zuko":
                return new Zuko();
            case "Katara":
                return new Katara();
            case "Pakku":
                return new Pakku();
        }
        return null;
    }
    public static async Task<Sprite> GetTileSprite(string key)
    {
        AsyncOperationHandle<Sprite> sp = Addressables.LoadAssetAsync<Sprite>(key);
        await sp.Task;

        if (sp.Status == AsyncOperationStatus.Succeeded && sp.IsDone)
        {
            return sp.Result;
        }
        else
        {
            return null;
        }
    }
}
