using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss1Controller : MonoBehaviour
{
	public float velocidadBala;
	private float movActualBalaEnem;

	public static float movInicialBalaEnem;

	// Use this for initialization
	void Awake()
	{
		movActualBalaEnem = movInicialBalaEnem;
	}

	// Update is called once per frame
	void Update()
	{
		if (!GameController.gameOver)
		{
			float movX = transform.position.x;
			float movY = transform.position.y;

			if (movActualBalaEnem == 1) // Izquierda
			{
				movX = movX - velocidadBala;
			}

			else if (movActualBalaEnem == 2) // Derecha
			{
				movX = movX + velocidadBala;
			}

			else if (movActualBalaEnem == 3) // Abajo
			{
				movY = movY - velocidadBala;
			}

			else if (movActualBalaEnem == 4) // Arriba
			{
				movY = movY + velocidadBala;
			}

			else if (movActualBalaEnem == 5) // Izquierda Abajo
			{
				movX = movX - velocidadBala;
				movY = movY - velocidadBala;
			}

			else if (movActualBalaEnem == 6) // Izquierda Arriba
			{
				movX = movX - velocidadBala;
				movY = movY + velocidadBala;
			}

			else if (movActualBalaEnem == 7) // Derecha Abajo
			{
				movX = movX + velocidadBala;
				movY = movY - velocidadBala;
			}

			else if (movActualBalaEnem == 8) // Derecha Arriba
			{
				movX = movX + velocidadBala;
				movY = movY + velocidadBala;
			}

			else
			{
				Debug.Log ("No hay movimiento bala Boss 1");
			}

			transform.position = new Vector3(movX, movY, transform.position.z);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(other.gameObject);
			GameController.gameOver = true;
		}

		if (other.gameObject.tag != "Enemigo1" && other.gameObject.tag != "Boss1" && other.gameObject.tag != "BalaPlayer" && other.gameObject.tag != "ItemDrop" && other.gameObject.tag != "BalaEnemigo")
		{
			Destroy(gameObject);
		}
	}
}
