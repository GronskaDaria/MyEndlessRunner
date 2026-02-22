using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float horizontalSpeed = 3f;
    public float rightLimit = 7.5f;
    public float leftLimit = -7.5f;



    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed*Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow)))
        {
            if (this.gameObject.transform.position.x>leftLimit)
            { 
                transform.Translate(Vector3.left*horizontalSpeed*Time.deltaTime, Space.World);
            }
            
        }
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            if (this.gameObject.transform.position.x<rightLimit)
            {
                transform.Translate(Vector3.right*horizontalSpeed*Time.deltaTime, Space.World);
            }
        }
    }
}
  