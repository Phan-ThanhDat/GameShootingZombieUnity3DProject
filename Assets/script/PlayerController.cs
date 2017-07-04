using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int damage =1;
	public float fireTime = 0.3f;
	private float lastFireTime= 0;
    private Animator anim;
    public GameObject Smoke;
    public Animator GunAnimator;
    public GameObject gunHead;

	// Use this for initialization
	void Start () {
       // anim = gameObject.GetComponent<Animator>();
		updateFireTime ();
        
        GunAnimator = transform.FindChild("Gun").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            SetFireAnim(true);
            Fire();
            InsSmoke();
        }

        else
            SetFireAnim(false);

    }
	void updateFireTime()
	{
		lastFireTime = Time.time;
	}

    
    void SetFireAnim(bool isFire)
    {
        GunAnimator.SetBool("isGun",isFire);
    }

    void InsSmoke()
    {
        GameObject Sm = Instantiate(Smoke, gunHead.transform.position, gunHead.transform.rotation) as GameObject;
        Destroy(Sm, 0.5f);
    }

	void Fire()
	{
        if (Time.time >= lastFireTime + fireTime)
        {
            

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //test change

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.transform.tag.Equals("Zombie"))
                {
                    hit.transform.gameObject.GetComponent<ZombieController>().getHit(damage);
                    
                }

            }

            

            updateFireTime();
        }

       


    }
}
