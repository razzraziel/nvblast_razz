using UnityEngine;

public class GameObjectBlaster : MonoBehaviour
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
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(1, 2, 1), NvBlastChunkDesc.Flags.NoFlags));
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(2, 3, 2), NvBlastChunkDesc.Flags.NoFlags));
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(1, 1, 1), NvBlastChunkDesc.Flags.SupportFlag));
        settings.extents = new Vector3(10, 50, 10);
        settings.staticHeight = 10.0f;
        _thisCubeAsset = CubeAsset.generate(settings);
        _objectToBlastFamily.Initialize(_thisCubeAsset);
        _objectToBlastFamily.transform.localPosition = this.transform.localPosition;

    }

}
