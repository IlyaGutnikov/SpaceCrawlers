using UnityEngine;
using System.Collections;

public class SpaceCrawlerAI : MonoBehaviour {
	
	private SteeringBasics steeringBasics;
	private Wander1 wander;

	/// <summary>
	/// Space Crawler base
	/// </summary>
	public Transform baseTarget;

	/// <summary>
	/// Current Target
	/// </summary>
	public Transform currentTarget;

	public bool IsWander = true;

	public bool IsGoingToBase = false;

	// Use this for initialization
	void Start () {
		steeringBasics = GetComponent<SteeringBasics>();
		wander = GetComponent<Wander1>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 accel;
		if (IsWander == true) {
			
			accel = wander.getSteering ();
		} else {
			//go to base if find mineral
			if (IsGoingToBase == true) {
				accel = steeringBasics.seek(baseTarget.position);
			} else {
				//go to mineral if it not-empty
				accel = steeringBasics.seek(currentTarget.position);
			}
		}

		steeringBasics.steer(accel);
		steeringBasics.lookWhereYoureGoing();
	}
}
