using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public GameManager gameManager;
    private List<int[]> order;
    [SerializeField]private int index;

    private WaitForSeconds wait;

    public GameObject order_prefab;
    private GameObject order_object;
    private static float objectCount = 0;
    private int[] garbage;

    private void Start()
    {
        garbage = new int[] { index, 0 };
        order = gameManager.order;
        wait = new WaitForSeconds(0.01f);
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(index < order.Count)
            {
                StartCoroutine(GiveOrder());
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(index < order.Count)
            {
                StopCoroutine(GiveOrder());
                if(!gameManager.orders.Contains(order_object))
                    Destroy(order_object);
            }
        }
    }
    private IEnumerator GiveOrder()
    {
        while (order.Contains(garbage))//переписать
        {
            order_object = Instantiate(order_prefab, transform.position, new Quaternion(0, 0, 0, 0));
            while (Vector3.Distance(gameManager.player.transform.position, order_object.transform.position) >0.1f)
            {
                order_object.transform.position += (gameManager.player.transform.position - transform.position)/ gameManager.order_speed;
                yield return wait;
            }
            order_object.transform.parent = gameManager.player;
            order_object.transform.position = gameManager.player.transform.position + new Vector3(gameManager.player.transform.forward.x / 3, objectCount, gameManager.player.transform.forward.z/3);
            objectCount+=0.1f;
            gameManager.orders.Add(order_object);
            foreach (var item in order)
            {
                if (item[0] == index) { 
                    item[1]--;
                    if (item[1] == -1)
                    {
                        order.Remove(item);
                        Debug.Log("Sas");
                    }
                }
            }
        }
        if (gameManager.OrderCheck())
            objectCount = 0;
    }
}
