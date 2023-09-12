using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private int health;

    [SerializeField]
    private float speed;

    private SpriteRenderer spriteRenderer;

    private Vector2 moveVector = Vector2.zero;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");

        //Debug.Log("moveVector: " + moveVector);
    }

    private void Move()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);

        SetSpriteFilp();

        ConstrainToCameraBounds();
    }

    /// <summary>
    /// ī�޶� ��� ������ �÷��̾ �� ������ �Ѵ�.
    /// </summary>
    private void ConstrainToCameraBounds()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0f)
        {
            viewPos.x = 0f;
        }

        if (viewPos.x > 1f)
        {
            viewPos.x = 1f;
        }

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    private void SetSpriteFilp()
    {
        if (moveVector.x == 1)
        {
            spriteRenderer.flipX = false;
        }

        if (moveVector.x == -1)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�浹�ߴ�.");

            TakeDamage();


        }
    }

    private void TakeDamage()
    {
        if (health <= 0)
        {
            Debug.Log("ü���� 0�̴�.");
        }
        
        health--;

        Debug.Log("health: " + health);
    }
}
