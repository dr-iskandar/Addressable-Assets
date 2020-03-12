using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadAssetByLabel : MonoBehaviour
{
    public string _label;
    public string _assetName;

    private List<GameObject> Assets { get; } = new List<GameObject>();

    public void LoadAsset()
    {
        CreateAndWaitUntilCompleted();
    }

    private async Task CreateAndWaitUntilCompleted()
    {
        await CreateAddressablesLoader.InitAsset(_label, Assets);

        foreach (var asset in Assets)
        {
            //OBJS LOADED PERFORM ADDITIONAL ACTIONS
            Debug.Log(asset.name);
            return;
        }
    }
}


public static class CreateAddressablesLoader
{
    public static async Task InitAsset<T>(string assetNameOrLabel, List<T> createObjs)
        where T : Object
    {
        var locations = await Addressables.LoadResourceLocationsAsync(assetNameOrLabel).Task;
        foreach (var location in locations)
        {
            createObjs.Add(await Addressables.InstantiateAsync(location).Task as T);
            return;
        }
        
    }
    
}
