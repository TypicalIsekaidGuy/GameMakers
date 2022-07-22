using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public GameManager gameManager;
    private List<int> order;
    [SerializeField]private int index;

    private WaitForSecondsRealtime wait;

    public GameObject order_prefab;
    private GameObject order_object;

    private void Start()
    {
        order = gameManager.order;
        wait = new WaitForSecondsRealtime(gameManager.order_speed/10);
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(index < order.Count)
            {
                StartCoroutine("GiveOrder");
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(index < order.Count)
            {
                StopCoroutine("GiveOrder");
            }
        }
    }
    private IEnumerator GiveOrder()
    {
        while (order[index] != 0)
        {
            order_object = Instantiate(order_prefab, transform.position, new Quaternion(0, 0, 0, 0));
            int sas = 0;
            while (sas!=100)
            {
                order_object.transform.position += new Vector3(1, 1, 1) / 100;
                sas++;
                yield return wait;
            }
            Destroy(order_object);
            order[index]--;
        }
        order.RemoveAt(index);
    }
}
