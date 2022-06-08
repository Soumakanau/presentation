using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHp = 3;
    public int hp = 3;
    public int at = 1;
    public float speed = 3f;
    public float attackRadius;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public Slider hpBar = default;
    Rigidbody2D rb;
    Animator playerAnima;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnima = GetComponent<Animator>();
        hp = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = hp;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        Movement();
        Debug.Log(hp);
    }
    void Attack()
    {
        playerAnima.SetTrigger("IsAttack");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name + "に攻撃");
            hitEnemy.GetComponent<Enemy>().OnDamage(at);
        }
    }


    private void OnDrawGizmosSelected()//当たり判定の範囲の表示
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }



    void Movement()//プレイヤー移動
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    public void OnDamage(int damage)
    {
        hp -= damage;
        hpBar.value = hp;
        playerAnima.SetTrigger("IsHurt");
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        hp = 0;
        playerAnima.SetTrigger("IsDie");
    }
}
