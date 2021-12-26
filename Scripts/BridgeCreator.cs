using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCreator : MonoBehaviour
{
    [SerializeField] GameObject NormalBridge;
    [SerializeField] GameObject LeftBridge;

    int Direction = 0;
    int rnd = 0;

    public GameObject nextBridge;
    public GameObject newBridge;
    public GameObject nowBridge;
    public GameObject old1Bridge;
    public GameObject old2Bridge;
    public GameObject clearBridge;
    bool begin = true;
    // Start is called before the first frame update
    void Start()
    {
        
        for( int i = 0; i < 2; i++ )
        {
            Create();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        if( rnd == 1 ) 
        {
            rnd = 0;
        }
        else
        {
            rnd = Random.Range(0, 2);
        }

        clearBridge = old2Bridge;
        old2Bridge = old1Bridge;
        old1Bridge = nowBridge;
        nowBridge = newBridge;
        //nextBridge=n
        if( begin )
        {

            nextBridge = Instantiate(NormalBridge, this.transform.position, Quaternion.identity);
            //newBridge = Instantiate(NormalBridge, newBridge.transform.GetChild(1).transform.position, Quaternion.Euler(0, 90 * Direction, 0));
           
            //newBridge = Instantiate(LeftBridge, newBridge.transform.GetChild(2).transform.position, Quaternion.identity);
            //newBridge = Instantiate(NormalBridge, newBridge.transform.GetChild(1).transform.position, rotation);
            //Direction++;
            begin = false;
        }

        else
        {
            //newBridge = Instantiate(NormalBridge, newBridge.transform.GetChild(1).transform.position, Quaternion.identity);
            
            if( rnd == 0 )
            {
                nextBridge = Instantiate(NormalBridge, newBridge.transform.GetChild(1).transform.position, Quaternion.Euler(0, 90 * Direction, 0));
               // newBridge = Instantiate(NormalBridge, newBridge.transform.GetChild(1).transform.position, Quaternion.Euler(0, 90 * Direction, 0));
               
            }
            else if( rnd == 1 )
            {


                nextBridge = Instantiate(LeftBridge, newBridge.transform.GetChild(2).transform.position , Quaternion.Euler(0, 90 * Direction, 0));
                Direction++;
                //newBridge = Instantiate(NormalBridge, newBridge.transform.GetChild(1).transform.position, Quaternion.Euler(0, 90 * Direction, 0));
            }
            

        }
        newBridge = nextBridge;
    }
       
    
}
