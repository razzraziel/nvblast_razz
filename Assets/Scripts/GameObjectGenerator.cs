using UnityEngine;

public class GameObjectGenerator : MonoBehaviour
{
    private CubeFamily _objectToBlastFamily;
    private CubeAsset _thisCubeAsset;

    void Start()
    {
        if (!(_objectToBlastFamily = this.GetComponent<CubeFamily>()))
        {
            Debug.Log(this.gameObject.name +  " has no CubeFamily.");
            return;
        }

        Init();
    }
    
    private void Init()
    {
        CubeAsset.Settings settings = new CubeAsset.Settings();
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(1, 1, 1), NvBlastChunkDesc.Flags.NoFlags));
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(2, 2, 2), NvBlastChunkDesc.Flags.SupportFlag));
        settings.extents = new Vector3(10, 10, 10);
        settings.staticHeight = 1.0f;
        _thisCubeAsset = CubeAsset.generate(settings);
        _objectToBlastFamily.Initialize(_thisCubeAsset);
        _objectToBlastFamily.transform.localPosition = this.transform.localPosition;
    }
}
