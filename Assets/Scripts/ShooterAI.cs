using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShooterAI : MonoBehaviour {

    // Rate of Fire
    [SerializeField]
    private float RateOfFire;

    // Which target to follow
    private GameObject _target;
    public GameObject Target
    {
        get
        {
            return _target;
        }
    }

    // Time since last shot
    private float _timeSinceLastShot;

    // Enemy List
    private  List<GameObject> _enemies;

	void Awake ()
    {
        _enemies = new List<GameObject>();
        _timeSinceLastShot = 1/RateOfFire;
	}
	
	void Update ()
    {
        if (_target != null)
        {
            // Try to fire at our target
            _timeSinceLastShot += Time.deltaTime;
            if (_timeSinceLastShot >= 1/RateOfFire)
            {
                GameObject gameObject = Instantiate(Resources.Load("Projectile")) as GameObject;
                gameObject.transform.position = transform.position;
                gameObject.transform.parent = this.transform;
                ProjectileAI projectile = gameObject.GetComponent<ProjectileAI>();
                projectile.Target = _target;
                projectile.Defense = this.gameObject;

                _timeSinceLastShot = 0;
            }
        }
        else
        {
            // Set a new target if possible
            if (_enemies.Count > 0)
            {
                foreach (GameObject current in _enemies)
                {
                    if (_target != null)
                    {
                        EnemyAI enemy = current.GetComponent<EnemyAI>();
                        GameObject enemyTarget = enemy.Target;
                        if ((current.transform.position - enemyTarget.transform.position).magnitude < (_target.transform.position - enemyTarget.transform.position).magnitude)
                        {
                            _target = current;
                        }
                    }
                    else
                    {
                        _target = current;
                    }
                }
            }
        }
	}

    // Add enemy to the queue
    void OnTriggerEnter(Collider other)
    {
        _enemies.Add(other.gameObject);
    }

    // Remove enemy as a target if it is out of range
    // Remove enemies from List that are out of range
    void OnTriggerExit(Collider other)
    {
        if (_target == other.gameObject)
        {
            _target = null;
        }

        GameObject enemy = _enemies.Find(x => x == other.gameObject);
        if (enemy != null)
        {
            _enemies.Remove(enemy);
        }
    }
}
