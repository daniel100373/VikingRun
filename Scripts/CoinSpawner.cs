using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    
    public Transform Coin;

   
    List<Transform> coinList;
    
    // Start is called before the first frame update
    void Start()
    {
        coinList = new List<Transform>();
        coinList.Add(Instantiate(Coin));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
