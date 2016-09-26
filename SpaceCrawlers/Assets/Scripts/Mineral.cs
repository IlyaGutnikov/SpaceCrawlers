using UnityEngine;
using System.Collections;

public class Mineral : MonoBehaviour {

	public int health = 100;

	public int damagePerCollision = 25;

	void OnCollisionEnter (Collision col) {
		
		if (col.gameObject.tag.Equals ("SpaceCrawler")) {

			health = health - damagePerCollision;

			if (health <= 0) {
			
				Destroy (this.gameObject);
			}
		}
	}

}
