using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudBeam : MonoBehaviour {

	//public GameObject beamcopy;
	public GameObject BeamPrefab;
	public Rigidbody wave;
	public GameObject WorldBeamPos;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void beammove()
	{
		BeamPrefab.SetActive (true);
//		GameObject go = Instantiate (BeamPrefab, BeamPrefab.transform);
//		BeamPrefab.SetActive (false);
//		go.SetActive (true);
//		go.transform.SetParent (WorldBeamPos.transform);
//		wave = go.GetComponent<Rigidbody> ();
//		wave.AddForce (new Vector3 (5, 0, 0));
	}
}
