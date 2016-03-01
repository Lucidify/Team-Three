using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class BattlePath : MonoBehaviour {
    public List<GameObject> enemies;
    int i = 0;
    bool move = true;
    public bool playerTurn = false;
    public PlayerPathStats playerStats;
    public Text health;
    public Text [] enemyText;
	// Use this for initialization
	void Start () {
        playerTurn = false;
	}
	
	// Update is called once per frame
	void Update () {
        health.text = "Player Health: " + playerStats.health;

        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemyText[i].text = enemies[i].gameObject.name + enemies[i].GetComponent<EnemyAttack>().enemyHealth; 
            }
        }







        if (playerStats.health <= 0)
            Application.LoadLevel(0);
        if (!playerTurn)
        {
            if (i < enemies.Count)
            {
                Camera.main.transform.position = new Vector3(transform.position.x, 32, transform.position.z);
                if (Camera.main.transform.position.x <= -0.54f)
                    Camera.main.transform.position = new Vector3(-0.54f, 32, Camera.main.transform.position.z);
                if (Camera.main.transform.position.x >= 0.54f)
                    Camera.main.transform.position = new Vector3(0.54f, 32, Camera.main.transform.position.z);
                if (Camera.main.transform.position.z <= -1.53)
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 32, -1.53f);
                if (Camera.main.transform.position.z >= 1.53f)
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 32, 1.53f);

                enemies[i].GetComponent<UnitMove>().MoveObject();
                if (enemies[i].GetComponent<UnitMove>().moveOn == true)
                {
                    if (enemies[i].GetComponent<UnitMove>().canAttack)
                    {
                        playerStats.health -= enemies[i].GetComponent<EnemyAttack>().enemyAttack;
                    }
                    i++;
                }
            }
            else
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    enemies[j].GetComponent<UnitMove>().first = true;
                    enemies[j].GetComponent<UnitMove>().second = true;
                    enemies[j].GetComponent<UnitMove>().runonce = true;
                    enemies[j].GetComponent<UnitMove>().moveOn = false;
                    enemies[j].GetComponent<UnitMove>().pathfinder = null;


                }
                i = 0;
                playerTurn = true;
            }
                
        }


        
        
            

	}
}
