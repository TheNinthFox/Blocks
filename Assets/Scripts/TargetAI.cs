using UnityEngine;
using System.Collections;

public class TargetAI : MonoBehaviour {

	void Awake () {
	
	}
	
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
