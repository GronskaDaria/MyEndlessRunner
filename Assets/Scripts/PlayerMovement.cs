using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float horizontalSpeed = 3f;


    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed*Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(Vector3.left*horizontalSpeed*Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(Vector3.right*horizontalSpeed*Time.deltaTime, Space.World);
        }
    }
}
 