using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform cam;

    public bool isOrderReady = false;
    public List<int> order = new List<int>();
    public int readyOrderIndex = 0;
    private int min1 = 3;
    private int max1 = 5;
    private int min2 = 3;
    private int max2 = 5;
    private int min3 = 3;
    private int max3 = 5;
    private int min4 = 3;
    private int max4 = 5;
    public float order_speed = 2;

    void Start()
    {
        GiveOrder();
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
            switch (readyOrderIndex)
            {
                case 0:
                    order.Add(rand.Next(min1,max1+1));
                    break;
                case 1:
                    order.Add(rand.Next(min1,max1+1));
                    order.Add(rand.Next(min2,max2+1));
                    break;
                case 2:
                    order.Add(rand.Next(min1,max1+1));
                    order.Add(rand.Next(min2,max2+1));
                    order.Add(rand.Next(min3,max3+1));
                    break;
                case 3:
                    order.Add(rand.Next(min1,max1+1));
                    order.Add(rand.Next(min2,max2+1));
                    order.Add(rand.Next(min3,max3+1));
                    order.Add(rand.Next(min4,max4+1));
                    break;
            }
        }
    }
}
