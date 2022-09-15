using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;

    private bool isDead;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Aleteo();
        }
    }
    private void Aleteo()
    {
        playerRb.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Aleteo");
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        playerAnimator.SetTrigger("Muelto");
        GameManager.Instance.GameOver();
    }
}


