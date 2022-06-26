using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	private Rigidbody Rb;
	private float minSpeed = 15;
	private float maxSpeed = 18;
	private float maxTorque = 2;
	private float xRange = 4;
	private float yspawnPos = 2;
	private GameManager gameManager;
	public ParticleSystem explosionParticle;
	public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		Rb.AddForce(Vector3.up * Random.Range(minSpeed , maxSpeed) , ForceMode.Impulse);
		Rb.AddTorque(Random.Range(-maxTorque , maxTorque) , Random.Range(-maxTorque , maxTorque) , Random.Range(-maxTorque , maxTorque), ForceMode.Impulse);
		
		transform.position = new Vector3(Random.Range(-xRange,xRange) , -yspawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnMouseDown(){
		if(gameManager.isGameActive){
			Destroy(gameObject);
			Instantiate(explosionParticle ,transform.position ,explosionParticle.transform.rotation);
			gameManager.UptadeScore(pointValue);
		}
		if(gameObject.CompareTag("bad")){
			gameManager.GameOver();
		}
		
	}
	private void OnTriggerEnter(Collider other){
		
		Destroy(gameObject);
		
	}
}
