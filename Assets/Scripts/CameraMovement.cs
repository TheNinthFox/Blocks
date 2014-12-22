using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private GameObject HitPlane;

    [SerializeField]
    private float MoveSpeed;
    
    [SerializeField]
    private float ZoomSpeed;

    public Vector3 MoveTarget { get; set; }
    public Vector3 ZoomTarget { get; set; }
    private const float MIN_ZOOM = -4.0f;
    private const float MAX_ZOOM = -20.0f;

	// Use this for initialization
	void Start ()
    {
        MoveTarget = new Vector3(0f, 0f, 0f);
        ZoomTarget = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
        zoom();
	}

    void move()
    {
        Vector3 from = transform.position;
        from.z = transform.position.z;
        Vector3 to = MoveTarget;
        to.z = transform.position.z;

        transform.position = Vector3.Lerp(from, to, MoveSpeed * Time.deltaTime);

        Vector3 position = transform.position;
        position.z = HitPlane.transform.position.z;
        HitPlane.transform.position = position;
    }

    void zoom()
    {
        Vector3 from = transform.position;
        from.x = transform.position.x;
        from.y = transform.position.y;

        Vector3 to = ZoomTarget;
        to.x = transform.position.x;
        to.y = transform.position.y;

        if (to.z < MAX_ZOOM)
            to.z = MAX_ZOOM;
        else if (to.z > MIN_ZOOM)
            to.z = MIN_ZOOM;

        transform.position = Vector3.Lerp(from, to, ZoomSpeed * Time.deltaTime);
    }
}
