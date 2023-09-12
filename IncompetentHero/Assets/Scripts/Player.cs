using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    //private Vector2 moveDirection = Vector2.zero;

    private Vector2 moveVector = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");

        Debug.Log("moveVector: " + moveVector);
    }

    private void Move()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�浹�ߴ�.");
            // �÷��̾� HP�� ���ҽ�Ų��.
        }
    }
}
