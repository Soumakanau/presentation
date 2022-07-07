using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxHp = 5;
    public int hp = 5;
    [SerializeField] int at = 1;
    [SerializeField] float speed = 1.5f;
    public float attackRadius;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public Slider hpBar = default;
    Rigidbody2D rb;
    Animator playerAnima;
    List<ItemBase2D> _itemList = new List<ItemBase2D>();
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
        
        if (hp >= 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
            Movement();
         }
        if (Input.GetButtonDown("Fire1"))
        {
            if (_itemList.Count > 0)
            {
                // リストの先頭にあるアイテムを使って、破棄する
                ItemBase2D item = _itemList[0];
                _itemList.RemoveAt(0);
                item.Activate();
                Destroy(item.gameObject);
            }
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

        void Movement()//プレイヤー移動
        {
            float x = Input.GetAxisRaw("Horizontal");

            if (x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            if (x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            playerAnima.SetFloat("Speed", Mathf.Abs(x));
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
        }
    }
    void GetItem(ItemBase2D item)
    {
        _itemList.Add(item);
    }
    private void OnDrawGizmosSelected()//当たり判定の範囲の表示
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
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
    public void AddDamege(int Damege)
    {
        at += Damege;
    }
    public void AddHeart(int recovery)
    {
        hp += recovery;
        hpBar.value = hp;
    }
}



