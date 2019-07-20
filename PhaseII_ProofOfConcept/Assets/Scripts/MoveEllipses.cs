using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEllipses : MonoBehaviour
{
    public Transform transformTopEllipse;
    public Transform transformBottomEllipse;
    public float speedMove = 1f;
    private Vector3 startPosition;
    




    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {




        if (Vector3.Distance(transformTopEllipse.position, startPosition) < 2f)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transformTopEllipse.Translate(Vector3.up * Time.deltaTime * speedMove);
                transformBottomEllipse.Translate(Vector3.down * Time.deltaTime * speedMove);

            }
        }



        if (Vector3.Distance(transformTopEllipse.position, startPosition) > 0.01f)
        {

            if (Input.GetKey(KeyCode.Q))
            {

                transformTopEllipse.Translate(Vector3.down * Time.deltaTime * speedMove);
                transformBottomEllipse.Translate(Vector3.up * Time.deltaTime * speedMove);

            }
        }


    }
}
