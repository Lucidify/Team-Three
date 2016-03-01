using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
    public bool run = true;
    public Enemies enemies;
    // Use this for initialization
    float battleTime = 0;
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        battleTime += Time.deltaTime;
        if (run)
            StartCoroutine(EnemyTurn());
	}

    IEnumerator EnemyTurn()
    {
        run = false;
        enemies.enemies[0].gameObject.GetComponent<Battle>().EnemyMove();
        yield return new  WaitForSeconds(3.0f);
        print("Waited 3 seconds");
        run = true;
    }
}
