using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPlayer : MonoBehaviour {

	public GameObject origin;
	public GameObject origin01;
	public GameObject target;
	public GameObject Beam;
	public GameObject Beam01;
	public Vector3 direction;
	public static Vector3 dir;
	public GameObject beamParent;


	public GameObject origincopy;
	public GameObject targetCopy;
	public GameObject WorldPosition;
	public GameObject TargetWorldPosition;

	public GameObject canvas01;

    public ParticleSystem MagicCircle;








	GameObject playerbeam=null;
	void Start () {
		
	}
	

	void Update () {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            ShootBeam();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            ShootBeam01();
        }
		if (playerbeam) {
			playerbeam.transform.Translate (direction*0.01f);

		}

		dir = direction;
		
	}


	public void ShootBeam()
	{
		
		
		StartCoroutine (BeamLoadAndAttack ());
	}
	public void ShootBeam01()
	{


		StartCoroutine (BeamLoadAndAttack01 ());
	}


	IEnumerator BeamLoadAndAttack()
	{
		SlashSword.canReleaseBeam = true;
		//canvas01.isActiveAndEnabled = false;

		canvas01.SetActive (false);
        MagicCircle.Play();
        

//		cubeCopy = Instantiate (cubePrefab, cubePrefab.transform);
//		cubeCopy.transform.SetParent (enemyCubeWorldParent.transform);
////		target = cubeCopy;
//
//		originCopy = Instantiate (origin, origin.transform);
//		originCopy.transform.SetParent (enemyCubeWorldParent.transform);
//		origincopy=Instantiate(origin,origin.transform);
//		targetCopy = Instantiate (target, target.transform);
//
//		origincopy.transform.SetParent (WorldPosition.transform);
//		targetCopy.transform.SetParent (WorldPosition.transform);
//		targetCopy.transform.SetParent (TargetWorldPosition.transform);
//			







		yield return new WaitForSeconds (2.06f);
		if (SlashSword.canReleaseBeam == true) {

			playerbeam = Instantiate (Beam, origin.transform);
			playerbeam.transform.SetParent (beamParent.transform);
			direction = target.transform.position - origin.transform.position;
		}
		//canvas01.isActiveAndEnabled = true;
		canvas01.SetActive (true);
        MagicCircle.Stop();
		SlashSword.canReleaseBeam = false;
        

	}
	IEnumerator BeamLoadAndAttack01()
	{
		SlashSword.canReleaseBeam = true;

		yield return new WaitForSeconds (0.3f);
		if (SlashSword.canReleaseBeam == true) {

			playerbeam = Instantiate (Beam01, origin01.transform);
			playerbeam.transform.SetParent (beamParent.transform);
			direction = target.transform.position - origin01.transform.position;
		}

		SlashSword.canReleaseBeam = false;

	}
	public void StopBeam()
	{
		StopCoroutine (BeamLoadAndAttack ());
		StopCoroutine (BeamLoadAndAttack01 ());
	}


}
