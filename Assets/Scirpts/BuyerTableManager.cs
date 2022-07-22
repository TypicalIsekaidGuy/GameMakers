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
            if (gameManager.order.Count == 0)
            {
                gameManager.GiveOrder();
            }
        }
    }
}
