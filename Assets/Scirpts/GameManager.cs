using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform cam;

    [HideInInspector]public bool isOrderReady = false;
    public List<int[]> order = new List<int[]>();
    public List<GameObject> orders = new List<GameObject>();
    public int readyOrderIndex;
    private int min, max;  
    [HideInInspector]public int order_speed = 100;

    void Start()
    {
        readyOrderIndex = 4;
        GiveOrder();
        GetSettings();
    }
    void Update()
    {
        cam.position = new Vector3(player.transform.position.x, 1.53f, player.transform.position.z - 2.158f);
    }
    public void GiveOrder()
    {
        if (!isOrderReady)
        {
            isOrderReady = true;
            System.Random rand = new System.Random();
            for (int i = -1; i < readyOrderIndex; i++)
                order.Add(new int[] { i + 1, rand.Next(min, max + 1) });
        }
    }
    public bool OrderCheck()
    {
        return order.Count == 0;
    }
    private void GetSettings()
    {
        min = 3;
        max = 5;
    }
}
