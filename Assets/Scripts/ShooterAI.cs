using UnityEngine;
using System.Collections;

public class ShooterAI : MonoBehaviour {

    [SerializeField]
    private float RateOfFire;

    private GameObject _target;
    public GameObject Target
    {
        get
        {
            return _target;
        }
    }

    private float _firedLast;
    private Queue _enemies;

	void Awake ()
    {
        _enemies = new Queue();
        _firedLast = 1/RateOfFire;
	}
	
	void Update ()
    {
        if (_target != null)
        {
            _firedLast += Time.deltaTime;
            if (_firedLast >= 1/RateOfFire)
            {
                GameObject gameObject = Instantiate(Resources.Load("Projectile")) as GameObject;
                gameObject.transform.parent = this.transform;
                ProjectileAI projectile = gameObject.GetComponent<ProjectileAI>();
                projectile.Target = _target;
                projectile.Defense = this.gameObject;

                _firedLast = 0;
            }
        }
        else
        {
            if (_enemies.Count > 0)
            {
                _target = _enemies.Dequeue() as GameObject;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        _enemies.Enqueue(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (_target == other.gameObject)
        {
            _target = null;
        }
    }
}
