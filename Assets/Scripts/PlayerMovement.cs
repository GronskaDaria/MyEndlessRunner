using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed*Time.deltaTime, Space.World);
    }
}
 