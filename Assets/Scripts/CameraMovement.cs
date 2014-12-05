using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Vector3 Target { get; set; }

	// Use this for initialization
	void Start ()
    {
        Target = new Vector3(0f, 0f, 0f);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
	}

    void move()
    {
        Vector3 from = transform.position;
        from.z = transform.position.z;
        Vector3 to = Target;
        to.z = transform.position.z;

        transform.position = Vector3.Lerp(from, to, Time.deltaTime);
    }
}
