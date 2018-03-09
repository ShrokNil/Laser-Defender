using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

public GameObject enemyPrefab;
		public float width = 10f;
		public float height = 5f;
		public float speed = 5f;
		private bool movingRight = true;
		

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
	
	//Spawns enemies
		foreach ( Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	
	}
	
	public void OnDrawGizmos(){
			Gizmos.DrawWireCube(transform.position, new Vector3 (width, height));
	}
	
	// Update is called once per frame
	void Update () {
	 if (movingRight){
	 		transform.position += new Vector3(speed*Time.deltaTime,0);
	 }else{
			transform.position += new Vector3(-speed*Time.deltaTime,0);
	 	}
	}
}
