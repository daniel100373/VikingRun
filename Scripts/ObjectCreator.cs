using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    GameObject newCoin;
    GameObject newObstacle;
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        if( Random.Range(0, 3) == 2 )
        {
            newObstacle = Instantiate(Obstacle, transform.GetChild(13).transform.position, Quaternion.identity);
        }
        for( int i = 0; i < 5; i++ )
        {
            
            newCoin = Instantiate(Coin, transform.GetChild(Random.Range(4, 10)).transform.position, Quaternion.identity);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
