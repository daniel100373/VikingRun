using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBridge : MonoBehaviour
{
    BridgeCreator bridgeCreator;
    // Start is called before the first frame update
    void Start()
    {
        bridgeCreator = FindObjectOfType<BridgeCreator>();
    }

    private void OnTriggerExit(Collider other)
    {
        bridgeCreator.Create();
        Destroy(bridgeCreator.old2Bridge);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
