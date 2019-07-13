using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderDeath : MonoBehaviour
{
    private void OnCollisionEnter2D (Collision2D other)
    {
       Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // allora è un player
            player.killMe();
            other.collider.enabled = true;
            player.GameOverPanel.SetActive(true);
        }

    }
    
}
