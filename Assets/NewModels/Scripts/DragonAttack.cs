using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonAttack : MonoBehaviour {

	public GameObject FireParticles;
	public ParticleSystem fire;
	public static float EnemyHealth=1f;
	public float Health;
	public Image healthBarImg;
	public GameObject FlameThrower;

	public Vector3 redDrgonPos;


	public GameObject dragon;
	public Animator anim;
	public GameObject player;
	public GameObject DragonRootPos;
	public float distance;
	public bool BeginMovingTowardsPlayer=false;
	public bool isMovingTowardsPlayer=false;
	public bool isMovingAwayFromPlayer=false;
	public bool isAtDragonRootPos=false;
	public int RandIntNum;
	public int timeElapsed=0;
	Vector3 direction;
    public ParticleSystem sparks;
    public ParticleSystem smoke;
    public static bool isGlowing = false;

	//public bool at1isplaying = false;
	//public bool at2isplaying = false;
	public int num;




	void Start () {
		
		//FireParticles.SetActive (false);
		fire = FireParticles.GetComponent<ParticleSystem> ();
		anim = GetComponent<Animator> ();
		fire.Stop ();

		StartCoroutine (Attack01 ());

	}
	
	// Update is called once per frame
	void Update () {
		redDrgonPos = dragon.transform.position;

		timeElapsed += (int)Time.deltaTime;
		direction = this.transform.position - player.transform.position;
		distance = direction.magnitude;
		healthBarImg.fillAmount = EnemyHealth;
		Health = EnemyHealth;
		if (distance > 12f && timeElapsed%2==0 && BeginMovingTowardsPlayer==false && isMovingAwayFromPlayer==false) 
		{
			RandIntNum = Random.Range (1, 100000);
			if (RandIntNum % 319 == 0) {
				//if(redDrgonPos.z<=158)
					MoveTowardsPlayer ();
			}
		}
		if (distance > 12f && isMovingTowardsPlayer == true && isMovingAwayFromPlayer==false) 
		{
			this.transform.Translate (0, 0, 10 * Time.deltaTime);
			anim.ResetTrigger ("attack01");
			anim.ResetTrigger ("attack02");
			anim.ResetTrigger ("scream");
			anim.ResetTrigger ("idle");
			anim.ResetTrigger ("flame");
			StopCoroutine (Attack01 ());
			StopCoroutine (Attack02 ());
			StopCoroutine (Scream ());
			StopCoroutine (BreatheFire ());

			StartCoroutine (RunTowardsPlayer ());

		}
		if (distance <= 12f) 
		{	
			BeginMovingTowardsPlayer = false;
			isMovingTowardsPlayer = false;

			MoveAwayFromPlayer ();
		}
		//if ((this.transform.position - DragonRootPos.transform.position).magnitude <= 2)
        if(this.transform.position.z > 175)
        {
			isAtDragonRootPos = true;
			MovedAwayFromPlayer ();
		} 
		else {
			isAtDragonRootPos = false;
		}

		if ( isMovingTowardsPlayer == false && BeginMovingTowardsPlayer == false && isMovingAwayFromPlayer == true && isAtDragonRootPos==false) 
		{
			//if (this.transform.position.z < DragonRootPos.transform.position.z)
				this.transform.Translate (0, 0, -10 * Time.deltaTime);
			StartCoroutine (RunAwayFromPlayer ());
		}

		
	}
	public void MoveTowardsPlayer()
	{	
		BeginMovingTowardsPlayer=true;
		isMovingTowardsPlayer = true;
	}
	public void MoveAwayFromPlayer()
	{
		StartCoroutine (StayMoved ());
	}
	IEnumerator StayMoved()
	{
		yield return new WaitForSeconds (3f);
		isMovingAwayFromPlayer = true;
	}
	public void MovedAwayFromPlayer()
	{
		isMovingAwayFromPlayer = false;
	}

//	public void PrimaryAttack()
//	{
//		//StartCoroutine (BreatheFire ());
//		//Attack01();
//		StartCoroutine(Attack01());
//	}
//	public void SecondaryAttack()
//	{
//		//StartCoroutine (BreatheFire ());
//		//Attack02();
//		StartCoroutine(Attack02());
//	}
	IEnumerator BreatheFire()
	{
//		FireParticles.SetActive (true);
		fire.Play();
		yield return new WaitForSeconds (4f);
		fire.Stop ();


	}
	IEnumerator RunTowardsPlayer()
	{
		anim.SetTrigger ("run");
		yield return new WaitUntil (() => distance <= 12f);
		anim.ResetTrigger ("run");
	}

	IEnumerator RunAwayFromPlayer()
	{
		anim.SetTrigger ("run");
		yield return new WaitUntil (() => isAtDragonRootPos==true);
		anim.ResetTrigger ("run");
	}


	IEnumerator Attack01()
	{
//		at1isplaying = true;
//		at2isplaying = false;
		anim.SetTrigger ("attack01");
		yield return new WaitForSeconds (1.0f);
		anim.ResetTrigger ("attack01");
		//at1isplaying = false;
		num = Random.Range (1, 6);
		if (isMovingTowardsPlayer == false && isMovingAwayFromPlayer==false) {
			if (num == 1)
				StartCoroutine (Attack01 ());
			else if (num == 2)
				StartCoroutine (Attack02 ());
			else if (num == 3)
				StartCoroutine (Scream ());
			else if (num == 4)
				StartCoroutine (Idle ());
			else if (num == 5)
				StartCoroutine (Flames ());
		}
		else
		StartCoroutine (Attack01 ());
		
		
	}
	IEnumerator Attack02()
	{
		//at2isplaying = true;
		//at1isplaying = false;
		anim.SetTrigger ("attack02");
		yield return new WaitForSeconds (2.0f);
		anim.ResetTrigger ("attack02");
		//at2isplaying = false;
		num = Random.Range (1, 6);
		if (num == 1)
			StartCoroutine (Attack01 ());
		else if (num == 2)
			StartCoroutine (Attack02 ());
		else if (num == 3)
			StartCoroutine (Scream ());
		else if (num == 4)
			StartCoroutine (Idle ());
		else if (num == 5)
			StartCoroutine (Flames ());
	}
	IEnumerator Scream()
	{
		//at2isplaying = true;
		//at1isplaying = false;
		anim.SetTrigger ("scream");
        sparks.Play();
        smoke.Play();
        isGlowing = true;
        yield return new WaitForSeconds (4f);
		anim.ResetTrigger ("scream");
        sparks.Stop();
        smoke.Stop();
        isGlowing = false;

		//at2isplaying = false;
		num = Random.Range (1, 6);
		if (num == 1)
			StartCoroutine (Attack01 ());
		else if (num == 2)
			StartCoroutine (Attack02 ());
		else if (num == 3)
			StartCoroutine (Scream ());
		else if (num == 4)
			StartCoroutine (Idle ());
		else if (num == 5)
			StartCoroutine (Flames ());
	}
	IEnumerator Idle()
	{
		//at2isplaying = true;
		//at1isplaying = false;
		anim.SetTrigger ("idle");
		yield return new WaitForSeconds (3.0f);
		anim.ResetTrigger ("idle");

		//at2isplaying = false;
		num = Random.Range (1, 6);
		if (num == 1)
			StartCoroutine (Attack01 ());
		else if (num == 2)
			StartCoroutine (Attack02 ());
		else if (num == 3)
			StartCoroutine (Scream ());
		else if (num == 4)
			StartCoroutine (Idle ());
		else if (num == 5)
			StartCoroutine (Flames ());
	}
	IEnumerator Flames()
	{
		//at2isplaying = true;
		//at1isplaying = false;
		anim.SetTrigger ("flame");

		fire.Play();
		FlameThrower.SetActive (true);
		yield return new WaitForSeconds (3.40f);
		fire.Stop ();
		FlameThrower.SetActive (false);
		anim.ResetTrigger ("flame");


		//at2isplaying = false;
		num = Random.Range (1, 6);
		if (num == 1)
			StartCoroutine (Attack01 ());
		else if (num == 2)
			StartCoroutine (Attack02 ());
		else if (num == 3)
			StartCoroutine (Scream ());
		else if (num == 4)
			StartCoroutine (Idle ());
		else if (num == 5)
			StartCoroutine (Flames ());
	}



}
