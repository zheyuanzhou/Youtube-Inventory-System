using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.instance.items.Count < GameManager.instance.slots.Length)//STEP 03 ONLY THIS LINE IS STEP 03
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameManager.instance.AddItem(itemData);//STEP 02
            }
            else//STEP 03
            {
                Debug.Log("You CANNOT PICK UP. YOUR BAG IS FULLLLLLL");
            }

        }
    }

}
