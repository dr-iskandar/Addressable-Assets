using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    public LoadAssetByLabel loadAssetByLabel;

    public void loadAsset(string ObjectName)
    {
        loadAssetByLabel._assetName = ObjectName;
        loadAssetByLabel._label = ObjectName;

        loadAssetByLabel.LoadAsset();
    }
}
