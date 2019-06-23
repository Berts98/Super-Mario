using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string EnemyName = "Enemy To Rename";
    public int Life = 10;
    public float MoveSpeed = 1.4f;
    private bool IsAlive = false;

    /// <summary>
    /// Funzione che arreca danno alla vita del nemico.
    /// </summary>
    /// <param name="amount">Ammontare del danno inflitto.</param>
    public void Damage(int amount) {
        Life -= amount;
        if (Life <= 0) {
            KillMe();
        }
    }

    /// <summary>
    /// Comportamento di morte.
    /// </summary>
    private void KillMe() {
        foreach (Collider collider in GetComponentsInChildren<Collider>()) {
            collider.enabled = false;
        }
    }
}
