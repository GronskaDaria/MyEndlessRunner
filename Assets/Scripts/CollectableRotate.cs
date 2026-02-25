using System;
using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    int rotateSpeed = 1;
    [SerializeField] AudioSource coinFX;
      void Update()
      {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
      }
    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        Master.coinCount++;
        this.gameObject.SetActive(false);
    }
}
