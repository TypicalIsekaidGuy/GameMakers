using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerTableManager : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (gameManager.OrderCheck())
            {
                foreach (GameObject u in gameManager.orders)
                {
                    Destroy(u);
                }
                gameManager.orders.Clear();//обернуть в метод
                gameManager.order.Clear();
                gameManager.isOrderReady = false;
                gameManager.GiveOrder();
            }
        }
    }
}
