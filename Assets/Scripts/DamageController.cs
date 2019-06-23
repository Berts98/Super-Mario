using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public float BouncingForce = 200;

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Collisione: " + other.name);
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            // allora è un nemico
            enemy.Damage(1);
            Rigidbody rb = GetComponentInParent<Rigidbody>();
            if (rb != null) {
                // faccio il rimbalzo post danneggiamento
                rb.AddForce(new Vector3(0, BouncingForce, 0));
            }
        }
    }

}
