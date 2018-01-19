using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDobleController : MonoBehaviour
{
	public int bonusCantidadDisparos;

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
			if (BaseConst.cantidadBalasActual < 2)
			{
				BaseConst.cantidadBalasActual += bonusCantidadDisparos;
			}

			Destroy (gameObject);
		}
	}
}
