using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Vector3 inputVec;


    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpPower = 1f;
    public int jumpCount = 0;
    public int Hp = 5;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        Die();
    }

    public void Move()
    {
        Vector3 dirVec = inputVec * moveSpeed;

        rigid.velocity = dirVec;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            jumpCount++;
            if (jumpCount > 1)
            {
                jumpCount = 1;
            }
        }

        if (coll.gameObject.CompareTag("Enemy"))
        {
            Hp--;
            StartCoroutine("ColorChange");
        }
    }

    IEnumerator ColorChange()
    {
        sprite.material.color = Color.blue;

        yield return new WaitForSeconds(0.5f);
        yield return sprite.material.color = Color.white;
    }

    public void Die()
    {
        if(Hp == 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            GameManager.Instance.Die();
        }
    }
}
