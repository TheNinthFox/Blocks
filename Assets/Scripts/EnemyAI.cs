using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject Target;

    [SerializeField]
    private float Speed;

    void Awake() 
    {

    }

	void Update ()
    {
        move();
	}

    void move()
    {
        Vector3 velocity = new Vector3(Speed, 0f, 0f);
        Vector3 angularVelocity = new Vector3(0f, 0f, -Speed);

        if (Target.transform.position.x < transform.position.x)
        {
            velocity.x = -velocity.x;
            angularVelocity = -angularVelocity;
        }

        //rigidbody.velocity = velocity;
        rigidbody.angularVelocity = angularVelocity;
    }
}
