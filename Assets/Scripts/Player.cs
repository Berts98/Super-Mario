using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public  int Life;
    public float MovementSpeed;
    public int Coins;
    public float JumpForce;
    public bool isGrounded;
    public Rigidbody2D rb;
    public Animator anim;

    bool isAlive = true;

    // Update is called once per frame
    void Update()
    {
        if (Life > 0) {
            CheckInput();
        }
    }

    /// <summary>
    /// Controllo input movimento player
    /// </summary>
    public void CheckInput()
    {
        if (isAlive == false) {
            return;
        }

        // Movimento laterale
        if (Input.GetKey(KeyCode.A) == true) { // SX
            transform.position = transform.position + new Vector3(-MovementSpeed, 0f, 0f);                                   
            anim.SetInteger("movement/idle", -1);
        } else if (Input.GetKey(KeyCode.D)) { // DX
            transform.position = transform.position + new Vector3(+MovementSpeed, 0f, 0f);
            anim.SetInteger("movement/idle", 1);
        } else {
            anim.SetInteger("movement/idle", 0);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.W) == true && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, JumpForce));
            // transform.position = transform.position + new Vector3(0f, JumpForce * Time.deltaTime, 0f);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Accoviacciamento");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
       
        isGrounded = true;
      
    }

    public void Damage(int amount) {
        Life -= amount;
        if (Life <= 0)
            killMe();
    }

    public void Coin(int amount)
    {
        Coins += amount;
        
    }

    public void killMe() {
        foreach (Collider2D collider in GetComponentsInChildren<Collider2D>()) {
            collider.enabled = false;
        }
        isAlive = false;
        anim.SetTrigger("Death");
        //Debug.Log("killMe");
    }
}
