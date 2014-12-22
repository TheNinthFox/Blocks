using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private float SpawnDelay;

    private float timer;

	void Awake ()
    {
        timer = 0f;
	}
	
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnDelay)
        {
            GameObject gameObject = Instantiate(Resources.Load("Enemy")) as GameObject;
            GameObject World = GameObject.Find("World");
            gameObject.transform.parent = World.transform;
            timer = 0f;
        }
	}
}
