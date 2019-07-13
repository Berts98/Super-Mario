using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int Life;
    public float MovementSpeed;
    public int Coins;
    public int MaxCoins = 10;
    public float JumpForce;
    public bool isGrounded;
    public Rigidbody2D rb;
    public Animator anim;
    bool isAlive = true;
    public Vector3 StartEdge;
    public Vector3 EndEdge;
    public GameObject Toad;
    public Text CoinValue;
    public float Timer = 0f;
    public float DeathTimer = 0f;
    public Camera Cam;
    public GameObject GameOverPanel;

    // Update is called once per frame
    void Update()
    {
        if (Life > 0)
        {
            CheckInput();
        }
        victory();
    }

    /// <summary>
    /// Controllo input movimento player
    /// </summary>
    public void CheckInput()
    {
        if (isAlive == false)
        {
            return;
        }

        // Movimento laterale
        if (Input.GetKey(KeyCode.A) == true && transform.position.x > StartEdge.x)
        { // SX
            transform.position = transform.position + new Vector3(-MovementSpeed, 0f, 0f);
            anim.SetInteger("movement/idle", -1);
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < EndEdge.x)
        { // DX
            transform.position = transform.position + new Vector3(+MovementSpeed, 0f, 0f);
            anim.SetInteger("movement/idle", 1);
        }
        else
        {
            anim.SetInteger("movement/idle", 0);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.W) == true && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, JumpForce));
            // transform.position = transform.position + new Vector3(0f, JumpForce * Time.deltaTime, 0f);
            isGrounded = false;
        }
        /*if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Accoviacciamento");
        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    public void Damage(int amount)
    {
        Life -= amount;
        if (Life <= 0)
        {
            Cam.transform.parent = null;
            killMe();
        }
        GameOverPanel.SetActive(true);
    }

    public void Coin(int amount)
    {
        Coins += amount;
        CoinValue.text = Coins.ToString();
    }

    public void killMe()
    {
        foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = false;
        }
        isAlive = false;
        anim.SetTrigger("Death");
        //Debug.Log("killMe");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndLevel" && isGrounded == true)
        {
            Toad.SetActive(true);
        }
        if (collision.tag == "EndLevel1")
        {
            SceneManager.LoadScene(3);
        }
    }

    public void victory()
    {
        if (Toad.activeInHierarchy == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= 2f)
            {
                SceneManager.LoadScene(3);
            } 
        }
    }
}
