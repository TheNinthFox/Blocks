using UnityEngine;
using System.Collections;
using Assets.Scripts.Interfaces;

public class ProjectileAI : MonoBehaviour {

    private GameObject _target;
    public GameObject Target
    {
        get
        {
            return _target;
        }

        set
        {
            _target = value;
        }
    }

    private GameObject _defense;
    public GameObject Defense
    {
        get
        {
            return _defense;
        }
        set
        {
            _defense = value;
        }
    }

    [SerializeField]
    private float Speed;

	
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
        else
        {
            ShooterAI shooter = _defense.GetComponent<ShooterAI>();
            _target = shooter.Target;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        IDamageable enemy = other.gameObject.GetComponent<EnemyAI>() as IDamageable;
        enemy.takeDamage(34);
        Destroy(this.gameObject);
    }
}
