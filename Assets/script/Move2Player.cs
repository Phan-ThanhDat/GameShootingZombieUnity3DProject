using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Player : MonoBehaviour {

	GameObject player;
	GameObject lookAtTarget;

	float moveSpeed;
	public float minspeed = 0.5f;
	public float maxspeed = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		lookAtTarget = GameObject.FindGameObjectWithTag ("LookAtTarget");
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void UpdateMovespeed()
	{
		moveSpeed = Random.Range (minspeed, maxspeed +1);
	}

	void Move () {
		if (!player || !lookAtTarget)
			return;

        if (Vector3.Distance(transform.position,player.transform.position) >= 2 )
        {
            UpdateMovespeed();
            transform.LookAt(lookAtTarget.transform.position);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isIdle",true);
            

            gameObject.GetComponent<ZombieController>().IsAttack = true;
            gameObject.GetComponent<Move2Player>().enabled = false;
        }

		

	}
}
