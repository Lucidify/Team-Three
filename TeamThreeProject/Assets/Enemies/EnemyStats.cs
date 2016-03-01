using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {
    public int health;
    public int attack;
    Battle battle;
	// Use this for initialization
	void Start () {
        battle = GameObject.FindGameObjectWithTag("Battle").GetComponent<Battle>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
            battle.enemySize -= 1;
        }
	}
}
