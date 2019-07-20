using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEllipses : MonoBehaviour
{
    public Transform transformTopEllipse;
    public Transform transformBottomEllipse;
    public float speedMove = 1f;
    float RangeY=0;
    




    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transformTopEllipse.position.y<=2f)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transformTopEllipse.Translate(Vector3.up * Time.deltaTime * speedMove);
                transformBottomEllipse.Translate(Vector3.down * Time.deltaTime * speedMove);

            }
        }
        
        if (transformTopEllipse.position.y>=0.01f)
        {

            if (Input.GetKey(KeyCode.Q))
            {

                transformTopEllipse.Translate(Vector3.down * Time.deltaTime * speedMove);
                transformBottomEllipse.Translate(Vector3.up * Time.deltaTime * speedMove);

            }
        }


    }
}
