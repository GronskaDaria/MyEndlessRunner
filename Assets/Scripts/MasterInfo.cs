using TMPro;
using UnityEngine;

public class Master : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    void Update()
    {
        coinDisplay.GetComponent<TMP_Text>().text = "COINS: " + coinCount;
    }
}
