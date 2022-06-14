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
    public GameObject Player;
    public GameObject Enemy1;
    
    // public float speed = 0.3f;
    Rigidbody2D rb;
    /*Transform Target;
    GameObject Player;
    [SerializeField] float MoveSpeed = 2f;
    [SerializeField] int DetecDist = 8;
    [SerializeField] bool InArea = false;*/



    Animator enemyAnime;
    float CountTime;
    // Start is called before the first frame update
    void Start()
    {
        /*Player = GameObject.FindWithTag("Player");
        Target = Player.transform;*/
        rb = GetComponent<Rigidbody2D>();
        enemyAnime = this.gameObject.GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {
        //move();
        /*if (InArea)
        {
            this.transform.LookAt(Target.transform);

            Vector2 direction = Target.position - this.transform.position;
            direction = direction.normalized;

            Vector2 velocity = direction * MoveSpeed;
        }*/

        //if (Diff().x < 10)
        //{
        //Enemy‚ÆPlayer‚ÌXŽ²‚Ì‹——£‚Ì·‚ª10‚æ‚è¬‚³‚­‚È‚Á‚½ê‡‚Ìˆ—‚ð‚±‚±‚É‘‚­
        //}
        //if (Diff().y < 10)
        //{
        //    //Enemy‚ÆPlayer‚ÌYŽ²‚Ì‹——£‚Ì·‚ª10‚æ‚è¬‚³‚­‚È‚Á‚½ê‡‚Ìˆ—‚ð‚±‚±‚É‘‚­

        //}
        Vector2 posA = Player.transform.position;
        Vector2 posB = Enemy1.transform.position;
        float dis = Vector2.Distance(posA,posB);
        
        if (dis < 2 )
        {
            Vector2 force = new Vector2(-1, 0);
            rb.AddForce(force);
        }
        else if (dis > 2)
        {
            Vector2 force = new Vector2(0, 0);
        }
       






        
        if (Diff().x < 1 && Diff().y < 1)
        {
            enemyAnime.SetTrigger("IsAttack");
        }

        CountTime += Time.deltaTime;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        InArea = false;
    }*/

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
        Destroy(this.gameObject, 1.5f);
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

    


    /*private void move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ("Enemy" == collision.gameObject.tag)
        {
            speed = speed * 3;
        }
    }*/
}
