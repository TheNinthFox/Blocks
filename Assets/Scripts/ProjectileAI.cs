using UnityEngine;
using System.Collections;

public class ProjectileAI : MonoBehaviour {

    public GameObject _target;
    //public GameObject Target { get; set; }
    public float Speed;

	
	void Update ()
    {
        // Find and move to the target
        if (_target != null)
        {
            Vector3 position = _target.transform.position - this.transform.position;
            float distance = position.magnitude;
            Vector3 direction = position / distance;

            this.transform.position += direction * Speed * Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
