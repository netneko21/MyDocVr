using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEllipses : MonoBehaviour
{
    public Transform transformTopEllipse;
    public Transform transformBottomEllipse;
    public float speedMove = 1f;
    private float rangeY = 0;





    // Start is called before the first frame update
    void Start()
    {

        rangeY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.E))
        {
            rangeY +=Time.deltaTime * speedMove;
           
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            rangeY -=Time.deltaTime * speedMove;
            
        }

        rangeY = Mathf.Clamp(rangeY, 0f, 2f);
        transformTopEllipse.position = new Vector3 (0, rangeY, 0);
        transformBottomEllipse.position = new Vector3 (0, -rangeY, 0);
       


        

    }
}
