using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int at = 1;
    public int hp = 3;
    public float attackRadius = 2;
    public Transform attackCenter = default;
    public Transform playerPos;
    Animator enemyAnime;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Diff().x < 10)
        {
            Attack();//EnemyとPlayerのX軸の距離の差が10より小さくなった場合の処理をここに書く

        }
        /*if (Diff().y < 10)
        {
            //EnemyとPlayerのY軸の距離の差が10より小さくなった場合の処理をここに書く

        }
        if (Diff().x < 10 && Diff().y < 10)
        {

        }*/
    }

    Vector2 Diff()
    {
        float diifX = Mathf.Abs(transform.position.x - playerPos.position.x);
        float diifY = Mathf.Abs(transform.position.y - playerPos.position.y);

        return new Vector2(diifX, diifY);
    }


    public void OnDamage(int damage)
    {
        Debug.Log("point");
        hp -= damage;
        enemyAnime.SetTrigger("IsHurt");
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        hp = 0;
        enemyAnime.SetTrigger("IsDie");
    }
    void Attack()
    {
        
        var col = Physics2D.OverlapCircleAll(attackCenter.position, attackRadius);
        foreach (var c in col)
        {
            PlayerController player = c.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                enemyAnime.SetTrigger("IsAttack");
                Debug.Log(c.gameObject.name + "に攻撃");
            }    
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackCenter.position, attackRadius);
    }

}
