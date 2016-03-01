using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    public int enemyHealth;
    public int enemyAttack;
    BattlePath battle;
	// Use this for initialization
	void Start ()
    {
        enemyHealth = Random.Range(80, 100);
        enemyAttack = Random.Range(6, 10);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyHealth <= 0)
        {
            battle = GameObject.FindGameObjectWithTag("Battle").GetComponent<BattlePath>();
            battle.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
	}
}
