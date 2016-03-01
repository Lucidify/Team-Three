using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemies : MonoBehaviour {

    public List<GameObject> enemies;
    public GameObject[] enemyPos;
    bool runonce = false;
	// Use this for initialization
	void Start () {
        //enemies = new List<GameObject>();

        // give each enemy a position
      
	}
	
	// Update is called once per frame
	void Update () {
        enemyPos = GameObject.FindGameObjectsWithTag("Enemy");
        if (!runonce && enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count;)
            {
                int randX = Random.Range(0, 20);
                int randY = Random.Range(10, 20);
                Vector3 placement = new Vector3(randX * 0.32f, randY * 0.32f, 0);
                if (!Physics2D.Linecast(placement,placement, 1 << LayerMask.NameToLayer("Object")))
                {
                    Vector3 pos = new Vector3(0.16f + (randX * 0.32f), 0.16f + (randY * 0.32f), 0);
                    Instantiate(enemies[i], pos, transform.rotation);

                    i++;
                }
                    
            }
            runonce = true;
           
        }
        
    }
}
