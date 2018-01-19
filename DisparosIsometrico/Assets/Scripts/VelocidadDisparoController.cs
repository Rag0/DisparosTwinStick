using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadDisparoController : MonoBehaviour
{
	public float bonusVelocidadDisparo;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (PlayerController.fireRate > 0.2f)
			{
				PlayerController.fireRate -= bonusVelocidadDisparo;
			}

			Destroy (gameObject);
		}
	}
}
