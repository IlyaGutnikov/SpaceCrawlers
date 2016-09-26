using UnityEngine;
using System.Collections;

public class SpaceCrawlerAI : MonoBehaviour {
	
	private SteeringBasics steeringBasics;
	private Wander1 wander;

	/// <summary>
	/// Space Crawler base
	/// </summary>
	public GameObject baseTarget;

	/// <summary>
	/// Current Target
	/// </summary>
	public GameObject currentTarget;

	public TrailRenderer trailRenderer;

	public bool IsWander = true;

	public bool IsGoingToBase = false;

	// Use this for initialization
	void Start () {
		steeringBasics = GetComponent<SteeringBasics>();
		wander = GetComponent<Wander1>();
		trailRenderer.enabled = false;
	}

	void OnCollisionEnter (Collision col) {
	
		if(col.gameObject.tag.Equals("Mineral") && (currentTarget == null))
		{
			IsWander = false;
			IsGoingToBase = true;
			currentTarget = col.gameObject;

			trailRenderer.enabled = true;
		}

		if(col.gameObject.tag.Equals("Mineral") && (currentTarget != null))
		{
			IsWander = false;
			IsGoingToBase = true;

			trailRenderer.enabled = true;
		}

		if(col.gameObject.tag.Equals("Base") && (currentTarget != null))
		{
			IsWander = false;
			IsGoingToBase = false;
		}

		if(col.gameObject.tag.Equals("Base") && (currentTarget == null))
		{
			IsWander = true;
			IsGoingToBase = false;
			trailRenderer.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 accel;
		if (IsWander == true) {
			
			accel = wander.getSteering ();
		} else {
			//go to base if find mineral
			if (IsGoingToBase == true) {
				accel = steeringBasics.seek(baseTarget.transform.position);
			} else {
				//go to mineral if it not-empty
				accel = steeringBasics.seek(currentTarget.transform.position);
			}
		}

		steeringBasics.steer(accel);
		steeringBasics.lookWhereYoureGoing();
	}
}
