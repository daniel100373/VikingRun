using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if( other.CompareTag("Player") )
        {
            //Debug.Log(1);
            UI.Instance.AddScore();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
