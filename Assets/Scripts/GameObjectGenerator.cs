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
        //First depth for first state, so it will be unfractred (1,1,1)
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(1, 1, 1), NvBlastChunkDesc.Flags.NoFlags));
        //Second depth for first fracture, so it will fractured by 2 per axis. You can add more depths or increase this depths count.
        settings.depths.Add(new CubeAsset.DepthInfo(new Vector3(2, 2, 2), NvBlastChunkDesc.Flags.SupportFlag));
        //this is size
        settings.extents = new Vector3(10, 10, 10);
        //this is static parts of object, so 1.0 means first row will be static.
        settings.staticHeight = 1.0f;
        _thisCubeAsset = CubeAsset.generate(settings);
        _objectToBlastFamily.Initialize(_thisCubeAsset);
        _objectToBlastFamily.transform.localPosition = this.transform.localPosition;
    }
}
