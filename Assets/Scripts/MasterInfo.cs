using TMPro;
using UnityEngine;

public class Master : MonoBehaviour
{
    public static int coinCount = 0;
    public static int distanceCount = 0;
    private int startZ=-80;
    [SerializeField] GameObject coinDisplay;
    [SerializeField] GameObject distanceDisplay;
    private GameObject player;
    private void Start()
    {
        player=GameObject.Find("Player");
    }

    void Update()
    {
        distanceCount=Mathf.RoundToInt(player.transform.position.z-startZ);
        coinDisplay.GetComponent<TMP_Text>().text = "COINS: " + coinCount;
        distanceDisplay.GetComponent<TMP_Text>().text =distanceCount.ToString()+ " km";
    }
}
