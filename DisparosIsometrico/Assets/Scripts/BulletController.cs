using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
	private float disparoActual;

	public int puntajeEnemigo;
	private int contadorRebotes;

	public static int danhoBulletPlayer = 5;

	public GameObject itemVelocidadDisparo;
	public GameObject itemVelocidadBala;
	public GameObject itemCantidadBalas;
	public GameObject itemBulletRebote;

    // Use this for initialization
    void Start ()
    {
        disparoActual = PlayerController.disparoActual;
		PlayerController.disparoActual = 0;
		contadorRebotes = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameController.gameOver)
        {
            float movX = transform.position.x;
            float movY = transform.position.y;

            if (disparoActual == 1)
            {
				movX = movX + BaseConst.velocidadBalaActual;
            }

            else if (disparoActual == 2)
            {
				movX = movX - BaseConst.velocidadBalaActual;
            }

            else if (disparoActual == 3)
            {
				movY = movY + BaseConst.velocidadBalaActual;
            }

            else if (disparoActual == 4)
            {
				movY = movY - BaseConst.velocidadBalaActual;
            }

            transform.position = new Vector3(movX, movY, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "BalaEnemigo" && other.gameObject.tag != "ItemDrop" && other.gameObject.tag != "BalaPlayer")
        {
			// calcular rebote
			if (BaseConst.tipoBulletActual == 2 && contadorRebotes < 1 && other.gameObject.tag == "Muro")
			{
				if (disparoActual == 1)
				{
					disparoActual = 2;
				} 

				else if (disparoActual == 2)
				{
					disparoActual = 1;
				}

				else if (disparoActual == 3)
				{
					disparoActual = 4;
				}

				else if (disparoActual == 4)
				{
					disparoActual = 3;
				}

				contadorRebotes++;
			}

			else 
			{
				Destroy (gameObject);
			}
        }

        if (other.gameObject.tag == "Enemigo1")
        {
			Vector2 posActualEnemigo = new Vector2 (other.gameObject.transform.position.x, other.gameObject.transform.position.y);

            Destroy(other.gameObject);
			SpawnearDrop("Enemigo1", posActualEnemigo);

			GameController.score = GameController.score + Enemigo1Controller.puntaje;
        }

		if (other.gameObject.tag == "Boss1")
		{
			// Asignar daño
			Boss1Controller.estaDanado = true;
		}
    }

	void SpawnearDrop (string tipoEnemigo, Vector2 posActualEnemigo)
	{
		switch (tipoEnemigo)
		{
			case "Enemigo1":
				calcularProbabilidadDrop (posActualEnemigo);

				break;

			default:

				break;
		}
	}

	void calcularProbabilidadDrop (Vector2 posActualEnemigo)
	{
		float probabilidad = 0.5f;
		float numeroRandom = Random.Range(0f, 1f);

		if (numeroRandom <= probabilidad)
		{
			if (numeroRandom <= 0.25f)
			{
				Instantiate(itemVelocidadBala, posActualEnemigo, Quaternion.identity);
			}

			else
			{
				Instantiate(itemVelocidadDisparo, posActualEnemigo, Quaternion.identity);
			}
		}

		else
		{
			if (numeroRandom >= 0.75f)
			{
				Instantiate(itemCantidadBalas, posActualEnemigo, Quaternion.identity);
			}

			else
			{
				Instantiate(itemBulletRebote, posActualEnemigo, Quaternion.identity);
			}
		}			
	}

	/*void calcularDisparoRebote(string tagObjeto, GameObject gameObject)
	{
		if (contadorRebotes < 1 && tagObjeto == "Muro") 
		{
			if (disparoActual == 1) 
			{
				disparoActual = 2;
			}

			else if (disparoActual == 2) 
			{
				disparoActual = 1;
			}

			else if (disparoActual == 3) 
			{
				disparoActual = 4;
			}

			else if (disparoActual == 4) 
			{
				disparoActual = 3;
			}

			contadorRebotes++;
		}
	}*/
}
