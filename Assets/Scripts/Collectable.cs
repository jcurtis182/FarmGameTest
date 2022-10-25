using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);
            Destroy(gameObject);
        }
        
    }   
    
}

public enum CollectableType
{
    NONE, POTATO_SEED
}
