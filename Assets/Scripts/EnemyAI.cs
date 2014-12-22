using UnityEngine;
using System.Collections;
using Assets.Scripts._3DUI;
using Assets.Scripts.Interfaces;

public class EnemyAI : MonoBehaviour, IDamageable {

    // Needs to be public so it can be accessed via editor & scripts
    public GameObject Target;

    // How fast is the enemy?
    [SerializeField]
    private float Speed;

    // Corresponding UI element
    private EnemyUI UI;

    // Health
    private float _health;

    // Max Health
    [SerializeField]
    private float _maxHealth;

    // Setup
    void Awake() 
    {
        Transform healthbar = this.transform.GetChild(0);
        UI = new EnemyUI(gameObject, healthbar.GetComponent<RectTransform>());
        _health = _maxHealth;
    }

    // Update
	void Update ()
    {
        move();

        UI.update();
	}

    // Move the ball
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

    float IDamageable.Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    void IDamageable.takeDamage(float amount)
    {
        _health -= amount;

        if (_health <= 0) (this as IDamageable).die();
    }

    void IDamageable.die()
    {
        Destroy(gameObject);
    }


    float IDamageable.MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
}
