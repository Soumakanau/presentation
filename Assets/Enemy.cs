using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attack = 1;
    public int hp = 3;
    public float attackRadius = 2;
    public float AttackTime;
    public Transform attackCenter = default;
    public Transform playerPos;
    public PlayerController player = default;

    Animator enemyAnime;
    float CountTime;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Diff().x < 10)
        //{
        //    //Enemy‚ÆPlayer‚ÌXŽ²‚Ì‹——£‚Ì·‚ª10‚æ‚è¬‚³‚­‚È‚Á‚½ê‡‚Ìˆ—‚ð‚±‚±‚É‘‚­
        //}
        //if (Diff().y < 10)
        //{
        //    //Enemy‚ÆPlayer‚ÌYŽ²‚Ì‹——£‚Ì·‚ª10‚æ‚è¬‚³‚­‚È‚Á‚½ê‡‚Ìˆ—‚ð‚±‚±‚É‘‚­

        //}

        if (Diff().x < 3 && Diff().y < 3)
        {
            enemyAnime.SetTrigger("IsAttack");
        }

        CountTime += Time.deltaTime;
    }

    Vector2 Diff()
    {
        float diifX = Mathf.Abs(transform.position.x - playerPos.position.x);
        float diifY = Mathf.Abs(transform.position.y - playerPos.position.y);

        return new Vector2(diifX, diifY);
    }


    public void OnDamage(int damage)
    {
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
            if (player && AttackTime < CountTime)
            {
                Debug.Log(c.gameObject.name + "‚ÉUŒ‚");
                player.OnDamage(attack);
                CountTime = 0;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackCenter.position, attackRadius);
    }

}
