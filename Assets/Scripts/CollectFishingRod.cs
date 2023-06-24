using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFishingRod : MonoBehaviour
{// creating a "GameObject" and making that object playerfishingrod. Then checking that GameObject entering collider is the player, through player tag.

 // if so we want to destroy fishingrod on dock, and activate (make visible) fishingrod in player hands. 
 // the player was always holding the rod, we just turned it on.

    [SerializeField] GameObject playerFishingrod;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerFishingrod.SetActive(true);
            Destroy(gameObject);
        }
    }
}
