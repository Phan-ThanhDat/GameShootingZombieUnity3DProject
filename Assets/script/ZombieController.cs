using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public int zombieBlood = 3;
    private float lastShootenTime = 0;
    private Animator anim;
    private bool isShooten;
    public bool IsAttack = false;
    public float attackTime = 1;
    public float lastAttackTime = 0;

    public bool IsShooten
    {
        get { return isShooten; }
        set
        {
            isShooten = value;
            ShootAnim(isShooten);
            updateShootenTime();
        }
    }

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        IsShooten =false;
        updateShootenTime();

    }

    void updateShootenTime()
    {
        lastShootenTime = Time.time;
    }

    void updateAttackTime()
    {
        lastAttackTime = Time.time;
    }
   
    void ShootAnim(bool isShooten)
    {
        anim.SetBool("isShooten", isShooten);
    }

    void AttackAnim(bool isAttack)
    {
        anim.SetBool("isAttack", isAttack);
    }

    // Update is called once per frame
    void Update () {
        if (IsShooten && Time.time >= lastShootenTime + 0.3)
        {
            IsShooten = false;
        }

        if (IsAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackTime)
        {
            AttackAnim(true);
        }
       
        else
            AttackAnim(false);
    }

	public void getHit(int damage)
	{
        IsShooten = true;
        zombieBlood -= damage;

		if (zombieBlood <= 0)
			Dead ();
	}

	public  void Dead()
	{
        anim.SetBool("isDead", true);
        Destroy (gameObject,1.9f);
	}
}
