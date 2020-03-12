using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadAddressableAsset : MonoBehaviour
{
    [SerializeField] private AssetReference _explosion;
    public Transform parent;

    void Start()
    {
        StartCoroutine(ienum());
    }

    IEnumerator ienum()
    {
        var go = _explosion.InstantiateAsync();
        yield return go;

        if (go.Result != null)
        {
            go.Result.transform.SetParent(parent);
            go.Result.transform.localPosition = new Vector3(0, 0, 0);
        }

    }
}